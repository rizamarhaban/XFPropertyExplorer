using PropertyExplorerDemo.ViewModels;

using System.ComponentModel;

namespace PropertyExplorerDemo.Controls
{
    internal class PropertySortingItems : ViewModelBase
    {
        private NotifyObservableCollection<PropertyItem> _properties = new();

        public PropertySortingItems()
        {
            _properties.ItemPropertyUpdated += ItemPropertyUpdated;
        }

        private void ItemPropertyUpdated(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(e.PropertyName);
        }

        public NotifyObservableCollection<PropertyItem> Properties
        {
            get => _properties;
            set => SetProperty(ref _properties, value);
        }
    }
}
