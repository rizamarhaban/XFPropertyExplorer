using Xamarin.Forms;

namespace PropertyExplorerDemo.Controls
{
    public class ArrangedTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Gets or sets the text property.
        /// </summary>
        public DataTemplate SortingTemplate { get; set; }

        /// <summary>
        /// Gets or sets the boolean property.
        /// </summary>
        public DataTemplate CategoryTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is null) return CategoryTemplate;

            if(item is PropertySortingItems) return SortingTemplate;
            
            return CategoryTemplate;

        }
    }
}
