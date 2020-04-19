using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Wpf.UI.Annotations;

namespace BookKeeper.Wpf.UI.Infrastructure
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool OnPropertyChanged<TProperty>(ref TProperty property, TProperty value,
            [CallerMemberName] string propertyName = null)
        {
            if (Equals(property, value))
                return false;

            property = value;
            OnPropertyChanged();
            return true;
        }
    }
}
