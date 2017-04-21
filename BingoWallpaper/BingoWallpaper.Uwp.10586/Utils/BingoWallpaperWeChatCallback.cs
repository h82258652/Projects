﻿using BingoWallpaper.Uwp.Services;
using MicroMsg.sdk;
using Microsoft.Practices.ServiceLocation;

namespace BingoWallpaper.Uwp.Utils
{
    internal sealed class BingoWallpaperWechatCallback : WXEntryBasePage
    {
        private readonly IAppToastService _appToastService;

        internal BingoWallpaperWechatCallback()
        {
            _appToastService = ServiceLocator.Current.GetInstance<IAppToastService>();
        }

        public override void OnSendMessageToWXResponse(SendMessageToWX.Resp response)
        {
            base.OnSendMessageToWXResponse(response);
            if (response.ErrCode == 0)
            {
                _appToastService.ShowMessage(LocalizedStrings.ShareSuccess);
            }
            else
            {
                _appToastService.ShowError(response.ErrStr);
            }
        }
    }
}