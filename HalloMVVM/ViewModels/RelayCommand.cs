using System;
using System.Windows.Input;

namespace HalloMVVM.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Action _executeHander;
        private readonly Func<bool> _canExecuteHandler;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action execute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute), "Execute must not be null!");
            _executeHander = execute;

            //_executeHander = execute ?? throw new ArgumentNullException(nameof(execute), "Execute must not be null!");
        }
        public RelayCommand(Action execute, Func<bool> canExecute) 
            : this(execute)
        {
            _canExecuteHandler = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteHandler == null)
                return true;

            return _canExecuteHandler();
        }

        public void Execute(object parameter)
        {
            _executeHander();
        }
    }

    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _executeHander;
        private readonly Func<T, bool> _canExecuteHandler;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<T> execute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute), "Execute must not be null!");
            _executeHander = execute;

            //_executeHander = execute ?? throw new ArgumentNullException(nameof(execute), "Execute must not be null!");
        }
        public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
            : this(execute)
        {
            _canExecuteHandler = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteHandler == null)
                return true;

            return _canExecuteHandler((T)parameter);
        }

        public void Execute(object parameter)
        {
            _executeHander((T)parameter);
        }
    }
}
