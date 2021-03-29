using System;

using Xamarin.Forms;

namespace PropertyExplorerDemo.Controls
{
    public class PropertyTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Gets or sets the text property.
        /// </summary>
        public DataTemplate TextPropertyTemplate { get; set; }

        /// <summary>
        /// Gets or sets the boolean property.
        /// </summary>
        public DataTemplate BooleanPropertyTemplate { get; set; }

        /// <summary>
        /// Gets or sets the int property.
        /// </summary>
        public DataTemplate NumericPropertyTemplate { get; set; }

        /// <summary>
        /// Gets or sets the color property.
        /// </summary>
        public DataTemplate ColorPropertyTemplate { get; set; }

        /// <summary>
        /// Gets or sets the thickness property template.
        /// </summary>
        public DataTemplate ThicknessPropertyTemplate { get; set; }

        /// <summary>
        /// Gets or sets the date time property template.
        /// </summary>
        public DataTemplate DateTimePropertyTemplate { get; set; }

        /// <summary>
        /// Gets or sets the blank.
        /// </summary>
        public DataTemplate BlankTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is null) return BlankTemplate;

            var prop = item as PropertyItem;

            if (prop.PropertyType == typeof(byte)) return NumericPropertyTemplate;
            if (prop.PropertyType == typeof(int)) return NumericPropertyTemplate;
            if (prop.PropertyType == typeof(float)) return NumericPropertyTemplate;
            if (prop.PropertyType == typeof(double)) return NumericPropertyTemplate;

            if (prop.PropertyType == typeof(char)) return TextPropertyTemplate;
            if (prop.PropertyType == typeof(string)) return TextPropertyTemplate;

            if (prop.PropertyType == typeof(bool)) return BooleanPropertyTemplate;

            if (prop.PropertyType == typeof(Thickness)) return ThicknessPropertyTemplate;
            if (prop.PropertyType == typeof(DateTime)) return DateTimePropertyTemplate;
            if (prop.PropertyType == typeof(Color)) return ColorPropertyTemplate;

            return BlankTemplate;
        }
    }
}
