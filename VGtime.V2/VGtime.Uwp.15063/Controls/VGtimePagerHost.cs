using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace VGtime.Uwp.Controls
{
    [TemplateVisualState(GroupName = CommonStateGroupName, Name = VisibleStateName)]
    [TemplateVisualState(GroupName = CommonStateGroupName, Name = CollapsedStateName)]
    public sealed class VGtimePagerHost : Control
    {
        public static readonly DependencyProperty IsVisibleProperty = DependencyProperty.Register(nameof(IsVisible), typeof(bool), typeof(VGtimePagerHost), new PropertyMetadata(default(bool), OnIsVisibleChanged));

        private const string CollapsedStateName = "Collapsed";
        private const string CommonStateGroupName = "CommonStates";
        private const string VisibleStateName = "Visible";

        public VGtimePagerHost()
        {
            DefaultStyleKey = typeof(VGtimePagerHost);
        }

        public bool IsVisible
        {
            get
            {
                return (bool)GetValue(IsVisibleProperty);
            }
            set
            {
                SetValue(IsVisibleProperty, value);
            }
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            UpdateVisualState(false);
        }

        private static void OnIsVisibleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (VGtimePagerHost)d;

            obj.UpdateVisualState(true);
        }

        private void UpdateVisualState(bool useTransitions)
        {
            if (IsVisible)
            {
                VisualStateManager.GoToState(this, VisibleStateName, useTransitions);
            }
            else
            {
                VisualStateManager.GoToState(this, CollapsedStateName, useTransitions);
            }
        }
    }
}