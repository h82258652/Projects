using VGtime.Uwp.ViewModels;

namespace VGtime.Uwp.Views
{
    public sealed partial class GameDetailView
    {
        public GameDetailView()
        {
            InitializeComponent();
        }

        public GameDetailViewModel ViewModel
        {
            get
            {
                return DataContext as GameDetailViewModel;
            }
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RelationListView), new ViewModelParameters.RelationListViewModelParameter(ViewModel.GameDetail.GameId, 1));
        }

        private void Button_Click_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RelationListView), new ViewModelParameters.RelationListViewModelParameter(ViewModel.GameDetail.GameId, 2));
        }

        private void Button_Click_2(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ScoreListView), ViewModel.GameDetail.GameId);
        }

        private void Button_Click_3(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RelationListView), new ViewModelParameters.RelationListViewModelParameter(ViewModel.GameDetail.GameId, 3));
        }

        private void Button_Click_4(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(StrategyView), ViewModel.GameDetail.GameId);
        }
    }
}