using System.Net;
using VGtime.Services;
using Windows.UI.Xaml;

namespace VGtime.Uwp.Views
{
    public sealed partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        private async void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            IPostService postService = new PostService();
            {
                //var result = await postService.GetHeadPicAsync();
                //if (result.ErrorCode == HttpStatusCode.OK)
                //{
                //    var dataData = result.Data.Data;
                //}
            }
            {
                var result = await postService.GetListAsync();
                if (result.ErrorCode == HttpStatusCode.OK)
                {
                    var dataData = result.Data.Data;
                    ListView.ItemsSource = dataData;
                }
            }
        }
    }
}