using System;

namespace VGtime.Uwp.Controls
{
    public class VGtimePagerPageChangedEventArgs : EventArgs
    {
        public VGtimePagerPageChangedEventArgs(int newPage)
        {
            NewPage = newPage;
        }

        public int NewPage
        {
            get;
        }
    }
}