using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace VGtime.Uwp.Controls
{
    [TemplatePart(Name = EllipseTemplateName, Type = typeof(Ellipse))]
    [TemplatePart(Name = EllipseAssistTemplateName, Type = typeof(EllipseAssist))]
    [TemplateVisualState(GroupName = ActiveStateGroupName, Name = InactiveStateName)]
    [TemplateVisualState(GroupName = ActiveStateGroupName, Name = ActiveStateName)]
    public class VGtimeProgressRing : Control
    {
        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register(nameof(IsActive), typeof(bool), typeof(VGtimeProgressRing), new PropertyMetadata(default(bool), OnIsActiveChanged));

        public static readonly DependencyProperty ThicknessProperty = DependencyProperty.Register(nameof(Thickness), typeof(double), typeof(VGtimeProgressRing), new PropertyMetadata(default(double)));

        private const string ActiveStateGroupName = "ActiveStates";

        private const string ActiveStateName = "Active";

        private const string EllipseAssistTemplateName = "PART_EllipseAssist";

        private const string EllipseTemplateName = "PART_Ellipse";

        private const string InactiveStateName = "Inactive";

        public VGtimeProgressRing()
        {
            DefaultStyleKey = typeof(VGtimeProgressRing);
        }

        public bool IsActive
        {
            get
            {
                return (bool)GetValue(IsActiveProperty);
            }
            set
            {
                SetValue(IsActiveProperty, value);
            }
        }

        public double Thickness
        {
            get
            {
                return (double)GetValue(ThicknessProperty);
            }
            set
            {
                SetValue(ThicknessProperty, value);
            }
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var ellipse = (Ellipse)GetTemplateChild(EllipseTemplateName);
            var ellipseAssist = (EllipseAssist)GetTemplateChild(EllipseAssistTemplateName);
            ellipseAssist.AttachedEllipse = ellipse;

            UpdateVisualState();
        }

        private static void OnIsActiveChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (VGtimeProgressRing)d;

            obj.UpdateVisualState();
        }

        private void UpdateVisualState()
        {
            if (IsActive)
            {
                VisualStateManager.GoToState(this, ActiveStateName, true);
            }
            else
            {
                VisualStateManager.GoToState(this, InactiveStateName, true);
            }
        }
    }
}