using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace VGtime.Uwp.Controls
{
    [TemplateVisualState(GroupName = CommonStateGroupName, Name = NoScoreVisualStateName)]
    [TemplateVisualState(GroupName = CommonStateGroupName, Name = OnSaleVisualStateName)]
    [TemplateVisualState(GroupName = CommonStateGroupName, Name = WaitForSaleStateName)]
    public sealed class ScoreItem : Control
    {
        public static readonly DependencyProperty ScoreProperty = DependencyProperty.Register(nameof(Score), typeof(object), typeof(ScoreItem), new PropertyMetadata(null, OnScoreChanged));

        public static readonly DependencyProperty SuffixProperty = DependencyProperty.Register(nameof(Suffix), typeof(object), typeof(ScoreItem), new PropertyMetadata(default(object)));

        private const string CommonStateGroupName = "CommonStates";

        private const string NoScoreVisualStateName = "NoScore";

        private const string OnSaleVisualStateName = "OnSale";

        private const string WaitForSaleStateName = "WaitForSale";

        public ScoreItem()
        {
            DefaultStyleKey = typeof(ScoreItem);
        }

        public float? Score
        {
            get
            {
                return (float?)GetValue(ScoreProperty);
            }
            set
            {
                SetValue(ScoreProperty, value);
            }
        }

        public object Suffix
        {
            get
            {
                return GetValue(SuffixProperty);
            }
            set
            {
                SetValue(SuffixProperty, value);
            }
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            UpdateVisualState();
        }

        private static void OnScoreChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (ScoreItem)d;

            obj.UpdateVisualState();
        }

        private void UpdateVisualState()
        {
            if (!Score.HasValue)
            {
                VisualStateManager.GoToState(this, NoScoreVisualStateName, true);
            }
            else if (Score.Value > 0)
            {
                VisualStateManager.GoToState(this, OnSaleVisualStateName, true);
            }
            else
            {
                VisualStateManager.GoToState(this, WaitForSaleStateName, true);
            }
        }
    }
}