using System.Threading.Tasks;

namespace VGtime.Uwp.Controls
{
    public interface IDialog
    {
        void Hide();

        Task HideAsync();

        void Show();

        Task ShowAsync();
    }
}