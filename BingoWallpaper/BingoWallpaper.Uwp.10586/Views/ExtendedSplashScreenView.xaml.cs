﻿using System;
using System.Linq;
using System.Threading.Tasks;
using BingoWallpaper.Extensions;
using BingoWallpaper.Uwp.BackgroundTasks;
using SoftwareKobo.Helpers;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Background;
using Windows.Foundation.Metadata;
using Windows.Graphics.Display;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.AwaitableUI;

namespace BingoWallpaper.Uwp.Views
{
    public sealed partial class ExtendedSplashScreenView
    {
        private readonly SplashScreen _splashScreen;

        private BackgroundTaskRegistration _backgroundTaskRegistration;

        public ExtendedSplashScreenView()
        {
            InitializeComponent();
        }

        public ExtendedSplashScreenView(SplashScreen splashScreen) : this()
        {
            _splashScreen = splashScreen;

            UpdateSplashScreenImagePosition();
        }

        public event EventHandler Completed;

        public async Task DismissAsync()
        {
            await DismissStoryboard.BeginAsync();
        }

        private static async Task HideStatusBarAsync()
        {
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                await StatusBar.GetForCurrentView().HideAsync();
            }
        }

        private static void InitializeTitleBar()
        {
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            var systemAccentColor = ColorExtensions.AccentColor;
            titleBar.BackgroundColor = systemAccentColor;
            titleBar.ForegroundColor = Colors.White;
            titleBar.InactiveBackgroundColor = systemAccentColor;
            titleBar.ButtonBackgroundColor = systemAccentColor;
            titleBar.ButtonForegroundColor = Colors.White;
            titleBar.ButtonHoverBackgroundColor = systemAccentColor.Lighter();
            titleBar.ButtonPressedBackgroundColor = systemAccentColor.Darker();
            titleBar.ButtonInactiveBackgroundColor = systemAccentColor;
        }

        private static void UpdatePrimaryTile()
        {
            new UpdateTileTask().Run(null);
        }

        private void ExtendedSplashScreenView_Loaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SizeChanged += Window_SizeChanged;
            UpdateSplashScreenImagePosition();
        }

        private void ExtendedSplashScreenView_Unloaded(object sender, RoutedEventArgs e)
        {
            Window.Current.SizeChanged -= Window_SizeChanged;
        }

        private async Task RegisterBackgroundTaskAsync()
        {
            _backgroundTaskRegistration = BackgroundTaskRegistration.AllTasks.Values.OfType<BackgroundTaskRegistration>().FirstOrDefault(temp => temp.Name == Constants.UpdateTileTaskName);

            if (_backgroundTaskRegistration != null)
            {
                // 已经注册后台任务。
                return;
            }

            var access = await BackgroundExecutionManager.RequestAccessAsync();
            if (access != BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity)
            {
                // 没有权限。
                return;
            }

            var builder = new BackgroundTaskBuilder();
            // 仅在网络可用下执行后台任务。
            builder.AddCondition(new SystemCondition(SystemConditionType.InternetAvailable));

            builder.Name = Constants.UpdateTileTaskName;
            builder.TaskEntryPoint = "BingoWallpaper.Uwp.BackgroundTasks.UpdateTileTask";
            builder.SetTrigger(new TimeTrigger(15, false));
            _backgroundTaskRegistration = builder.Register();
        }

        private async void SplashScreenImage_ImageOpened(object sender, RoutedEventArgs e)
        {
            // 图片加载完毕后激活当前窗口，系统 SplashScreen 将会消失。
            Window.Current.Activate();

            InitializeTitleBar();
            await Task.WhenAll(HideStatusBarAsync(), RegisterBackgroundTaskAsync());
            UpdatePrimaryTile();
            Completed?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateSplashScreenImagePosition()
        {
            if (_splashScreen != null)
            {
                var rect = _splashScreen.ImageLocation;
                Canvas.SetLeft(SplashScreenImage, rect.Left);
                Canvas.SetTop(SplashScreenImage, rect.Top);

                if (DeviceFamilyHelper.IsMobile)
                {
                    var scaleFactor = (double)DisplayInformation.GetForCurrentView().ResolutionScale / 100.0d;
                    SplashScreenImage.Width = rect.Width / scaleFactor;
                    SplashScreenImage.Height = rect.Height / scaleFactor;
                }
                else
                {
                    SplashScreenImage.Width = rect.Width;
                    SplashScreenImage.Height = rect.Height;
                }
            }
        }

        private void Window_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            UpdateSplashScreenImagePosition();
        }
    }
}