using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TemplateSolution.Common
{
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //the [CallerMemberName] attribute is not required, but it will allow you to write: OnPropertyChanged(); instead of OnPropertyChanged("SomeProperty");
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Allows to use { SetProperty(ref _firstName, value); } 
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;
            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
    }
}
