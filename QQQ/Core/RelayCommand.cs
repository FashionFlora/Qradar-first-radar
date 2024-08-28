using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LogicLyric.Core
{
    class RelayCommand : ICommand
    {

        private Action<object> _execute;
        private Func<object, bool> _canExecute;
        private Action buttonClicked;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }

        }
        public RelayCommand(Action<object> execute, Func<object,bool> canExecute =null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public RelayCommand(Action buttonClicked)
        {
            this.buttonClicked = buttonClicked;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }
        public void Exectue(object parameter)
        {
            _execute(parameter);

        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
