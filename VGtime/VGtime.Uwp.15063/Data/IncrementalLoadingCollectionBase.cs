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
        private bool _hasMoreItems = true;

        private bool _isLoading;

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