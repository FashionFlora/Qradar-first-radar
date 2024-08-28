using LogicLyric.MVM.View;
using LogicLyric.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLyric.MVM.ViewModel
{
    public class ChestViewModel : ViewModelBase
    {



        DrawView drawView;

        public bool greenAvalonBind
        {
            get
            {
                return Properties.Settings.Default.greenAvalonSetting;
            }
            set
            {
                Properties.Settings.Default.greenAvalonSetting = value;
                Properties.Settings.Default.Save();
                RadarSettings.updateChestEnchants("standard", Properties.Settings.Default.greenAvalonSetting);
                RadarSettings.updateChestEnchants("green", Properties.Settings.Default.greenAvalonSetting);
                drawView.invalidateChestEnchants();
            }
        }

        public bool blueAvalonBind
        {
            get
            {
                return Properties.Settings.Default.blueAvalonSetting;
            }
            set
            {
                Properties.Settings.Default.blueAvalonSetting = value;
                Properties.Settings.Default.Save();
                RadarSettings.updateChestEnchants("uncommon", Properties.Settings.Default.blueAvalonSetting);
                RadarSettings.updateChestEnchants("blue", Properties.Settings.Default.blueAvalonSetting);
                drawView.invalidateChestEnchants();
            }
        }
        public bool purpleAvalonBind
        {
            get
            {
                return Properties.Settings.Default.purpleAvalonSetting;
            }
            set
            {
                Properties.Settings.Default.purpleAvalonSetting = value;
                Properties.Settings.Default.Save();
                RadarSettings.updateChestEnchants("rare", Properties.Settings.Default.purpleAvalonSetting);
                RadarSettings.updateChestEnchants("purple", Properties.Settings.Default.purpleAvalonSetting);
                drawView.invalidateChestEnchants();
            }
        }
        public bool legendaryAvalonBind
        {
            get
            {
                return Properties.Settings.Default.legendaryAvalonSetting;
            }
            set
            {
                Properties.Settings.Default.legendaryAvalonSetting = value;
                Properties.Settings.Default.Save();
                RadarSettings.updateChestEnchants("legendary", Properties.Settings.Default.legendaryAvalonSetting);
                RadarSettings.updateChestEnchants("yellow", Properties.Settings.Default.legendaryAvalonSetting);
                drawView.invalidateChestEnchants();
            }
        }

        public bool dungeonE0Bind
        {
            get
            {
                return Properties.Settings.Default.dungeonE0BindSetting;
            }
            set
            {
                Properties.Settings.Default.dungeonE0BindSetting = value;
                Properties.Settings.Default.Save();
                RadarSettings.updateDungeonEnchant(0, Properties.Settings.Default.dungeonE0BindSetting);
                drawView.invalidateDungeonsEnchant();
            }
        }

        public bool dungeonE1Bind
        {
            get
            {
                return Properties.Settings.Default.dungeonE1BindSetting;
            }
            set
            {
                Properties.Settings.Default.dungeonE1BindSetting = value;
                Properties.Settings.Default.Save();
                RadarSettings.updateDungeonEnchant(1, Properties.Settings.Default.dungeonE1BindSetting);
                drawView.invalidateDungeonsEnchant();
            }
        }


        public bool dungeonE2Bind
        {
            get
            {
                return Properties.Settings.Default.dungeonE2BindSetting;
            }
            set
            {
                Properties.Settings.Default.dungeonE2BindSetting = value;
                Properties.Settings.Default.Save();
                RadarSettings.updateDungeonEnchant(2, Properties.Settings.Default.dungeonE2BindSetting);
                drawView.invalidateDungeonsEnchant();
            }
        }


        public bool dungeonE3Bind
        {
            get
            {
                return Properties.Settings.Default.dungeonE3BindSetting;
            }
            set
            {
                Properties.Settings.Default.dungeonE3BindSetting = value;
                Properties.Settings.Default.Save();
                RadarSettings.updateDungeonEnchant(3, Properties.Settings.Default.dungeonE3BindSetting);
                drawView.invalidateDungeonsEnchant();
            }
        }



        public bool dungeonE4Bind
        {
            get
            {
                return Properties.Settings.Default.dungeonE4BindSetting;
            }
            set
            {
                Properties.Settings.Default.dungeonE4BindSetting = value;
                Properties.Settings.Default.Save();
                RadarSettings.updateDungeonEnchant(4, Properties.Settings.Default.dungeonE4BindSetting);
                drawView.invalidateDungeonsEnchant();
            }
        }



        public bool mistE0Bind
        {
            get
            {
                return Properties.Settings.Default.mistE0BindSetting;
            }
            set
            {
                Properties.Settings.Default.mistE0BindSetting = value;
                RadarSettings.updatemistEnchant(0, Properties.Settings.Default.mistE0BindSetting);
                Properties.Settings.Default.Save();
                drawView.invalidateMistEnchant();
            }
        }


        public bool mistE1Bind
        {
            get
            {
                return Properties.Settings.Default.mistE1BindSetting;
            }
            set
            {
                Properties.Settings.Default.mistE1BindSetting = value;
                RadarSettings.updatemistEnchant(1, Properties.Settings.Default.mistE1BindSetting);
                Properties.Settings.Default.Save();
                drawView.invalidateMistEnchant();
            }
        }



        public bool mistE2Bind
        {
            get
            {
                return Properties.Settings.Default.mistE2BindSetting;
            }
            set
            {
                Properties.Settings.Default.mistE2BindSetting = value;
                Properties.Settings.Default.Save();
                RadarSettings.updatemistEnchant(2, Properties.Settings.Default.mistE2BindSetting);
                drawView.invalidateMistEnchant();
            }
        }


        public bool mistE3Bind
        {
            get
            {
                return Properties.Settings.Default.mistE3BindSetting;
            }
            set
            {
                Properties.Settings.Default.mistE3BindSetting = value;
                Properties.Settings.Default.Save();
                RadarSettings.updatemistEnchant(3, Properties.Settings.Default.mistE3BindSetting);
                drawView.invalidateMistEnchant();
            }
        }

        public bool mistE4Bind
        {
            get
            {
                return Properties.Settings.Default.mistE4BindSetting;
            }
            set
            {
                Properties.Settings.Default.mistE4BindSetting = value;
                Properties.Settings.Default.Save();
                RadarSettings.updatemistEnchant(4, Properties.Settings.Default.mistE4BindSetting);
                drawView.invalidateMistEnchant();
            }
        }

        public bool corruptBind
        {
            get
            {
                return Properties.Settings.Default.corruptSetting;
            }
            set
            {
                Properties.Settings.Default.corruptSetting = value;
                Properties.Settings.Default.Save();
                drawView.invalidateCorrupt();

            }
        }


        public bool dungeonDuoBind
        {
            get
            {
                return Properties.Settings.Default.dungeonDuoSetting;
            }
            set
            {
                Properties.Settings.Default.dungeonDuoSetting = value;
                Properties.Settings.Default.Save();

                RadarSettings.updateDungeonType(1, Properties.Settings.Default.dungeonDuoSetting);

                drawView.invalidateDungeonType();

            }
        }

        public bool dungeonSoloBind
        {
            get
            {
                return Properties.Settings.Default.dungeonSoloSetting;
            }
            set
            {
                Properties.Settings.Default.dungeonSoloSetting = value;
                Properties.Settings.Default.Save();

                RadarSettings.updateDungeonType(0, Properties.Settings.Default.dungeonSoloSetting);
                drawView.invalidateDungeonType();
            }
        }


        public bool mistSoloBind
        {
            get
            {
                return Properties.Settings.Default.mistSoloSetting;
            }
            set
            {
                Properties.Settings.Default.mistSoloSetting = value;
                Properties.Settings.Default.Save();
                RadarSettings.updateMistType(0, Properties.Settings.Default.mistSoloSetting);
                drawView.invalidateMistType();
            }
        }


        public bool mistDuoBind
        {
            get
            {
                return Properties.Settings.Default.mistDuoSetting;
            }
            set
            {
                Properties.Settings.Default.mistDuoSetting = value;
                Properties.Settings.Default.Save();

     
                RadarSettings.updateMistType(1, Properties.Settings.Default.mistDuoSetting);
                drawView.invalidateMistType();
           
            }
        }

     

        public bool hellgateBind
        {
            get
            {
                return Properties.Settings.Default.hellgateSetting;
            }
            set
            {
                Properties.Settings.Default.hellgateSetting = value;
                Properties.Settings.Default.Save();

                drawView.invalidateHellGate();

            }
        }


        public ChestViewModel(DrawView drawView)
        {


            this.drawView = drawView;
        }
        

    }

}
