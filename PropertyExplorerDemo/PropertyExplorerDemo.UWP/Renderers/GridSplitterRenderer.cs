using PropertyExplorerDemo.Controls;
using PropertyExplorerDemo.UWP.Renderers;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

using Xamarin.Forms.Platform.UWP;

using WF = Windows.Foundation;

[assembly: ExportRenderer(typeof(GridSplitter), typeof(GridSplitterRenderer))]

namespace PropertyExplorerDemo.UWP.Renderers
{
    public class GridSplitterRenderer : ViewRenderer<GridSplitter, SplitView>
    {
        private WF.Point? _lastPt;

        protected override void OnElementChanged(ElementChangedEventArgs<GridSplitter> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                this.PointerPressed -= MouseLeftButtonDown;
                this.PointerReleased -= MouseLeftButtonUp;
                this.PointerMoved -= MouseMove;
            }

            if (e.NewElement != null)
            {
                this.PointerPressed += MouseLeftButtonDown;
                this.PointerReleased += MouseLeftButtonUp;
                this.PointerMoved += MouseMove;
            }
        }

        private void MouseMove(object sender, PointerRoutedEventArgs e)
        {
            if (_lastPt != null)
            {
                WF.Point pt = e.GetCurrentPoint(null).Position;
                Element.UpdateGrid(pt.X - _lastPt.Value.X, pt.Y - _lastPt.Value.Y);
                _lastPt = pt;
            }
        }

        private void MouseLeftButtonUp(object sender, PointerRoutedEventArgs e)
        {
            _lastPt = null;
        }

        private void MouseLeftButtonDown(object sender, PointerRoutedEventArgs e)
        {
            _lastPt = e.GetCurrentPoint(null).Position;
            CapturePointer(e.Pointer);
        }

    }
}
