using System;
using Windows.UI.Xaml.Controls.Primitives;

namespace VGtime.Uwp.Controls
{
    public class VGtimePivotSelectedHeaderItemClickEventArgs : EventArgs
    {
        public VGtimePivotSelectedHeaderItemClickEventArgs(PivotHeaderItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            Item = item;
        }

        public PivotHeaderItem Item
        {
            get;
        }
    }
}