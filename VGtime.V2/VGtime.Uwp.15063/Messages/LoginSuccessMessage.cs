using System;
using GalaSoft.MvvmLight.Messaging;
using VGtime.Models.Users;

namespace VGtime.Uwp.Messages
{
    public class LoginSuccessMessage : MessageBase
    {
        public LoginSuccessMessage(UserBase userInfo)
        {
            if (userInfo == null)
            {
                throw new ArgumentNullException(nameof(userInfo));
            }

            UserInfo = userInfo;
        }

        public UserBase UserInfo
        {
            get;
        }
    }
}