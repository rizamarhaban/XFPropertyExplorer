using PropertyExplorerDemo.ViewModels;

using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;

using Xamarin.Forms.Shapes;

namespace PropertyExplorerDemo.Controls
{
    internal class PropertyGroupItems : ViewModelBase
    {
        private const string DownArrowHead = @"M30.587915,0L31.995998,1.4199842 15.949964,17.351
                                               0,1.4979873 1.4099131,0.078979151 15.949964,14.53102z";
        private const string UpArrowHead = @"M16.046999,0L31.994998,15.853991 30.585086,17.272997
                                             16.046022,2.8200051 1.4090576,17.351 0,15.931994z";

        private NotifyObservableCollection<PropertyItem> _properties = new();
        private string _header;
        private bool _isExpanded;
        private Geometry _arrowHead;
        private readonly Geometry _downArrow;
        private readonly Geometry _upArrow;

        public PropertyGroupItems()
        {
            _downArrow = new PathGeometryConverter().ConvertFromInvariantString(DownArrowHead) as Geometry;
            _upArrow = new PathGeometryConverter().ConvertFromInvariantString(UpArrowHead) as Geometry;

            _arrowHead = _downArrow; // default arrow on collapsed expander

            _properties.ItemPropertyUpdated += ItemPropertyUpdated;
        }

        private void ItemPropertyUpdated(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(e.PropertyName);
        }

        public string Header
        {
            get => _header;
            set => SetProperty(ref _header, value);
        }

        public NotifyObservableCollection<PropertyItem> Properties
        {
            get { return _properties; }
        }

        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                SetProperty(ref _isExpanded, value);

                if (value)
                    ArrowHead = _upArrow;
                else
                    ArrowHead = _downArrow;
            }
        }

        public Geometry ArrowHead
        {
            get => _arrowHead;
            set => SetProperty(ref _arrowHead, value);
        }

    }
}
