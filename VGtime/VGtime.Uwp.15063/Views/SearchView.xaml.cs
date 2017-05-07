using VGtime.Uwp.ViewModels;

namespace VGtime.Uwp.Views
{
    public sealed partial class SearchView
    {
        public SearchView()
        {
            InitializeComponent();
        }

        private void AutoSuggestBox_QuerySubmitted(Windows.UI.Xaml.Controls.AutoSuggestBox sender, Windows.UI.Xaml.Controls.AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            var vm = DataContext as SearchViewModel;
            vm.SearchCommand.Execute(args.QueryText);
        }
    }
}