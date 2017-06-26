using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace VGtime.Uwp.Controls
{
    [TemplatePart(Name = PagerItemListViewTemplateName, Type = typeof(ListView))]
    [TemplatePart(Name = PreviousButtonTemplateName, Type = typeof(Button))]
    [TemplatePart(Name = NextButtonTemplateName, Type = typeof(Button))]
    [StyleTypedProperty(Property = nameof(PagerItemStyle), StyleTargetType = typeof(ListViewItem))]
    [StyleTypedProperty(Property = nameof(PreviousButtonStyle), StyleTargetType = typeof(Button))]
    [StyleTypedProperty(Property = nameof(NextButtonStyle), StyleTargetType = typeof(Button))]
    public class VGtimePager : Control
    {
        public static readonly DependencyProperty CurrentPageProperty = DependencyProperty.Register(nameof(CurrentPage), typeof(int), typeof(VGtimePager), new PropertyMetadata(1, OnCurrentPageChanged));

        public static readonly DependencyProperty NextButtonStyleProperty = DependencyProperty.Register(nameof(NextButtonStyle), typeof(Style), typeof(VGtimePager), new PropertyMetadata(default(Style)));

        public static readonly DependencyProperty PagerItemStyleProperty = DependencyProperty.Register(nameof(PagerItemStyle), typeof(Style), typeof(VGtimePager), new PropertyMetadata(default(Style)));

        public static readonly DependencyProperty PreviousButtonStyleProperty = DependencyProperty.Register(nameof(PreviousButtonStyle), typeof(Style), typeof(VGtimePager), new PropertyMetadata(default(Style)));

        public static readonly DependencyProperty TotalPageProperty = DependencyProperty.Register(nameof(TotalPage), typeof(int), typeof(VGtimePager), new PropertyMetadata(1, OnTotalPageChanged));

        private const string NextButtonTemplateName = "PART_NextButton";

        private const string PagerItemListViewTemplateName = "PART_PagerItemListView";

        private const string PreviousButtonTemplateName = "PART_PreviousButton";

        private Button _nextButton;

        private ListView _pagerItemListView;

        private Button _previousButton;

        public VGtimePager()
        {
            DefaultStyleKey = typeof(VGtimePager);
        }

        public event VGtimePagerPageChangedEventHandler PageChanged;

        public int CurrentPage
        {
            get
            {
                return (int)GetValue(CurrentPageProperty);
            }
            set
            {
                SetValue(CurrentPageProperty, value);
            }
        }

        public Style NextButtonStyle
        {
            get
            {
                return (Style)GetValue(NextButtonStyleProperty);
            }
            set
            {
                SetValue(NextButtonStyleProperty, value);
            }
        }

        public Style PagerItemStyle
        {
            get
            {
                return (Style)GetValue(PagerItemStyleProperty);
            }
            set
            {
                SetValue(PagerItemStyleProperty, value);
            }
        }

        public Style PreviousButtonStyle
        {
            get
            {
                return (Style)GetValue(PreviousButtonStyleProperty);
            }
            set
            {
                SetValue(PreviousButtonStyleProperty, value);
            }
        }

        public int TotalPage
        {
            get
            {
                return (int)GetValue(TotalPageProperty);
            }
            set
            {
                SetValue(TotalPageProperty, value);
            }
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _pagerItemListView = (ListView)GetTemplateChild(PagerItemListViewTemplateName);
            _pagerItemListView.SelectionChanged += PagerItemListView_SelectionChanged;

            _previousButton = (Button)GetTemplateChild(PreviousButtonTemplateName);
            _previousButton.Click += PreviousButton_Click;

            _nextButton = (Button)GetTemplateChild(NextButtonTemplateName);
            _nextButton.Click += NextButton_Click;

            UpdateView();
        }

        private static void OnCurrentPageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (VGtimePager)d;
            var value = (int)e.NewValue;

            if (value < 1)
            {
                obj.CurrentPage = 1;
                return;
            }
            if (value > obj.TotalPage)
            {
                obj.CurrentPage = obj.TotalPage;
                return;
            }

            obj.UpdateView();
            obj.PageChanged?.Invoke(obj, new VGtimePagerPageChangedEventArgs(value));
        }

        private static void OnTotalPageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (VGtimePager)d;
            var value = (int)e.NewValue;

            if (value < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(TotalPage));
            }

            obj.UpdateView();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage < TotalPage)
            {
                CurrentPage++;
            }
        }

        private void PagerItemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedPagerItem = _pagerItemListView.SelectedItem;
            if (selectedPagerItem != null)
            {
                CurrentPage = (int)selectedPagerItem;
            }
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
            }
        }

        private void UpdateView()
        {
            if (_pagerItemListView != null)
            {
                _pagerItemListView.ItemsSource = Enumerable.Range(1, TotalPage);
                _pagerItemListView.SelectedItem = CurrentPage;
            }
            if (_previousButton != null)
            {
                _previousButton.IsEnabled = CurrentPage > 1;
            }
            if (_nextButton != null)
            {
                _nextButton.IsEnabled = CurrentPage < TotalPage;
            }
        }
    }
}