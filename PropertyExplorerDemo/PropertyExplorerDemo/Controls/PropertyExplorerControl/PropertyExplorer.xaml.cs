using PropertyExplorerDemo.Helpers;

using SkiaSharp;
using SkiaSharp.Views.Forms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PropertyExplorerDemo.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertyExplorer : ContentView
    {
        //public event EventHandler

        public static readonly BindableProperty TitleProperty
                = BindableProperty.Create(nameof(Title), typeof(string),
                    typeof(PropertyExplorer), default(string),
                    propertyChanged: TitleChanged);

        public static readonly BindableProperty SourceObjectProperty
                = BindableProperty.Create(nameof(SourceObject),
                    typeof(object), typeof(PropertyExplorer), null,
                    propertyChanged: SourceObjectChanged);

        private readonly NotifyObservableCollection<PropertyGroupItems> asGroups;
        private readonly NotifyObservableCollection<PropertySortingItems> asSorted;

        private static void SourceObjectChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var c = bindable as PropertyExplorer;
            var data = TypeDescriptor.GetProperties(newValue);

            c.lblComponentType.Text = newValue.GetType().Name;

            string[] disabledProperties = { "AnchorX", "AnchorY", "IsClippedToBounds", "CascadeInputTransparent" };

            Dictionary<string, List<PropertyItem>> propDic =
                data.OfType<PropertyDescriptor>()
                .Where(p => p.IsBrowsable && !disabledProperties.Contains(p.Name))
                .GroupBy(cat => cat.Category)
                .ToDictionary(p => p.Key,
                              p => p.Select(q => new PropertyItem(q, q.GetValue(newValue))).ToList());

            propDic.ForEach(group =>
            {
                var groupItem = new PropertyGroupItems { Header = group.Key };
                group.Value.ForEach(p => groupItem.Properties.Add(p));
                c.asGroups.Add(groupItem);
            });

            var sortItem = new PropertySortingItems();
            var list = new List<PropertyItem>();
            propDic.Values.ForEach(p => list.AddRange(p));
            sortItem.Properties = list.OrderBy(p => p.PropertyName).ToObservableCollection();
            c.asSorted.Add(sortItem);

            c.cvList.ItemsSource = c.asGroups;
        }

        public object SourceObject
        {
            get => GetValue(SourceObjectProperty);
            set => SetValue(SourceObjectProperty, value);
        }

        private static void TitleChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var c = bindable as PropertyExplorer;
            c.lblTitle.Text = (string)newValue;
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public PropertyExplorer()
        {
            InitializeComponent();

            pickerArranged.SelectedIndex = 1;
            pickerArranged.SelectedIndexChanged += ArrangedSelectedChanged;
            searchBar.SearchButtonPressed += SearchButtonPressed;
            searchBar.TextChanged += SearchTextChanged;

            asGroups = new NotifyObservableCollection<PropertyGroupItems>();
            asSorted = new NotifyObservableCollection<PropertySortingItems>();

            asGroups.ItemPropertyUpdated += ItemPropertyUpdated;
            asSorted.ItemPropertyUpdated += ItemPropertyUpdated;
        }

        private void ItemPropertyUpdated(object sender, PropertyChangedEventArgs e)
        {
            Debug.WriteLine(e.PropertyName);
        }

        private void ArrangedSelectedChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if (picker.SelectedItem.ToString() == "Sorting")
            {
                cvList.ItemsSource = asSorted;
            }
            else
            {
                cvList.ItemsSource = asGroups;
            }
        }

        private void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchBox = sender as SearchBar;
            if (string.IsNullOrEmpty(searchBox.Text))
                SwitchToNormalList();
        }

        private void SwitchToNormalList()
        {

        }

        private void SearchButtonPressed(object sender, EventArgs e)
        {

        }
    }
}