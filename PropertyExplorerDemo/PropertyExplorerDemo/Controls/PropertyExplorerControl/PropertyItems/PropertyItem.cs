using PropertyExplorerDemo.ViewModels;

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

using Xamarin.Forms;

namespace PropertyExplorerDemo.Controls
{
    public class PropertyItem : ViewModelBase
    {
        private readonly string _category;
        private readonly string _propertyName;
        private readonly Type _propertyType;
        private object _propertyValue;
        private ICommand _updatedCommand;

        public PropertyItem(PropertyDescriptor prop, object propertyValue)
        {
            _category = prop.Category;
            _propertyName = prop.Name;
            _propertyType = prop.PropertyType;
            _propertyValue = propertyValue;
        }

        public ICommand UpdatedCommand => _updatedCommand
            ?? (_updatedCommand = new Command(() => RaisePropertyChanged(_propertyName)));

        public string PropertyName => _propertyName;

        public string Category => _category;

        public Type PropertyType => _propertyType;

        public object PropertyValue
        {
            get => _propertyValue;
            set => SetProperty(ref _propertyValue, value);
        }
    }
}
