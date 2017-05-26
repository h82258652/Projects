using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using VGtime.Uwp.ViewModels.Games;
using WinRTXamlToolkit.AwaitableUI;

namespace VGtime.Uwp.Views.Games
{
    public sealed partial class GamePhotoView
    {
        public GamePhotoView()
        {
            InitializeComponent();
        }

        public GamePhotoViewModel ViewModel => (GamePhotoViewModel)DataContext;

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            int gameId = (int)e.Parameter;
            if (ViewModel.GameId != gameId)
            {
                ViewModel.LoadPhotos(gameId);
            }

            if (e.NavigationMode == NavigationMode.Back)
            {
                await PhotosGridView.WaitForLoadedAsync();
                var connectedAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("ImagePagerView");
                if (connectedAnimation != null)
                {
                    var item = PhotosGridView.Items[0];// TODO
                    PhotosGridView.ScrollIntoView(item);
                    await PhotosGridView.TryStartConnectedAnimationAsync(connectedAnimation, item, "PhotoImage");
                }
            }
        }

        private void PhotosGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var gridView = (ListViewBase)sender;
            gridView.PrepareConnectedAnimation("GamePhotoView", e.ClickedItem, "PhotoImage");
        }
    }
}