using System.Collections.Generic;
using System.ComponentModel;

using Xamarin.Forms.Internals;

namespace PropertyExplorerDemo.Helpers
{
    public static class LinqExtensions
    {
        /// <summary>
        /// Converts to observable collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The col.</param>
        public static NotifyObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source) where T : INotifyPropertyChanged
        {
            var list = new NotifyObservableCollection<T>();
            source.ForEach(p => list.Add(p));  // make sure each item raised property changed
            return list;
        }

    }
}
