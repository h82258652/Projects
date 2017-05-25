using VGtime.Uwp.ViewModels.Users;

namespace VGtime.Uwp.Views.Users
{
    public sealed partial class LoginView
    {
        public LoginView()
        {
            InitializeComponent();
        }

        public LoginViewModel ViewModel => (LoginViewModel)DataContext;
    }
}