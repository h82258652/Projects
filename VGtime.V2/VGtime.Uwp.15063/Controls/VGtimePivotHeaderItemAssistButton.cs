using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using WinRTXamlToolkit.Controls.Extensions;

namespace VGtime.Uwp.Controls
{
    internal class VGtimePivotHeaderItemAssistButton : Button
    {
        internal static readonly DependencyProperty AttachPivotHeaderItemProperty = DependencyProperty.Register(nameof(AttachPivotHeaderItem), typeof(PivotHeaderItem), typeof(VGtimePivotHeaderItemAssistButton), new PropertyMetadata(default(PivotHeaderItem)));

        internal VGtimePivotHeaderItemAssistButton()
        {
            Click += VGtimePivotHeaderItemAssistButton_Click;
        }

        internal PivotHeaderItem AttachPivotHeaderItem
        {
            get
            {
                return (PivotHeaderItem)GetValue(AttachPivotHeaderItemProperty);
            }
            set
            {
                SetValue(AttachPivotHeaderItemProperty, value);
            }
        }

        private void VGtimePivotHeaderItemAssistButton_Click(object sender, RoutedEventArgs e)
        {
            var attachPivotHeaderItem = AttachPivotHeaderItem;
            if (attachPivotHeaderItem != null)
            {
                this.GetFirstAncestorOfType<VGtimePivot>()?.FireSelectedHeaderItemClick(attachPivotHeaderItem);
            }
        }
    }
}