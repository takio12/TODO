using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace TODO
{
    public class Command : ICommand
    {
        #region ICommand
        public bool CanExecute(Object parameter) { return true; }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            action();
        }
        #endregion

        private Action action;
        public Command(Action action)
        {
            this.action = action;
        }
    }
}
