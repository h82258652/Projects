using System;
using Windows.UI.Xaml;

namespace U148.Uwp.Controls
{
    public sealed partial class ChooseShareControl
    {
        public ChooseShareControl()
        {
            InitializeComponent();
        }

        public event EventHandler QQShareRequested;

        public event EventHandler QZoneShareRequested;

        public event EventHandler SinaWeiboShareRequested;

        public event EventHandler WechatShareRequested;

        private void QQShareButton_Click(object sender, RoutedEventArgs e)
        {
            QQShareRequested?.Invoke(this, EventArgs.Empty);
        }

        private void QZoneShareButton_Click(object sender, RoutedEventArgs e)
        {
            QZoneShareRequested?.Invoke(this, EventArgs.Empty);
        }

        private void SinaWeiboButton_Click(object sender, RoutedEventArgs e)
        {
            SinaWeiboShareRequested?.Invoke(this, EventArgs.Empty);
        }

        private void WechatButton_Click(object sender, RoutedEventArgs e)
        {
            WechatShareRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}