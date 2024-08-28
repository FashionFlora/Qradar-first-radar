using LogicLyric.MVM.View;
using LogicLyric.MVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLyric.MVM.ViewModel
{
    public class PlayerViewModel : ViewModelBase
    {



        DrawView drawView;

        public bool showPlayerBind
        {
            get
            {
                return Properties.Settings.Default.showPlayerSetting;
            }
            set
            {
          
                Properties.Settings.Default.showPlayerSetting = value;
                Properties.Settings.Default.Save();

       
                drawView.invalidatePlayers();
            }
        }
        public bool showPlayerNicknameBind
        {
            get
            {
                return Properties.Settings.Default.showNicknameSetting;
            }
            set
            {
                Properties.Settings.Default.showNicknameSetting = value;
                Properties.Settings.Default.Save();
                drawView.invalidatePlayerNicknames();


            }
        }

        public bool showPlayerHealthBind
        {


            get
            {
                return Properties.Settings.Default.showPlayerHealthSetting;
            }
            set
            {
                Properties.Settings.Default.showPlayerHealthSetting = value;
                Properties.Settings.Default.Save();

                drawView.invalidatePlayersHealths();


      
            }

        }
        public bool showGuildNameBind
        {
            get
            {
                return Properties.Settings.Default.showGuildSetting;
            }
            set
            {
                Properties.Settings.Default.showGuildSetting = value;

                Properties.Settings.Default.Save();

                drawView.invalidateGuild();
            }
        }


        public bool showPlayerItemsBind
        {
            get
            {
                return Properties.Settings.Default.showPlayerItemsSetting;
            }
            set
            {
                Properties.Settings.Default.showPlayerItemsSetting = value;

                Properties.Settings.Default.Save();

                drawView.invalidatePlayersItems();
            }
        }


        public bool showPlayerItemsDevModeBind
        {
            get
            {
                return Properties.Settings.Default.showPlayerItemsDevModeSetting;
            }
            set
            {
                Properties.Settings.Default.showPlayerItemsDevModeSetting = value;

                Properties.Settings.Default.Save();

            }
        }


        public bool showMountedBind
        {
            get
            {
                return Properties.Settings.Default.mountedSetting;
            }
            set
            {
                Properties.Settings.Default.mountedSetting = value;

                Properties.Settings.Default.Save();

                drawView.invalidatePlayerMounts(value);
            }
        }


        
        public int  itemsSizeBind
        {
            get
            {
                return Properties.Settings.Default.itemsSizeSetting;
            }
            set
            {
                Properties.Settings.Default.itemsSizeSetting = value;

        


                Properties.Settings.Default.Save();

            }

        }


        public int itemsHeightBind
        {
            get
            {
                return Properties.Settings.Default.itemsHeightSetting;
            }
            set
            {
                Properties.Settings.Default.itemsHeightSetting = value;

                drawView.invalidatePlayersItemsHeight();


                Properties.Settings.Default.Save();

            }

        }



        public int itemsWidthBind
        {
            get
            {
                return Properties.Settings.Default.itemsWidthSetting;
            }
            set
            {
                Properties.Settings.Default.itemsWidthSetting = value;

                drawView.invalidatePlayersItemsWidth();


                Properties.Settings.Default.Save();

            }

        }





        public bool soundOnNewPlayerBind
        {

            get
            {
                return Properties.Settings.Default.soundOnNewPlayerSetting;
            }
            set
            {
                Properties.Settings.Default.soundOnNewPlayerSetting = value;


                Properties.Settings.Default.Save();

            }
        }
        public bool showDistanceBind
        {
            get
            {
                return Properties.Settings.Default.showPlayerDistanceSetting;
            }
            set
            {

            
                Properties.Settings.Default.showPlayerDistanceSetting = value;
                Properties.Settings.Default.Save();
                drawView.invalidatePlayerDistance();
            }
        }




        public int translationXItemsBind
        {
            get
            {
                return Properties.Settings.Default.translationItemsXSetting;
            }
            set
            {
                Properties.Settings.Default.translationItemsXSetting = value;

                drawView.updateItemsTranslationX();


                Properties.Settings.Default.Save();
            }

        }

        public int translationYItemsBind
        {
            get
            {
                return Properties.Settings.Default.translationItemsYSetting;
            }
            set
            {
                Properties.Settings.Default.translationItemsYSetting = value;

                drawView.updateItemsTranslationY();
                Properties.Settings.Default.Save();
            }

        }





        public PlayerViewModel(DrawView drawView )
        {
              this.drawView = drawView;

        }
    }
}
