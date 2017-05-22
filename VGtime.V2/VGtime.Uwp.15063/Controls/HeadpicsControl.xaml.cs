using Windows.UI.Xaml;

namespace VGtime.Uwp.Controls
{
    public sealed partial class HeadpicsControl
    {
        public HeadpicsControl()
        {
            InitializeComponent();
        }

        private void HeadpicsControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width <= 640)
            {
                HeadpicsIndicator.Visibility = Visibility.Visible;
            }
            else
            {
                HeadpicsIndicator.Visibility = Visibility.Collapsed;
            }
        }
    }
}