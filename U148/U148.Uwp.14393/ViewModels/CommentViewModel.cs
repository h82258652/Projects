using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SoftwareKobo.ViewModels;
using U148.Configuration;
using U148.Models;
using U148.Services;
using U148.Uwp.Messages;
using U148.Uwp.Services;

namespace U148.Uwp.ViewModels
{
    public class CommentViewModel : ViewModelBase, INavigable
    {
        private readonly IAppToastService _appToastService;

        private readonly ICommentService _commentService;

        private readonly IU148Settings _u148Settings;

        private Article _article;

        private bool _isBusy;

        private RelayCommand _refreshCommand;

        private RelayCommand<string> _sendCommentCommand;

        public CommentViewModel(ICommentService commentService, IAppToastService appToastService, IU148Settings u148Settings)
        {
            _commentService = commentService;
            _appToastService = appToastService;
            _u148Settings = u148Settings;

            MessengerInstance.Register<LoginSuccessMessage>(this, message =>
            {
                RaisePropertyChanged(nameof(IsLogined));
                SendCommentCommand.RaiseCanExecuteChanged();
            });
            MessengerInstance.Register<LogoutMessage>(this, message =>
            {
                RaisePropertyChanged(nameof(IsLogined));
                SendCommentCommand.RaiseCanExecuteChanged();
            });
        }

        public IEnumerable<Comment> Comments
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            private set
            {
                Set(ref _isBusy, value);
                SendCommentCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsLogined => _u148Settings.UserInfo != null;

        public RelayCommand RefreshCommand
        {
            get
            {
                _refreshCommand = _refreshCommand ?? new RelayCommand(() =>
                {
                    throw new NotImplementedException();
                });
                return _refreshCommand;
            }
        }

        public RelayCommand<string> SendCommentCommand
        {
            get
            {
                _sendCommentCommand = _sendCommentCommand ?? new RelayCommand<string>(async comment =>
                {
                    if (IsBusy)
                    {
                        return;
                    }

                    var userInfo = _u148Settings.UserInfo;
                    if (userInfo == null)
                    {
                        MessengerInstance.Send(new ShowLoginViewMessage());
                        return;
                    }

                    if (string.IsNullOrEmpty(comment))
                    {
                        _appToastService.ShowInformation(LocalizedStrings.PleaseInputComment);
                        return;
                    }

                    IsBusy = true;
                    try
                    {
                        var result = await _commentService.SendCommentAsync(_article.Id, userInfo.Token, comment, _u148Settings.SimulateDevice);
                        if (result.ErrorCode == 0)
                        {
                            _appToastService.ShowMessage(LocalizedStrings.SendCommentSuccess);

                            MessengerInstance.Send(new SendCommentSuccessMessage());

                            // TODO refresh comments.
                            throw new NotImplementedException();
                        }
                        else
                        {
                            _appToastService.ShowError(result.ErrorMessage);
                        }
                    }
                    catch (Exception ex)
                    {
                        _appToastService.ShowError(ex.Message);
                    }
                    finally
                    {
                        IsBusy = false;
                    }
                }, comment =>
                {
                    return IsLogined && !IsBusy;
                });
                return _sendCommentCommand;
            }
        }

        public void Activate(object parameter)
        {
            _article = (Article)parameter;

            throw new NotImplementedException();
        }

        public override void Cleanup()
        {
            base.Cleanup();

            MessengerInstance.Unregister(this);
        }

        public void Deactivate(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}