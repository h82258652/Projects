using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using VGtime.Services;
using VGtime.Uwp.Data;

namespace VGtime.Uwp.ViewModels
{
    public class OldStrategyViewModel : ViewModelBase
    {
        public OldStrategyViewModel(IPostService postService)
        {
            StrategyPosts = new TagPostCollection(postService, 6);
        }

        public TagPostCollection StrategyPosts
        {
            get;
        }
    }
}