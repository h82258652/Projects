using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;
using SoftwareKobo.Extensions;

namespace VGtime.Uwp.Controls
{
    [TemplatePart(Name = StaticHeaderTemplateName, Type = typeof(PivotHeaderPanel))]
    [TemplatePart(Name = HeaderTemplateName, Type = typeof(PivotHeaderPanel))]
    [TemplatePart(Name = SelectedHeaderIndicatorTemplateName, Type = typeof(Rectangle))]
    public sealed class VGtimePivot : Pivot
    {
        private const string HeaderTemplateName = "Header";

        private const string SelectedHeaderIndicatorTemplateName = "PART_SelectedHeaderIndicator";

        private const string StaticHeaderTemplateName = "StaticHeader";

        private PivotHeaderPanel _header;

        private Visual _selectedHeaderIndicatorVisual;

        private PivotHeaderPanel _staticHeader;

        public VGtimePivot()
        {
            DefaultStyleKey = typeof(VGtimePivot);

            SelectionChanged += VGtimePivot_SelectionChanged;
        }

        public event VGtimePivotSelectedHeaderItemClickEventHandler SelectedHeaderItemClick;

        internal void FireSelectedHeaderItemClick(PivotHeaderItem item)
        {
            SelectedHeaderItemClick?.Invoke(this, new VGtimePivotSelectedHeaderItemClickEventArgs(item));
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _staticHeader = (PivotHeaderPanel)GetTemplateChild(StaticHeaderTemplateName);
            _header = (PivotHeaderPanel)GetTemplateChild(HeaderTemplateName);

            var selectedHeaderIndicator = (Rectangle)GetTemplateChild(SelectedHeaderIndicatorTemplateName);
            _selectedHeaderIndicatorVisual = ElementCompositionPreview.GetElementVisual(selectedHeaderIndicator);
            var scale = _selectedHeaderIndicatorVisual.Scale;
            scale.X = 0;
            _selectedHeaderIndicatorVisual.Scale = scale;
        }

        private void VGtimePivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_header != null)
            {
                var selectedIndex = SelectedIndex;
                if (selectedIndex >= 0)
                {
                    var pivotItem = (PivotItem)ContainerFromIndex(selectedIndex);
                    if (pivotItem != null)
                    {
                        var headerChildren = new List<PivotHeaderItem>();
                        headerChildren.AddRange(_staticHeader.Children.OfType<PivotHeaderItem>());
                        headerChildren.AddRange(_header.Children.OfType<PivotHeaderItem>());

                        var pivotHeaderItem = headerChildren.FirstOrDefault(temp => temp == pivotItem.Header || Equals(temp.Content, pivotItem.Header));
                        if (pivotHeaderItem != null)
                        {
                            var offsetX = (float)(Canvas.GetLeft(pivotHeaderItem) + pivotHeaderItem.Padding.Left);
                            var scaleX = (float)(pivotHeaderItem.ActualWidth - pivotHeaderItem.Padding.Left - pivotHeaderItem.Padding.Right);

                            if (_selectedHeaderIndicatorVisual.Scale.X > 0)
                            {
                                var compositor = _selectedHeaderIndicatorVisual.Compositor;

                                var offsetAnimation = compositor.CreateScalarKeyFrameAnimation();
                                offsetAnimation.InsertKeyFrame(1, offsetX, compositor.CreateCubicEasingFunction(EasingMode.EaseInOut));
                                offsetAnimation.Duration = TimeSpan.FromSeconds(0.3);

                                var scaleAnimation = compositor.CreateScalarKeyFrameAnimation();
                                scaleAnimation.InsertKeyFrame(1, scaleX, compositor.CreateCubicEasingFunction(EasingMode.EaseInOut));
                                scaleAnimation.Duration = TimeSpan.FromSeconds(0.3);

                                _selectedHeaderIndicatorVisual.StartAnimation("Offset.X", offsetAnimation);
                                _selectedHeaderIndicatorVisual.StartAnimation("Scale.X", scaleAnimation);
                            }
                            else
                            {
                                var offset = _selectedHeaderIndicatorVisual.Offset;
                                offset.X = offsetX;
                                _selectedHeaderIndicatorVisual.Offset = offset;

                                var scale = _selectedHeaderIndicatorVisual.Scale;
                                scale.X = scaleX;
                                _selectedHeaderIndicatorVisual.Scale = scale;
                            }
                        }
                    }
                }
            }
        }
    }
}