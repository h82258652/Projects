using System;
using System.Reflection;
using System.Windows.Controls.Primitives;

namespace SoftwareKobo.Extensions
{
    public static class PopupExtensions
    {
        public static void UpdatePosition(this Popup popup)
        {
            if (popup == null)
            {
                throw new ArgumentNullException(nameof(popup));
            }

            var type = popup.GetType();
            var method = type.GetMethod("UpdatePosition", BindingFlags.Instance | BindingFlags.NonPublic);
            method.Invoke(popup, null);
        }
    }
}