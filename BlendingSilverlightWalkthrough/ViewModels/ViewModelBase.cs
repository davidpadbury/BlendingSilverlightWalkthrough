using System;
using System.ComponentModel;
using System.Linq.Expressions;

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
    }
}