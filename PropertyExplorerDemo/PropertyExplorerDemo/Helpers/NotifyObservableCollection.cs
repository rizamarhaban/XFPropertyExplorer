using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace PropertyExplorerDemo
{
    public class NotifyObservableCollection<T> : ObservableCollection<T> where T : INotifyPropertyChanged
    {
        public event EventHandler<PropertyChangedEventArgs> ItemPropertyUpdated;

        private void Handle(object sender, PropertyChangedEventArgs args)
        {
            //OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset, null));
            ItemPropertyUpdated?.Invoke(this, new PropertyChangedEventArgs(args.PropertyName));
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (object t in e.NewItems)
                {
                    ((T)t).PropertyChanged += Handle;
                }
            }
            if (e.OldItems != null)
            {
                foreach (object t in e.OldItems)
                {
                    ((T)t).PropertyChanged -= Handle;
                }
            }

            base.OnCollectionChanged(e);
        }
    }
}