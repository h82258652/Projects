﻿using Windows.UI.Xaml.Navigation;
using VGtime.Uwp.ViewModels.Games;

namespace VGtime.Uwp.Views.Games
{
    public sealed partial class GamePostView
    {
        public GamePostView()
        {
            InitializeComponent();
        }

        public GamePostViewModel ViewModel => (GamePostViewModel)DataContext;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var gameId = (int)e.Parameter;
            if (ViewModel.GameId != gameId)
            {
                ViewModel.LoadPosts(gameId);
            }
        }
    }
}