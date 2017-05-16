using GalaSoft.MvvmLight;
using SoftwareKobo.ViewModels;
using VGtime.Models;
using VGtime.Uwp.ViewParameters;

namespace VGtime.Uwp.ViewModels
{
    public class AblumDetailViewModel : ViewModelBase, INavigable
    {
        private Ablum[] _ablums;

        private int _selectedIndex = -1;

        public Ablum[] Ablums
        {
            get
            {
                return _ablums;
            }
            private set
            {
                Set(ref _ablums, value);
            }
        }

        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                Set(ref _selectedIndex, value);
            }
        }

        public void Activate(object parameter)
        {
            var viewParameter = (AblumDetailViewParameter)parameter;
            Ablums = viewParameter.Ablums;
            SelectedIndex = viewParameter.Index;
        }

        public void Deactivate(object parameter)
        {
        }
    }
}