using MicroMsg.sdk;
using Microsoft.Practices.ServiceLocation;
using U148.Uwp.Services;

namespace U148.Uwp.Utils
{
    internal sealed class U148WechatCallback : WXEntryBasePage
    {
        private readonly IAppToastService _appToastService;

        internal U148WechatCallback()
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