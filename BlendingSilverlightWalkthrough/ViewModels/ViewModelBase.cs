using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Threading;

namespace BlendingSilverlightWalkthrough.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyChanged<TProp>(Expression<Func<TProp>> propertyAccessor)
        {
            var propertyName = propertyAccessor.GetMemberInfo().Name;
            var args = new PropertyChangedEventArgs(propertyName);
            
            OnPropertyChanged(args);
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = PropertyChanged;

            if (handler != null)
                handler(this, e);
        }

        protected virtual void InvokeOnDispatcher(Action action)
        {
            var dispatcher = GetDispatcher();

            if (dispatcher != null)
            {
                if (dispatcher.CheckAccess())
                {
                    action();
                }
                else
                {
                    dispatcher.BeginInvoke(action);
                }
            }
        }

        private Dispatcher GetDispatcher()
        {
            if (Application.Current != null && Application.Current.RootVisual != null)
                return Application.Current.RootVisual.Dispatcher;

            return null;
        }
    }
}