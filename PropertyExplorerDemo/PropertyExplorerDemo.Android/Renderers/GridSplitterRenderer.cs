using Android.Content;
using Android.Views;

using PropertyExplorerDemo.Droid.Renderers;
using PropertyExplorerDemo.Controls;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GridSplitter), typeof(GridSplitterRenderer))]

namespace PropertyExplorerDemo.Droid.Renderers
{
    public class GridSplitterRenderer : VisualElementRenderer<GridSplitter>
    {
        private Point _lastPoint;

        public GridSplitterRenderer(Context context) : base(context)
        {
        }

        public override bool OnTouchEvent(Android.Views.MotionEvent e)
        {
            switch (e.Action)
            {
                case (int)MotionEventActions.Down:
                    {
                        _lastPoint = new Point(e.RawX, e.RawY);
                        break;
                    }

                case MotionEventActions.Move:
                    {
                        Element.UpdateGrid(Context.FromPixels(e.RawX - _lastPoint.X), Context.FromPixels(e.RawY - _lastPoint.Y));
                        _lastPoint = new Point(e.RawX, e.RawY);
                        break;
                    }
            }

            return true;
        }
    }
}