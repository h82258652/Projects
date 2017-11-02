using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BingoWallpaper.Models.LeanCloud;
using BingoWallpaper.Services;
using ReactiveUI;

namespace BingoWallpaper.ViewModels
{
    public class MainViewModel : ReactiveObject, IMainViewModel
    {
        private readonly ILeanCloudService _leanCloudService;

        public MainViewModel(ILeanCloudService leanCloudService)
        {
            _leanCloudService = leanCloudService;
        }

        private ICommand _loadMoreCommand;

        public ICommand LoadMoreCommand
        {
            get
            {
                if (_loadMoreCommand == null)
                {
                    var command = ReactiveCommand.CreateFromTask(async () =>
                    {
                    });
                    command.ThrownExceptions.Subscribe(ex =>
                    {
                    });

                    _loadMoreCommand = command;
                }
                return _loadMoreCommand;
            }
        }

        public ICommand WallpaperClickCommand { get; }

        public ObservableCollection<Wallpaper> Wallpapers { get; }
    }
}