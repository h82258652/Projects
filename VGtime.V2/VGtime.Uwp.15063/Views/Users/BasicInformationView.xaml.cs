using VGtime.Uwp.ViewModels.Users;

namespace VGtime.Uwp.Views.Users
{
    public sealed partial class BasicInformationView
    {
        public BasicInformationView()
        {
            InitializeComponent();
        }

        public BasicInformationViewModel ViewModel => (BasicInformationViewModel)DataContext;
    }
}