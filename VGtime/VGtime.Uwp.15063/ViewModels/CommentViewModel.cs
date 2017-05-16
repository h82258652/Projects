﻿using GalaSoft.MvvmLight;
using SoftwareKobo.ViewModels;
using VGtime.Models;
using VGtime.Services;
using VGtime.Uwp.Data;

namespace VGtime.Uwp.ViewModels
{
    public class CommentViewModel : ViewModelBase, INavigable
    {
        private readonly IPostService _postService;

        private CommentCollection _comments;

        private Post _post;

        public CommentViewModel(IPostService postService)
        {
            _postService = postService;
        }

        public CommentCollection Comments
        {
            get
            {
                return _comments;
            }
            private set
            {
                Set(ref _comments, value);
            }
        }

        public Post Post
        {
            get
            {
                return _post;
            }
            private set
            {
                Set(ref _post, value);
            }
        }

        public void Activate(object parameter)
        {
            Post = (Post)parameter;
            Comments = new CommentCollection(Post.PostId, Post.DetailType, _postService);
        }

        public void Deactivate(object parameter)
        {
        }
    }
}