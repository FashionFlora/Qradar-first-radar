using LogicLyric.Core;
using LogicLyric.MVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LogicLyric.MVM.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {




        DrawView drawView;

        public bool drawBigCircleBind
        {
            get
            {
                return Properties.Settings.Default.drawBigCircleSetting;
            }
            set
            {
                Properties.Settings.Default.drawBigCircleSetting = value;

                Properties.Settings.Default.Save();
                drawView.invalidateCircles();


            }
        }
        public bool dragAndDropBind
        {
            get
            {
                return Properties.Settings.Default.dragAndDropSetting;
            }
            set
            {
                Properties.Settings.Default.dragAndDropSetting = value;

                Properties.Settings.Default.Save();


            }
        }



        public bool drawMiddleCircleBind
        {
            get
            {
                return Properties.Settings.Default.drawMiddleCircleSetting;
            }
            set
            {
                Properties.Settings.Default.drawMiddleCircleSetting = value;
                Properties.Settings.Default.Save();
                drawView.invalidateCircles();
            }
        }
        public bool drawSmallerCircleBind
        {
            get
            {
                return Properties.Settings.Default.drawSmallerCircleSetting;
            }
            set
            {
                Properties.Settings.Default.drawSmallerCircleSetting = value;
                Properties.Settings.Default.Save();
                drawView.invalidateCircles();
            }
        }

        public bool drawBigSquareBind
        {
            get
            {
                return Properties.Settings.Default.drawBigSquareSetting;
            }
            set
            {
                Properties.Settings.Default.drawBigSquareSetting = value;
                Properties.Settings.Default.Save();
                drawView.invalidateCircles();
            }
        }
        
        public bool drawMiddleSquareBind
        {
            get
            {
                return Properties.Settings.Default.drawMiddleSquareSetting;
            }
            set
            {
                Properties.Settings.Default.drawMiddleSquareSetting = value;
                Properties.Settings.Default.Save();
                drawView.invalidateCircles();
            }
        }


       
        public bool radarColorsBind
        {
            get
            {
                return Properties.Settings.Default.radarColorsSetting;
            }
            set
            {
                Properties.Settings.Default.radarColorsSetting = value;
                Properties.Settings.Default.Save();
                drawView.invalidateCircles();
            }
        }
        public bool drawSmallerSquareBind
        {
            get
            {
                return Properties.Settings.Default.drawSmallerSquareSetting;
            }
            set
            {
                Properties.Settings.Default.drawSmallerSquareSetting = value;
                Properties.Settings.Default.Save();
                drawView.invalidateCircles();
            }
        }



        public int translationWindowXBind
        {
            get
            {
                return Properties.Settings.Default.translationWindowXSetting;
            }
            set
            {
                Properties.Settings.Default.translationWindowXSetting = value;


                this.drawView.Left = Properties.Settings.Default.translationWindowXSetting;

                drawView.updateSize();


                Properties.Settings.Default.Save();
            }

        }


        public int translationWindowYBind
        {
            get
            {
                return Properties.Settings.Default.translationWindowYSetting;
            }
            set
            {
                Properties.Settings.Default.translationWindowYSetting = value;


                this.drawView.Top = Properties.Settings.Default.translationWindowYSetting;

                drawView.updateSize();


                Properties.Settings.Default.Save();
            }

        }



  


        public int windowScaleBind
        {
            get
            {
                return Properties.Settings.Default.windowScaleSetting;
            }
            set
            {
                Properties.Settings.Default.windowScaleSetting = value;


                drawView.updateSizeMain();


                Properties.Settings.Default.Save();
            }

        }



        public int windowSizeBind
        {
            get
            {
                return Properties.Settings.Default.windowSizeSetting;
            }
            set
            {
                Properties.Settings.Default.windowSizeSetting = value;


                this.drawView.Height = value;
                this.drawView.Width = value;

                drawView.updateSizeMain();
                drawView.invalidateCircles();


                Properties.Settings.Default.Save();
            }

        }



        public ICommand ResetDrawingsCommand { get;  set; }

        public SettingsViewModel(DrawView drawView)
        {


            this.drawView = drawView;
            ResetDrawingsCommand = new ViewModelCommand(ButtonClicked);
        }

        private void ButtonClicked(object obj)
        {
            drawView.clearAll();

        }
    }
}
