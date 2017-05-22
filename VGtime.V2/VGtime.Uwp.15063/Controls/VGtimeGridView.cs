using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace VGtime.Uwp.Controls
{
    public class VGtimeGridView : GridView
    {
        public static readonly DependencyProperty MaxItemWidthProperty = DependencyProperty.Register(nameof(MaxItemWidth), typeof(double), typeof(VGtimeGridView), new PropertyMetadata(double.PositiveInfinity, OnMaxItemWidthChanged));

        public VGtimeGridView()
        {
            SizeChanged += VGtimeGridView_SizeChanged;
        }

        public double MaxItemWidth
        {
            get
            {
                return (double)GetValue(MaxItemWidthProperty);
            }
            set
            {
                SetValue(MaxItemWidthProperty, value);
            }
        }

        private static void OnMaxItemWidthChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (VGtimeGridView)d;

            obj.UpdateColumn();
        }

        private void UpdateColumn()
        {
            var maxItemWidth = MaxItemWidth;
            if (double.IsPositiveInfinity(maxItemWidth))
            {
                return;
            }
            var itemsWrapGrid = ItemsPanelRoot as ItemsWrapGrid;
            if (itemsWrapGrid != null)
            {
                var width = itemsWrapGrid.ActualWidth;
                var column = Math.Ceiling(width / maxItemWidth);
                itemsWrapGrid.ItemWidth = width / column;
            }
        }

        private void VGtimeGridView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateColumn();
        }
    }
}