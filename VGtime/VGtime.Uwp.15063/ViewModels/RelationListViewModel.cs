using System;
using GalaSoft.MvvmLight;
using SoftwareKobo.ViewModels;
using VGtime.Services;

namespace VGtime.Uwp.ViewModels
{
    public class RelationListViewModel : ViewModelBase, INavigable
    {
        public void Activate(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Deactivate(object parameter)
        {
            throw new NotImplementedException();
        }

        private void LoadXXX()
        {
            // TODO rename

            _postService.GetRelationListAsync(2235, 1);
        }

        private readonly IPostService _postService;
    }
}