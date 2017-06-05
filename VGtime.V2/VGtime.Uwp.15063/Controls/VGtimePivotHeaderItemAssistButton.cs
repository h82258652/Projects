using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using WinRTXamlToolkit.Controls.Extensions;

namespace VGtime.Uwp.Controls
{
    internal class VGtimePivotHeaderItemAssistButton : Button
    {
        internal static readonly DependencyProperty AttachedPivotHeaderItemProperty = DependencyProperty.Register(nameof(AttachedPivotHeaderItem), typeof(PivotHeaderItem), typeof(VGtimePivotHeaderItemAssistButton), new PropertyMetadata(default(PivotHeaderItem)));

        internal VGtimePivotHeaderItemAssistButton()
        {
            Click += VGtimePivotHeaderItemAssistButton_Click;
        }

        internal PivotHeaderItem AttachedPivotHeaderItem
        {
            get
            {
                return (PivotHeaderItem)GetValue(AttachedPivotHeaderItemProperty);
            }
            set
            {
                SetValue(AttachedPivotHeaderItemProperty, value);
            }
        }

        private void VGtimePivotHeaderItemAssistButton_Click(object sender, RoutedEventArgs e)
        {
            var attachPivotHeaderItem = AttachedPivotHeaderItem;
            if (attachPivotHeaderItem != null)
            {
                this.GetFirstAncestorOfType<VGtimePivot>()?.FireSelectedHeaderItemClick(attachPivotHeaderItem);
            }
        }
    }
}