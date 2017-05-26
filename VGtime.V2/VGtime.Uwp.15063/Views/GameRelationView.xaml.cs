using System.Diagnostics;
using VGtime.Uwp.ViewModels;
using VGtime.Uwp.ViewParameters;
using Windows.UI.Xaml.Navigation;

namespace VGtime.Uwp.Views
{
    public sealed partial class GameRelationView
    {
        public GameRelationView()
        {
            InitializeComponent();
        }

        public GameRelationViewModel ViewModel => (GameRelationViewModel)DataContext;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameter = (GameRelationViewParameter)e.Parameter;
            Debug.Assert(parameter != null);
            if (ViewModel.GameId != parameter.GameId)
            {
                ViewModel.LoadGameRelations(parameter.GameId, parameter.Type);
            }
        }
    }
}