using System;
using System.ComponentModel;

using Xamarin.Forms;

namespace PropertyExplorerDemo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private object _source;

        public MainViewModel()
        {
            _source = new Activity();
        }

        public object Source
        {
            get => _source;
            set => SetProperty(ref _source, value);
        }

    }

    public class Activity : ContentView
    {
        public static readonly BindableProperty TestProperty
                = BindableProperty.Create(nameof(Test), typeof(string), typeof(Activity), default(string));

        [Category("Date/Time")]
        [Description("This is example of the description")]
        public string Test
        {
            get => (string)GetValue(TestProperty);
            set => SetValue(TestProperty, value);
        }

        public Activity()
        {
            Margin = new Thickness(12, 23, 34, 45);
        }

        [Category("Date/Time")]
        public DateTime DateTimeProperty { get; set; }

        [Category("Numbers")]
        public int IntegerNumber { get; set; }

        [Browsable(false)]
        public int InternalNumber { get; set; }

        [Category("Numbers")]
        public double DoubleNumber { get; set; }

        [Category("Numbers")]
        public float FloatNumber { get; set; }

        [Category("Numbers")]
        public bool BooleanNumber { get; set; }

        public string Header { get; set; }

        [Category("Appearance")]
        public Color Color { get; set; }

        [Category("Appearance")]
        public Image Image { get; set; }

        [Category("Layout")]
        public Point Position { get; set; }

        [Category("Layout")]
        public Thickness Margin { get; set; }

        [Category("Layout")]
        public Thickness Padding { get; set; }

        [Category("Layout")]
        public Size Size { get; set; }

    }
}
