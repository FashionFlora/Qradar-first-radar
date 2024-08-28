
using LogicLyric.MVM.View;
using System;



using System.Windows;
using System.Collections.Generic;
using LogicLyric.Core;
using LogicLyric.Utils;

namespace LogicLyric
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 


    public partial class App : Application
    {

        

        protected void ApplicationStart(object sender, StartupEventArgs ea)
        {

     

           
               


            /*
            
            
           EnableConsole.AllocConsoleNow();


           
            

            
            Load load = new Load();
            MainView mainView = new MainView();
            mainView.ShowInTaskbar = true;
       
            mainView.Show();

            

            */
            

            

            








            

            


           
            LoginView loginView = new LoginView();

            loginView.Show();



            loginView.IsVisibleChanged += (s, e) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {

                    Load load = new Load();
                    MainView mainView = new MainView();
      
                    mainView.Show();
                    loginView.Close();

                }
            };

            

            
            
            
            


            
            
            

           
           

        }
    }
}
