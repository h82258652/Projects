namespace VGtime.Uwp.Services
{
    public interface IAppToastService
    {
        void ShowError(string message);

        void ShowMessage(sbyte message);

        void ShowWarning(string message);
    }
}