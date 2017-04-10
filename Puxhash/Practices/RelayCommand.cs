using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Puxhash.Practices
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        private Action methodToExecute;
        private Func<bool> canExecuteEvaluator;
        public RelayCommand(Action methodToExecute, Func<bool> canExecuteEvaluator)
        {
            this.methodToExecute = methodToExecute;
            this.canExecuteEvaluator = canExecuteEvaluator;
        }
        public RelayCommand(Action methodToExecute)
            : this(methodToExecute, null)
        {
        }
        public bool CanExecute(object parameter)
        {
            return canExecuteEvaluator == null ? true : canExecuteEvaluator.Invoke();
            //if (canExecuteEvaluator == null)
            //{
            //    return true;
            //}
            //else
            //{
            //    bool result = canExecuteEvaluator.Invoke();
            //    return result;
            //}
        }
        public void Execute(object parameter)
        {
            methodToExecute.Invoke();
        }
    }
}
