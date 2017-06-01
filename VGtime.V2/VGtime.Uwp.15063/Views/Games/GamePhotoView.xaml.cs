using System;
using System.Diagnostics;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using VGtime.Uwp.ViewModels.Games;
using VGtime.Uwp.ViewParameters;
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

            var parameter = (GamePhotoViewParameter)e.Parameter;
            Debug.Assert(parameter != null);
            var gameId = parameter.GameId;
            if (ViewModel.GameId != gameId)
            {
                ViewModel.GameName = parameter.GameName;
                ViewModel.LoadPhotos(gameId);
            }

            if (e.NavigationMode == NavigationMode.Back)
            {
                var imagePagerViewParameter = ViewModel.ImagePagerViewParameter;
                if (imagePagerViewParameter != null)
                {
                    var photoIndex = imagePagerViewParameter.PhotoIndex;
                    await PhotosGridView.WaitForLoadedAsync();
                    var connectedAnimation = ConnectedAnimationService.GetForCurrentView().GetAnimation("ImagePagerView");
                    if (connectedAnimation != null)
                    {
                        var items = PhotosGridView.Items;
                        if (items != null)
                        {
                            var item = items[photoIndex];
                            PhotosGridView.ScrollIntoView(item);
                            await PhotosGridView.TryStartConnectedAnimationAsync(connectedAnimation, item, "PhotoImage");
                        }
                    }
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