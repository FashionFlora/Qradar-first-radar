using LogicLyric;

using LogicLyric.Chests;

using LogicLyric.HarvestableCodes;

using LogicLyric.CanvasDrawings;
using LogicLyric.CanvasItems;

using LogicLyrico;
using LogicLyrico.Mobs;
using System;
using System.Threading;

using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Net.Sockets;

using System.Collections.Generic;

using LogicLyric.RestEventsHandlers;
using LogicLyric.AAParser;
using LogicLyric.Core;
using LogicLyric.Dungeons;
using LogicLyric.Mists;
using SharpPcap;
using PacketDotNet;

namespace LogicLyric.MVM.View
{
    /// <summary>
    /// Interaction logic for DrawView.xaml
    /// </summary>
    public partial class DrawView : Window
    {



        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && Properties.Settings.Default.dragAndDropSetting)
            {
                DragMove();

                Properties.Settings.Default.translationWindowXSetting = (int)this.Left;
                Properties.Settings.Default.translationWindowYSetting = (int)this.Top;

                Properties.Settings.Default.Save();
            }
        }


        private  ProtocolParser receiver;


        PlayerHandler playerHandler = new PlayerHandler();
        HarvestableHandler harvestableHandler = new HarvestableHandler();

        internal void invalidateMistBosses()
        {
            drawMistsBosses.invalidateType();
        }

        MobsHandler mobsHandler;
        CanvasEnemyPlayerItems canvasEnemyPlayerItems = new CanvasEnemyPlayerItems();

        DungeonHandler dungeonHandler = new DungeonHandler();

        MistHandler mistHandler = new MistHandler();

        ChestHandler chestHandler = new ChestHandler();

        public DrawEnemyPlayers drawEnemyPlayers;
        DrawHarvestables drawHarvestables;
        DrawMobs drawMobs;
        DrawCircles drawCircles;
        DrawChests drawChests;
        DrawMistsBosses drawMistsBosses;

        DrawMists drawMists;


        DrawDungeons drawDungeons;


   

        internal void invalidateDevMode()
        {
            drawMobs.invalidateDevMode();
        }

  

        Single lpX;
        Single lpY;

    
        Matrix transformationMatrix = new Matrix();

        public DrawView()
        {
            InitializeComponent();
            Initialize();

        }

        public void clearAll()
        {


            try
            {
                mobsHandler.mobsList.Clear();
                playerHandler.playersInRange.Clear();
                harvestableHandler.harvestableList.Clear();
                mistHandler.mistList.Clear();
                dungeonHandler.dungeonList.Clear();
                chestHandler.chestsList.Clear();

            }
            catch
            {

            }





        }

        internal void invalidateGuild()
        {
            drawEnemyPlayers.invalidateGuild();
        }


        internal void invalidatePlayerDistance()
        {
            drawEnemyPlayers.invalidateDistance();
        }

        internal void invalidateDungeons()
        {


        }



        PlayerItemHandler playerItemHandler;
        private void Initialize()
        {

            mobsHandler = new MobsHandler();

            //    RenderOptions.ProcessRenderMode = System.Windows.Interop.RenderMode.SoftwareOnly;

            /*
            transformationMatrix.Translate(250, 250);
            transformationMatrix.RotateAt(225f, 250, 250);
            transformationMatrix.ScaleAt(4f, 4f, 250, 250);

            */

            CanvasChestItems.chests.Clear();
            CanvasDungeonItems.dungeonItems.Clear();
            CanvasEnemyPlayerItems.enemyPlayers.Clear();
            CanvasHarvestableItem.harvestableItems.Clear();
            CanvasMistBossesItems.mistBossesItems.Clear();

            CanvasMistItems.mistItems.Clear();
            CanvasMobItems.mobs.Clear();




        //    canvasAnimation.init(transformationMatrix, harvestableHandler);

            playerItemHandler = new PlayerItemHandler();

            this.Left = 0;
            this.Top = 0;



            drawEnemyPlayers = new DrawEnemyPlayers(playerHandler, this.canva, playerItemHandler);
            drawHarvestables = new DrawHarvestables(harvestableHandler, this.canva);
            drawChests = new DrawChests(chestHandler, this.canva);
            drawMobs = new DrawMobs(mobsHandler, this.canva);
            drawCircles = new DrawCircles(this.canva);
            drawDungeons = new DrawDungeons(dungeonHandler, this.canva);
            drawMists = new DrawMists(mistHandler, this.canva);
            drawMistsBosses = new DrawMistsBosses(mistHandler, this.canva);
   
    

            ReceiverBuilder builder = ReceiverBuilder.Create();


            builder.AddRequestHandler(new MoveRequestHandler(playerHandler));
            builder.AddRequestHandler(new EnterMistOperationHandler(playerHandler, mobsHandler, chestHandler, dungeonHandler, mistHandler, harvestableHandler));
            builder.AddRequestHandler(new EnterVillageOperationHandler(playerHandler, mobsHandler, chestHandler, dungeonHandler, mistHandler, harvestableHandler));
            builder.AddEventHandler(new MoveEventHandler(playerHandler, mobsHandler, mistHandler));
            builder.AddEventHandler(new NewCharacterEventHandler(playerHandler, drawEnemyPlayers));
            builder.AddEventHandler(new LeaveEventHandler(playerHandler, mobsHandler, chestHandler, dungeonHandler, mistHandler, harvestableHandler));


            builder.AddEventHandler(new MobChangeStateEventHandler(mobsHandler, harvestableHandler));
            builder.AddEventHandler(new NewMobEventHandler(mobsHandler, mistHandler));
            builder.AddEventHandler(new HarvestFinishedEventHandler(harvestableHandler));


            builder.AddEventHandler(new NewHarvestableObjectEventHandler(harvestableHandler));
            builder.AddEventHandler(new NewSimpleHarvestableObjectListEventHandler(harvestableHandler));


            builder.AddEventHandler(new JoinFinishedEventHandler(harvestableHandler, mobsHandler));
            builder.AddEventHandler(new AvalonEventHandler(chestHandler));


            builder.AddEventHandler(new PlayerNewItemEventHandler(playerHandler));
            builder.AddEventHandler(new PlayerAttackEventHandler(playerHandler));
            builder.AddEventHandler(new PlayerChangeEventHandler(playerHandler));
            builder.AddEventHandler(new PlayerRegenEventHandler(playerHandler));
            builder.AddEventHandler(new FirstTimeMountedEventHandler(playerHandler));


            builder.AddEventHandler(new DungeonEventHandler(dungeonHandler));
            receiver = builder.Build();





            CaptureDeviceList devices = CaptureDeviceList.Instance;
            foreach (var device in devices)
            {
                new Thread(() =>
                {
                    Console.WriteLine($"Open... {device.Description}");

                    device.OnPacketArrival += new PacketArrivalEventHandler(PacketHandler);
                    device.Open(DeviceMode.Promiscuous, 1);
                    device.StartCapture();
                })
                .Start();
            }


        }

        internal void updateSizeMain()
        {

            
            transformationMatrix = new Matrix();

            double size = this.Height / 2;

            float scale = Properties.Settings.Default.windowScaleSetting;

            if(scale==0)
            {
                scale = 4f;
            }
            else
            {
                scale = scale / 10;

            }
            Console.WriteLine(scale);



            transformationMatrix.Translate(size, size);
            transformationMatrix.RotateAt(225f, size, size);
            transformationMatrix.ScaleAt(scale, scale, size, size);

            
        }

        internal void updateScale()
        {
            throw new NotImplementedException();
        }

        internal void invalidateMobExp()
        {
            drawMobs.invalidateExp();
        }

        private void CapturePackets()
        {

 


            





        }


        private  void PacketHandler(object sender, CaptureEventArgs e)
        {
            UdpPacket packet = Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data).Extract<UdpPacket>();
            if (packet != null && (packet.SourcePort == 5056 || packet.DestinationPort == 5056))
            {
                try
                {


                    receiver.ReceivePacket(packet.PayloadData);
                    invalidate();
                }
                catch
                {
                    
                }
            }
        }





        internal void invalidateHarvestingIconsSize()
        {
            drawHarvestables.invalidateIcons();
        }

        internal void invalidateDungeonsEnchant()
        {
            drawDungeons.invalidateEnchant();
        }

        internal void invalidateMistEnchant()
        {
            drawMists.invalidateEnchant();
        }

        internal void invalidateCorrupt()
        {
            drawDungeons.invalidateCorrupt();
        }

        internal void invalidateDungeonType()
        {
            drawDungeons.invalidateType();
        }


        public void invalidate()
        {










            lock (StaticLocks.localLock)
            {

                lpX = playerHandler.localPlayerPosX();
                lpY = playerHandler.localPlayerPosY();






            }






            this.Dispatcher.InvokeAsync(() =>
            {




                drawDungeons.invalidate(lpX, lpY, transformationMatrix);
                drawChests.invalidate(lpX, lpY, transformationMatrix);

                lock (StaticLocks.harvestLock)
                {
                    drawHarvestables.invalidate(lpX, lpY, transformationMatrix);
                }

                drawMistsBosses.invalidate(lpX, lpY, transformationMatrix);
                lock (StaticLocks.mistsLock)
                {
                    drawMists.invalidate(lpX, lpY, transformationMatrix);
                }


                lock (StaticLocks.mobsLock)
                {
                    drawMobs.invalidate(lpX, lpY, transformationMatrix);
                }


                lock (StaticLocks.playersLock)
                {
                    drawEnemyPlayers.invalidate(lpX, lpY, transformationMatrix);
                }






            });















        }


        internal void updateItemsTranslationY()
        {
            drawEnemyPlayers.setItemsWindowTranslationY();

        }

        internal void updateItemsTranslationX()
        {
            drawEnemyPlayers.setItemsWindowTranslationX();
        }



        internal void invalidatePlayersItemsHeight()
        {
            drawEnemyPlayers.setItemsWindowHeight();
        }

        internal void invalidatePlayersItemsWidth()
        {
            drawEnemyPlayers.setItemsWindoWidth();

        }
        internal void invalidateMistType()
        {
            drawMists.invalidateType();
        }

        public void invalidateCircles()
        {


            drawCircles.invalidate(this.Width, this.Height);
            drawEnemyPlayers.invalidateCircles();
        }
        public void invalidatePlayerNicknames()
        {
            drawEnemyPlayers.invalidatePlayersNicknames();

        }

        internal void invalidateHellGate()
        {

            drawDungeons.invalidateHellGate();
        }

        public void invalidatePlayers()
        {

            drawEnemyPlayers.invalidatePlayers();

        }

        public void invalidateHarvestableTiers()
        {

            drawHarvestables.invalidateTiers();
        }

        public void invalidateHarvestableEnchants()
        {

            drawHarvestables.invalidateEnchants();
        }
        public void invalidateHarvestableSize()
        {
            drawHarvestables.invalidateSize();
        }


        public void invalidateMobEnchants()
        {
            drawMobs.invalidateEnchants();
        }

        public void invalidatePlayersHealths()
        {
            drawEnemyPlayers.invalidateHealth();
        }


        public void invalidateChestEnchants()
        {
            drawChests.invalidateEnchant();
        }


        internal void invalidateHarvestableTypes()
        {
            drawHarvestables.invalidateTypes();
        }

        internal void invalidatePlayersItems()
        {
            drawEnemyPlayers.invalidateItems();
        }

        internal void invalidatePlayerMounts(bool value)
        {
            drawEnemyPlayers.invalidateMounted(value);
        }

        internal void updateSize()
        {
            // drawEnemyPlayers.updateTranslation();
        }


        internal void invalidateMobTiers()
        {
            drawMobs.invalidateTiers();
        }

        internal void invalidateMobTypes()
        {
            drawMobs.invalidateTypes();
        }

        internal void invalidateOtherBosses()
        {
            drawMobs.invalidateOtherBosses();
        }

        internal void invalidateDrones()
        {
            drawMobs.invalidateDrones();
        }


    }
}
