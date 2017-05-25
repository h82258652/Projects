using System.Diagnostics;
using Windows.UI.Xaml.Navigation;
using VGtime.Uwp.ViewModels;
using VGtime.Uwp.ViewParameters;

namespace VGtime.Uwp.Views
{
    public sealed partial class CommentView
    {
        public CommentView()
        {
            InitializeComponent();
        }

        public CommentViewModel ViewModel => (CommentViewModel)DataContext;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var parameter = (CommentViewParameter)e.Parameter;
            Debug.Assert(parameter != null);
            if (ViewModel.PostId != parameter.PostId)
            {
                ViewModel.LoadComments(parameter.PostId, parameter.DetailType);
            }
        }
    }
}