using LogicLyric.MVM.Model;
using LogicLyric.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Input;
using System.Runtime.InteropServices;

namespace LogicLyric.MVM.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {



        //Fields
        private string _username;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        private IUserRepository userRepository;

        //Properties
        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }



        public bool saveBind
        {
            get
            {
                

                return Properties.Settings.Default.saveSetting;
            }

            set
            {

                OnPropertyChanged(nameof(saveBind));
                Properties.Settings.Default.saveSetting = value;
                Properties.Settings.Default.Save();

            }
        }


        public SecureString Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }

            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool IsViewVisible
        {
            get
            {
                return _isViewVisible;
            }

            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        //-> Commands
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        //Constructor
        public LoginViewModel()
        {
            userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("", ""));
            


           

            if (Properties.Settings.Default.saveSetting)
            {



                SecureString securePassword = new SecureString();
                foreach (char c in Properties.Settings.Default.passSetting)
                {
                    securePassword.AppendChar(c);
                }


                Username = Properties.Settings.Default.userSetting;
                Password = securePassword;
                _password = securePassword;

            }
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData = true;
        
    


            if (Properties.Settings.Default.saveSetting)
            {
                Properties.Settings.Default.userSetting = Username;
                string password = new System.Net.NetworkCredential(string.Empty, Password).Password;
                Properties.Settings.Default.passSetting = password;
                Properties.Settings.Default.Save();



            }


            return validData;
        }

  
        private void ExecuteLoginCommand(object obj)
        {



   
        
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(Username), null);
                IsViewVisible = false;
        


            


        }

        private void ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }

    }
}
