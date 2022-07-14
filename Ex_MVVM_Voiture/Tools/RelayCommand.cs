using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_MVVM_Voiture.Tools
{
    public class RelayCommand : IRelayCommand
    {
        // Event 

        public event EventHandler? CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }


        private readonly Func<bool> _CanExecute;
        private readonly Action _Execute;
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            if (execute is null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
            _Execute = execute;
            _CanExecute = canExecute;
        }

        public void Execute(object? parameter)
        {
            _Execute();
        }

        public bool CanExecute(object? parameter)
        {
            // return _CanExecute?.Invoke() ?? true;
            return _CanExecute is null ? true : _CanExecute();
        }
    }
}
