using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;

namespace WpfNavigationExample.Framework
{
    public class ObservableCommand : RelayCommand
    {
        ///<summary>
        /// The event fired when a command is executed;
        ///</summary>
        public event EventHandler CommandExecuted;

        public ObservableCommand(Action execute) : base(execute)
        {
            
        }
        
        public ObservableCommand(Action execute, Func<bool> canExecute) : base(execute, canExecute)
        {
            
        }

        public override void Execute(object parameter)
        {
            base.Execute(parameter);
            OnExecuteCommand();
        }

        private void OnExecuteCommand()
        {
            if (CommandExecuted != null)
            {
                CommandExecuted(this, EventArgs.Empty);
            }
        }
    }
}
