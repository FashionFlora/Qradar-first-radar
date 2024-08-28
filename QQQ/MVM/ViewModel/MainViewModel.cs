using LogicLyric.MVM.Model;
using LogicLyric.MVM.View;
using LogicLyric.Repositories;
using LogicLyric.Settings;
using LogicLyric.Utils;
using LogicLyrico;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Input;
using System.Windows.Media;

namespace LogicLyric.MVM.ViewModel
{
    public class MainViewModel : ViewModelBase
    {


        //Fields



   
        private IUserRepository userRepository;

        private UserAccountModel _currentUserAccount;



        private ViewModelBase _currentChildView;
        private string _caption;

        DrawView drawView;

  


        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }

            set
            {
                _currentUserAccount = value;
  
                OnPropertyChanged(nameof(CurrentUserAccount));

            }
        }

        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public ICommand ShowPlayerViewCommand { get; }
        public ICommand ShowRawViewCommand { get; }
        public ICommand ShowSettingsViewCommand { get; }
        public ICommand ShowChestViewCommand { get; }

        public ICommand ShowIgnoreListCommand { get; }
        public MainViewModel()
        {




            System.Threading.Thread.Sleep(399);


      
         

    
   


            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();

            ShowPlayerViewCommand = new ViewModelCommand(ExecuteShowPlayerView);
            ShowRawViewCommand = new ViewModelCommand(ExecuteShowRawView);

            ShowSettingsViewCommand = new ViewModelCommand(ExecuteShowSettings);

            ShowChestViewCommand = new ViewModelCommand(ExecuteShowChest);

           ShowIgnoreListCommand  =   new ViewModelCommand(ExecuteShowIgnoreList);

            //Default view
            drawView = new DrawView();
            ExecuteShowPlayerView(null);


            LoadCurrentUserData();


   

            drawView.ShowInTaskbar = false;

            drawView.Top = Properties.Settings.Default.translationWindowYSetting;
            drawView.Left = Properties.Settings.Default.translationWindowXSetting;
            if(Properties.Settings.Default.windowSizeSetting<=0)
            {
                drawView.Height = 400;
                drawView.Width = 400;


            }
            else
            {
                drawView.Height = Properties.Settings.Default.windowSizeSetting;
                drawView.Width = Properties.Settings.Default.windowSizeSetting;
            }
 

    
            drawView.Show();

            updateSettings();
        }

        private void updateSettings()
        {









            RadarSettings.updateHarvestingTier(1, Properties.Settings.Default.harvestingT1Setting);
            RadarSettings.updateHarvestingTier(2, Properties.Settings.Default.harvestingT2Setting);
            RadarSettings.updateHarvestingTier(3, Properties.Settings.Default.harvestingT3Setting);
            RadarSettings.updateHarvestingTier(4, Properties.Settings.Default.harvestingT4Setting);
            RadarSettings.updateHarvestingTier(5, Properties.Settings.Default.harvestingT5Setting);
            RadarSettings.updateHarvestingTier(6, Properties.Settings.Default.harvestingT6Setting);
            RadarSettings.updateHarvestingTier(7, Properties.Settings.Default.harvestingT7Setting);
            RadarSettings.updateHarvestingTier(8, Properties.Settings.Default.harvestingT8Setting);


            RadarSettings.updateHarvestingEnchant(0, Properties.Settings.Default.harvestingE0Setting);
            RadarSettings.updateHarvestingEnchant(1, Properties.Settings.Default.harvestingE1Setting);
            RadarSettings.updateHarvestingEnchant(2, Properties.Settings.Default.harvestingE2Setting);
            RadarSettings.updateHarvestingEnchant(3, Properties.Settings.Default.harvestingE3Setting);



            RadarSettings.updateMobTiers(1, Properties.Settings.Default.mobT1Setting);
            RadarSettings.updateMobTiers(2, Properties.Settings.Default.mobT2Setting);
            RadarSettings.updateMobTiers(3, Properties.Settings.Default.mobT3Setting);
            RadarSettings.updateMobTiers(4, Properties.Settings.Default.mobT4Setting);
            RadarSettings.updateMobTiers(5, Properties.Settings.Default.mobT5Setting);
            RadarSettings.updateMobTiers(6, Properties.Settings.Default.mobT6Setting);
            RadarSettings.updateMobTiers(7, Properties.Settings.Default.mobT7Setting);
            RadarSettings.updateMobTiers(8, Properties.Settings.Default.mobT8Setting);

            RadarSettings.updateMobEnchants(0, Properties.Settings.Default.mobE0Setting);
            RadarSettings.updateMobEnchants(1, Properties.Settings.Default.mobE1Setting);
            RadarSettings.updateMobEnchants(2, Properties.Settings.Default.mobE2Setting);
            RadarSettings.updateMobEnchants(3, Properties.Settings.Default.mobE3Setting);
            RadarSettings.updateMobEnchants(4, Properties.Settings.Default.mobE4Setting);


            RadarSettings.updateMobTypes(0, Properties.Settings.Default.mobHarvestableSetting);
            RadarSettings.updateMobTypes(1, Properties.Settings.Default.mobSkinnableSetting);
            RadarSettings.updateMobTypes(2, Properties.Settings.Default.mobOtherSetting);


            RadarSettings.updateHarvestableType(new List<HarvestableType>{
                HarvestableType.FIBER,
                HarvestableType.FIBER_CRITTER,
                HarvestableType.FIBER_GUARDIAN_DEAD,
                HarvestableType.FIBER_GUARDIAN_RED
            }, Properties.Settings.Default.harvestingFiberSetting);
            RadarSettings.updateHarvestableType(new List<HarvestableType>{
                HarvestableType.WOOD,
                HarvestableType.WOOD_CRITTER_DEAD,
                HarvestableType.WOOD_CRITTER_GREEN,
                HarvestableType.WOOD_CRITTER_RED,
                HarvestableType.WOOD_GIANTTREE,
                HarvestableType.WOOD_GUARDIAN_RED
            }, Properties.Settings.Default.harvestingWoodSetting);
            RadarSettings.updateHarvestableType(new List<HarvestableType>{
                HarvestableType.ORE,
                HarvestableType.ORE_CRITTER_DEAD,
                HarvestableType.ORE_CRITTER_GREEN,
                HarvestableType.ORE_CRITTER_RED,
                HarvestableType.ORE_GUARDIAN_RED
            }, Properties.Settings.Default.harvestingOreSetting);
            RadarSettings.updateHarvestableType(new List<HarvestableType>{
                HarvestableType.ROCK,
                HarvestableType.ROCK_CRITTER_DEAD,
                HarvestableType.ROCK_CRITTER_GREEN,
                HarvestableType.ROCK_CRITTER_RED,
                HarvestableType.ROCK_GUARDIAN_RED
            }, Properties.Settings.Default.harvestingRockSetting);



            RadarSettings.updateHarvestableType(new List<HarvestableType>{
                HarvestableType.HIDE,
                HarvestableType.HIDE_FOREST,
                HarvestableType.HIDE_STEPPE,
                HarvestableType.HIDE_SWAMP,
                HarvestableType.HIDE_MOUNTAIN,
                HarvestableType.HIDE_HIGHLAND,
                HarvestableType.HIDE_CRITTER,
                HarvestableType.HIDE_GUARDIAN,
            }, Properties.Settings.Default.harvestingHideSetting);





            RadarSettings.updateChestEnchants("standard", Properties.Settings.Default.greenAvalonSetting);
            RadarSettings.updateChestEnchants("green", Properties.Settings.Default.greenAvalonSetting);
            RadarSettings.updateChestEnchants("uncommon", Properties.Settings.Default.blueAvalonSetting);
            RadarSettings.updateChestEnchants("blue", Properties.Settings.Default.blueAvalonSetting);
            RadarSettings.updateChestEnchants("rare", Properties.Settings.Default.purpleAvalonSetting);
            RadarSettings.updateChestEnchants("purple", Properties.Settings.Default.purpleAvalonSetting);
            RadarSettings.updateChestEnchants("legendary", Properties.Settings.Default.legendaryAvalonSetting);
            RadarSettings.updateChestEnchants("yellow", Properties.Settings.Default.legendaryAvalonSetting);


            RadarSettings.updateDungeonEnchant(0, Properties.Settings.Default.dungeonE0BindSetting);
            RadarSettings.updateDungeonEnchant(1, Properties.Settings.Default.dungeonE1BindSetting);
            RadarSettings.updateDungeonEnchant(2, Properties.Settings.Default.dungeonE2BindSetting);
            RadarSettings.updateDungeonEnchant(3, Properties.Settings.Default.dungeonE3BindSetting);
            RadarSettings.updateDungeonEnchant(4, Properties.Settings.Default.dungeonE4BindSetting);

            RadarSettings.updateDungeonType(0, Properties.Settings.Default.dungeonSoloSetting);
            RadarSettings.updateDungeonType(1, Properties.Settings.Default.dungeonDuoSetting);



            RadarSettings.updateMistType(0, Properties.Settings.Default.mistSoloSetting);
            RadarSettings.updateMistType(1, Properties.Settings.Default.mistDuoSetting);

            RadarSettings.updatemistEnchant(0, Properties.Settings.Default.mistE0BindSetting);
            RadarSettings.updatemistEnchant(1, Properties.Settings.Default.mistE1BindSetting);
            RadarSettings.updatemistEnchant(2, Properties.Settings.Default.mistE2BindSetting);
            RadarSettings.updatemistEnchant(3, Properties.Settings.Default.mistE3BindSetting);
            RadarSettings.updatemistEnchant(4, Properties.Settings.Default.mistE4BindSetting);

            RadarSettings.updateMistBosses("spider", Properties.Settings.Default.spiderSetting);
            RadarSettings.updateMistBosses("veilweaver", Properties.Settings.Default.weilWeaverSetting);
            RadarSettings.updateMistBosses("griffin", Properties.Settings.Default.griffinSetting);
            RadarSettings.updateMistBosses("fairydragon", Properties.Settings.Default.fairyDragonSetting);
            //       RadarSettings.updateMistBosses(0,Prop)




            // Properties.Settings.Default.typeMembers.Add();


            if(Properties.Settings.Default.positionSetting==null)
            {
 
                Properties.Settings.Default.positionSetting = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.typeMembersSetting = new System.Collections.Specialized.StringCollection();
                Properties.Settings.Default.membersSetting = new System.Collections.Specialized.StringCollection();


                Properties.Settings.Default.Save();
            }
  


            if (Properties.Settings.Default.positionSetting != null)
            {


                var converter = new BrushConverter();

                for (int i = 0; i < Properties.Settings.Default.positionSetting.Count; i++)
                {
                    IgnoreListItems.members.Add(new Member { Number = Properties.Settings.Default.positionSetting[i], Character = Properties.Settings.Default.membersSetting[i][0].ToString(), BgColor = (Brush)converter.ConvertFromString("#1098AD"), Name = Properties.Settings.Default.membersSetting[i], Type = Properties.Settings.Default.typeMembersSetting[i] });
                }
            }

            drawView.invalidateCircles();

            drawView.updateSizeMain();



        }

        private void ExecuteShowChest(object obj)
        {
            CurrentChildView = new ChestViewModel(drawView);
        }

        private void ExecuteShowSettings(object obj)
        {
            CurrentChildView = new SettingsViewModel(drawView);

        }

        private void ExecuteShowRawView(object obj)
        {
            CurrentChildView = new  RawViewModel(drawView);

        }
        private void ExecuteShowPlayerView(object obj)
        {
            CurrentChildView = new PlayerViewModel(drawView);

        }

        private void ExecuteShowIgnoreList(object obj)
        {
            CurrentChildView = new DataGridViewModel(drawView);

        }



        private void LoadCurrentUserData()
        {


           CurrentUserAccount.DisplayName = "Logged as "  + " Days Left: 9999 ";

        }

            

        private void Shutdown()
        {
            Environment.Exit(1);
        }

            
    }
}
