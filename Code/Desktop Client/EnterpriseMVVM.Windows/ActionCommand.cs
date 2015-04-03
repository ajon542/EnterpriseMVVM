using System.Data;

namespace EnterpriseMVVM.Windows
{
    using System;
    using System.Windows.Input;

    public class ActionCommand : ICommand
    {
        private readonly Action<Object> action;
        private readonly Predicate<Object> predicate;

        public event EventHandler CanExecuteChanged
        {
            // The following link explains why this can be a bad approach
            // if you don't know what you are doing. The framework will
            // automatically call this CanExecuteChanged to handle the disabling
            // and enabling of buttons for you.
            // https://www.youtube.com/watch?v=ysWK4e2Mtco
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public ActionCommand(Action<Object> action)
            : this(action, null)
        {
        }

        public ActionCommand(Action<Object> action, Predicate<Object> predicate)
        {
            if (action == null)
            {
                throw new ArgumentNullException();
            }

            this.action = action;
            this.predicate = predicate;
        }

        public void Execute()
        {
            Execute(null);
        }

        public bool CanExecute(Object parameter)
        {
            if (predicate == null)
            {
                return true;
            }

            return predicate(parameter);
        }

        public void Execute(Object parameter)
        {
            action(parameter);
        }
    }
}
