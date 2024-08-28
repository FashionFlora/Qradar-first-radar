using LogicLyric.MVM.View;
using LogicLyric.MVM.ViewModel;
using LogicLyric.Settings;
using LogicLyrico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLyric.MVM.ViewModel
{
    public class RawViewModel : ViewModelBase
    {
        private DrawView drawView;



        public bool harvestingT1Bind
        {
            get
            {
                return Properties.Settings.Default.harvestingT1Setting;
            }
            set
            {
                Properties.Settings.Default.harvestingT1Setting = value;
                RadarSettings.updateHarvestingTier(1, value);
                Properties.Settings.Default.Save();

                drawView.invalidateHarvestableTiers();
            }
        }
        public bool harvestingHideBind
        {
            get
            {
                return Properties.Settings.Default.harvestingHideSetting;
            }
            set
            {
                Properties.Settings.Default.harvestingHideSetting = value;
                Properties.Settings.Default.Save();

                RadarSettings.updateHarvestableType(new List<HarvestableType>{
                HarvestableType.HIDE,
                HarvestableType.HIDE_FOREST,
                HarvestableType.HIDE_STEPPE,
                HarvestableType.HIDE_SWAMP,
                HarvestableType.HIDE_MOUNTAIN,
                HarvestableType.HIDE_HIGHLAND,
                HarvestableType.HIDE_CRITTER,
                HarvestableType.HIDE_GUARDIAN,
            }, value);

                drawView.invalidateHarvestableTypes();
            }
        }




        public bool devModeBind
        {
            get
            {
                return Properties.Settings.Default.devModeSetting;
            }
            set
            {
                Properties.Settings.Default.devModeSetting = value;
        
                Properties.Settings.Default.Save();

                drawView.invalidateDevMode();
            }
        }

        public bool spiderBind
        {
            get
            {
                return Properties.Settings.Default.spiderSetting;
            }
            set
            {
                Properties.Settings.Default.spiderSetting = value;
                RadarSettings.updateMistBosses("spider", value);
                Properties.Settings.Default.Save();

                drawView.invalidateMistBosses();
            }
        }


        public bool veilWeaverBind
        {
            get
            {
                return Properties.Settings.Default.weilWeaverSetting;
            }
            set
            {
                Properties.Settings.Default.weilWeaverSetting = value;
                RadarSettings.updateMistBosses("veilweaver", value);
                Properties.Settings.Default.Save();

                drawView.invalidateMistBosses();
            }
        }

        public bool fairyDragonBind
        {
            get
            {
                return Properties.Settings.Default.fairyDragonSetting;
            }
            set
            {
                Properties.Settings.Default.fairyDragonSetting = value;
                RadarSettings.updateMistBosses("fairydragon", value);
                Properties.Settings.Default.Save();

                drawView.invalidateMistBosses();
            }
        }



        public bool showExpBind
        {
            get
            {
                return Properties.Settings.Default.showExpSetting;
            }
            set
            {
                Properties.Settings.Default.showExpSetting = value;
                Properties.Settings.Default.Save();

                drawView.invalidateMobExp();
            }
        }


        public bool griffinBind
        {
            get
            {
                return Properties.Settings.Default.griffinSetting;
            }
            set
            {
                Properties.Settings.Default.griffinSetting = value;
                RadarSettings.updateMistBosses("griffin", value);
                Properties.Settings.Default.Save();

                drawView.invalidateMistBosses();
            }
        }


        public bool harvestingT2Bind
        {
            get
            {
                return Properties.Settings.Default.harvestingT2Setting;
            }
            set
            {
                Properties.Settings.Default.harvestingT2Setting = value;
                RadarSettings.updateHarvestingTier(2, value);
                Properties.Settings.Default.Save();
                drawView.invalidateHarvestableTiers();
            }
        }

        public bool harvestingT3Bind
        {
            get
            {
                return Properties.Settings.Default.harvestingT3Setting;
            }
            set
            {
                Properties.Settings.Default.harvestingT3Setting = value;
                RadarSettings.updateHarvestingTier(3, value);
                Properties.Settings.Default.Save();
                drawView.invalidateHarvestableTiers();
            }
        }

        public bool harvestingT4Bind
        {
            get
            {
                return Properties.Settings.Default.harvestingT4Setting;
            }
            set
            {
                Properties.Settings.Default.harvestingT4Setting = value;
                RadarSettings.updateHarvestingTier(4, value);
                Properties.Settings.Default.Save();
                drawView.invalidateHarvestableTiers();
            }
        }


        public bool harvestingT5Bind
        {
            get
            {
                return Properties.Settings.Default.harvestingT5Setting;
            }
            set
            {
                Properties.Settings.Default.harvestingT5Setting = value;
                RadarSettings.updateHarvestingTier(5, value);
                Properties.Settings.Default.Save();
                drawView.invalidateHarvestableTiers();
            }
        }

        public bool harvestingT6Bind
        {
            get
            {
                return Properties.Settings.Default.harvestingT6Setting;
            }
            set
            {
                Properties.Settings.Default.harvestingT6Setting = value;
                RadarSettings.updateHarvestingTier(6, value);
                Properties.Settings.Default.Save();
                drawView.invalidateHarvestableTiers();
            }
        }

        public bool harvestingT7Bind
        {
            get
            {
                return Properties.Settings.Default.harvestingT7Setting;
            }
            set
            {
                Properties.Settings.Default.harvestingT7Setting = value;
                RadarSettings.updateHarvestingTier(7, value);
                Properties.Settings.Default.Save();
                drawView.invalidateHarvestableTiers();
            }
        }

        public bool harvestingT8Bind
        {
            get
            {
                return Properties.Settings.Default.harvestingT8Setting;
            }
            set
            {
                Properties.Settings.Default.harvestingT8Setting = value;
                RadarSettings.updateHarvestingTier(8, value);
                Properties.Settings.Default.Save();
                drawView.invalidateHarvestableTiers();
            }
        }

        public bool harvestingE0Bind
        {
            get
            {
                return Properties.Settings.Default.harvestingE0Setting;
            }
            set
            {
                Properties.Settings.Default.harvestingE0Setting = value;

                Properties.Settings.Default.Save();
                RadarSettings.updateHarvestingEnchant(0, value);

                drawView.invalidateHarvestableEnchants();
            }
        }

        public bool harvestingE1Bind
        {
            get
            {
                return Properties.Settings.Default.harvestingE1Setting;
            }
            set
            {
                Properties.Settings.Default.harvestingE1Setting = value;

                Properties.Settings.Default.Save();

                drawView.invalidateHarvestableEnchants();
                RadarSettings.updateHarvestingEnchant(1, value);
            }
        }

        public bool harvestingE2Bind
        {
            get
            {
                return Properties.Settings.Default.harvestingE2Setting;
            }
            set
            {
                Properties.Settings.Default.harvestingE2Setting = value;
                RadarSettings.updateHarvestingEnchant(2, value);
                Properties.Settings.Default.Save();

                drawView.invalidateHarvestableEnchants();
            }
        }

        public bool harvestingE3Bind
        {
            get
            {
                return Properties.Settings.Default.harvestingE3Setting;
            }
            set
            {
                Properties.Settings.Default.harvestingE3Setting = value;
                RadarSettings.updateHarvestingEnchant(3, value);
                Properties.Settings.Default.Save();

                drawView.invalidateHarvestableEnchants();
            }
        }

        public bool harvestingFiberBind
        {
            get
            {
                return Properties.Settings.Default.harvestingFiberSetting;
            }
            set
            {
                Properties.Settings.Default.harvestingFiberSetting = value;

                RadarSettings.updateHarvestableType(new List<HarvestableType>{
                HarvestableType.FIBER,
                HarvestableType.FIBER_CRITTER,
                HarvestableType.FIBER_GUARDIAN_DEAD,
                HarvestableType.FIBER_GUARDIAN_RED
                 }, value);
                Properties.Settings.Default.Save();

                drawView.invalidateHarvestableTypes();
            }
        }

        public bool harvestingOreBind
        {
            get
            {
                return Properties.Settings.Default.harvestingOreSetting;
            }
            set
            {
                Properties.Settings.Default.harvestingOreSetting = value;
                Properties.Settings.Default.Save();

                RadarSettings.updateHarvestableType(new List<HarvestableType>{
                HarvestableType.ORE,
                HarvestableType.ORE_CRITTER_DEAD,
                HarvestableType.ORE_CRITTER_GREEN,
                HarvestableType.ORE_CRITTER_RED,
                HarvestableType.ORE_GUARDIAN_RED
            }, value);

                drawView.invalidateHarvestableTypes();
            }
        }



        public int sizeHarvesting
        {
            get
            {
                return Properties.Settings.Default.sizeHarvestingSetting;
            }
            set
            {
                Properties.Settings.Default.sizeHarvestingSetting = value;
                Properties.Settings.Default.Save();
                drawView.invalidateHarvestingIconsSize();
            }

        }
        public bool harvestingRockBind
        {
            get
            {
                return Properties.Settings.Default.harvestingRockSetting;
            }
            set
            {
                Properties.Settings.Default.harvestingRockSetting = value;

                RadarSettings.updateHarvestableType(new List<HarvestableType>{
                HarvestableType.ROCK,
                HarvestableType.ROCK_CRITTER_DEAD,
                HarvestableType.ROCK_CRITTER_GREEN,
                HarvestableType.ROCK_CRITTER_RED,
                HarvestableType.ROCK_GUARDIAN_RED
            }, value);
                Properties.Settings.Default.Save();


                drawView.invalidateHarvestableTypes();
            }
        }





        public bool harvestingWoodBind
        {
            get
            {
                return Properties.Settings.Default.harvestingWoodSetting;
            }
            set
            {
                Properties.Settings.Default.harvestingWoodSetting = value;

                RadarSettings.updateHarvestableType(new List<HarvestableType>{
                HarvestableType.WOOD,
                HarvestableType.WOOD_CRITTER_DEAD,
                HarvestableType.WOOD_CRITTER_GREEN,
                HarvestableType.WOOD_CRITTER_RED,
                HarvestableType.WOOD_GIANTTREE,
                HarvestableType.WOOD_GUARDIAN_RED
            }, value);
                Properties.Settings.Default.Save();

                drawView.invalidateHarvestableTypes();
            }
        }


        public bool harvestingSizeBind
        {
            get
            {
                return Properties.Settings.Default.harvestingSizeSetting;
            }
            set
            {
                Properties.Settings.Default.harvestingSizeSetting = value;

                Properties.Settings.Default.Save();

                drawView.invalidateHarvestableSize();
            }



        }




        public bool mobE0Bind
        {
            get
            {
                return Properties.Settings.Default.mobE0Setting;
            }
            set
            {



                Properties.Settings.Default.mobE0Setting = value;



                Properties.Settings.Default.Save();
                RadarSettings.updateMobEnchants(0, Properties.Settings.Default.mobE0Setting);
                drawView.invalidateMobEnchants();
            }

        }




        public bool mobE1Bind
        {
            get
            {
                return Properties.Settings.Default.mobE1Setting;
            }
            set
            {



                Properties.Settings.Default.mobE1Setting = value;
                Properties.Settings.Default.Save();
                RadarSettings.updateMobEnchants(1, Properties.Settings.Default.mobE1Setting);

                drawView.invalidateMobEnchants();
            }

        }



        public bool mobE2Bind
        {
            get
            {
                return Properties.Settings.Default.mobE2Setting;
            }
            set
            {



                Properties.Settings.Default.mobE2Setting = value;

                Properties.Settings.Default.Save();
                RadarSettings.updateMobEnchants(2, Properties.Settings.Default.mobE2Setting);

                drawView.invalidateMobEnchants();
            }

        }



        public bool mobE3Bind
        {
            get
            {
                return Properties.Settings.Default.mobE3Setting;
            }
            set
            {



                Properties.Settings.Default.mobE3Setting = value;

                RadarSettings.updateMobEnchants(3, Properties.Settings.Default.mobE3Setting);
                Properties.Settings.Default.Save();
                drawView.invalidateMobEnchants();

            }

        }

        public bool mobE4Bind
        {
            get
            {
                return Properties.Settings.Default.mobE4Setting;
            }
            set
            {
                Properties.Settings.Default.mobE4Setting = value;
                RadarSettings.updateMobEnchants(4, Properties.Settings.Default.mobE4Setting);
                drawView.invalidateMobEnchants();
                Properties.Settings.Default.Save();
            }

        }





        public bool mobT1Bind
        {
            get
            {
                return Properties.Settings.Default.mobT1Setting;
            }
            set
            {
                Properties.Settings.Default.mobT1Setting = value;
                RadarSettings.updateMobTiers(1, Properties.Settings.Default.mobT1Setting);
                Properties.Settings.Default.Save();
                drawView.invalidateMobTiers();

    
            }

        }


        public bool mobT2Bind
        {
            get
            {
                return Properties.Settings.Default.mobT2Setting;
            }
            set
            {
                Properties.Settings.Default.mobT2Setting = value;
                RadarSettings.updateMobTiers(2, Properties.Settings.Default.mobT2Setting);
                Properties.Settings.Default.Save();
                drawView.invalidateMobTiers();

        
            }

        }


        public bool mobT3Bind
        {
            get
            {
                return Properties.Settings.Default.mobT3Setting;
            }
            set
            {
                Properties.Settings.Default.mobT3Setting = value;
                RadarSettings.updateMobTiers(3, Properties.Settings.Default.mobT3Setting);
                Properties.Settings.Default.Save();
                drawView.invalidateMobTiers();

            }

        }




        public bool mobT4Bind
        {
            get
            {
                return Properties.Settings.Default.mobT4Setting;
            }
            set
            {
                Properties.Settings.Default.mobT4Setting = value;
                RadarSettings.updateMobTiers(4, Properties.Settings.Default.mobT4Setting);
                Properties.Settings.Default.Save();
                drawView.invalidateMobTiers();
            }

        }



        public bool mobT5Bind
        {
            get
            {
                return Properties.Settings.Default.mobT5Setting;
            }
            set
            {
                Properties.Settings.Default.mobT5Setting = value;
                RadarSettings.updateMobTiers(5, Properties.Settings.Default.mobT5Setting);
                Properties.Settings.Default.Save();
                drawView.invalidateMobTiers();
            }

        }





        public bool mobT6Bind
        {
            get
            {
                return Properties.Settings.Default.mobT6Setting;
            }
            set
            {
                Properties.Settings.Default.mobT6Setting = value;
                RadarSettings.updateMobTiers(6, Properties.Settings.Default.mobT6Setting);
                Properties.Settings.Default.Save();
                drawView.invalidateMobTiers();
            }

        }


        public bool mobT7Bind
        {
            get
            {
                return Properties.Settings.Default.mobT7Setting;
            }
            set
            {
                Properties.Settings.Default.mobT7Setting = value;
                RadarSettings.updateMobTiers(7, Properties.Settings.Default.mobT7Setting);
                Properties.Settings.Default.Save();
                drawView.invalidateMobTiers();
            }

        }


        public bool mobT8Bind
        {
            get
            {
                return Properties.Settings.Default.mobT8Setting;
            }
            set
            {
                Properties.Settings.Default.mobT8Setting = value;
                RadarSettings.updateMobTiers(8, Properties.Settings.Default.mobT8Setting);
                Properties.Settings.Default.Save();
                drawView.invalidateMobTiers();
            }

        }


        public bool harvestableMobBind
        {
            get
            {
                return Properties.Settings.Default.mobHarvestableSetting;
            }
            set
            {
                Properties.Settings.Default.mobHarvestableSetting = value;
                RadarSettings.updateMobTypes(0, Properties.Settings.Default.mobHarvestableSetting);
                Properties.Settings.Default.Save();
                drawView.invalidateMobTypes();
            }

        }




        public bool skinnableMobBind
        {
            get
            {
                return Properties.Settings.Default.mobSkinnableSetting;
            }
            set
            {
                Properties.Settings.Default.mobSkinnableSetting = value;
                RadarSettings.updateMobTypes(1, Properties.Settings.Default.mobSkinnableSetting);
                Properties.Settings.Default.Save();
                drawView.invalidateMobTypes();
            }

        }

        public bool allMobBind
        {
            get
            {
                return Properties.Settings.Default.mobOtherSetting;
            }
            set
            {
                Properties.Settings.Default.mobOtherSetting = value;
                RadarSettings.updateMobTypes(2, Properties.Settings.Default.mobOtherSetting);
                Properties.Settings.Default.Save();
                drawView.invalidateMobTypes();
      


            }
        }


        public bool otherBossesBind
        {
            get
            {
                return Properties.Settings.Default.otherBossesSetting;
            }
            set
            {
                Properties.Settings.Default.otherBossesSetting = value;
                Properties.Settings.Default.Save();
                drawView.invalidateOtherBosses();
            }
        }


        public bool avaloneDronesBind
        {
            get
            {
                return Properties.Settings.Default.avalonDronesSetting;
            }
            set
            {
                Properties.Settings.Default.avalonDronesSetting = value;
                Properties.Settings.Default.Save();

                drawView.invalidateDrones();
            }
        }





        public RawViewModel(DrawView drawView)
        {

            this.drawView = drawView;




            /*
            RadarSettings.updateHarvestableType(new List<HarvestableType>{
                HarvestableType.HIDE,
                HarvestableType.HIDE_CRITTER,
                HarvestableType.HIDE_FOREST,
                HarvestableType.HIDE_GUARDIAN,
                HarvestableType.HIDE_HIGHLAND,
                HarvestableType.HIDE_MOUNTAIN,
                HarvestableType.HIDE_STEPPE,
                HarvestableType.HIDE_SWAMP
            }, (bool)this.harvestingRock);


            */
            




        }
    }
}
