using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml.Data;

namespace VGtime.Uwp.Data
{
    public abstract class IncrementalLoadingCollectionBase<T> : ObservableCollection<T>, ISupportIncrementalLoading
    {
        private int _currentPage;

        private bool _hasMoreItems = true;

        private bool _isLoading;

        public int CurrentPage
        {
            get
            {
                return _currentPage;
            }
            protected set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(CurrentPage)));
                }
            }
        }

        public bool HasMoreItems
        {
            get
            {
                return _hasMoreItems;
            }
            protected set
            {
                if (_hasMoreItems != value)
                {
                    _hasMoreItems = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(HasMoreItems)));
                }
            }
        }

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            protected set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(IsLoading)));
                }
            }
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            return AsyncInfo.Run(async cancellationToken => new LoadMoreItemsResult()
            {
                Count = await LoadMoreItemsAsync(count, cancellationToken)
            });
        }

        public async void Refresh()
        {
            ClearItems();
            CurrentPage = 0;
            OnRefresh();
            HasMoreItems = true;
            await LoadMoreItemsAsync(1);
        }

        protected abstract Task<uint> LoadMoreItemsAsync(uint count, CancellationToken cancellationToken);

        protected virtual void OnRefresh()
        {
        }
    }
}