using System;
using GalaSoft.MvvmLight.Messaging;
using U148.Models;

namespace U148.Uwp.Messages
{
    public class LoginSuccessMessage : MessageBase
    {
        public LoginSuccessMessage(UserInfo userInfo)
        {
            if (userInfo == null)
            {
                throw new ArgumentNullException(nameof(userInfo));
            }

            UserInfo = userInfo;
        }

        public UserInfo UserInfo
        {
            get;
        }
    }
}