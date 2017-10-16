using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WeddingPhotos.Mobile.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel()
        {
            Tabs = new ObservableCollection<string>
            {
                "Test1",
                "Test2",
                "Test3"
            };
            TabPosition = 0;
            SlideTab = new RelayCommand<string>(OnSlideTab);
            SlideToTab = new RelayCommand<string>(OnSlideToTab);
        }

        public ICommand SlideTab { get; set; }
        public ICommand SlideToTab { get; set; }

        private bool _hasNext;
        public bool HasNext
        {
            get { return _hasNext; }
            set
            {
                _hasNext = value;
                RaisePropertyChanged(nameof(HasNext));
            }
        }

        private bool _hasPrevious;
        public bool HasPrevious
        {
            get { return _hasPrevious; }
            set
            {
                _hasPrevious = value;
                RaisePropertyChanged(nameof(HasPrevious));
            }
        }
        public ObservableCollection<string> Tabs { get; set; }

        private int _tabPosition;
        public int TabPosition
        {
            get { return _tabPosition; }
            set
            {
                _tabPosition = value;
                HasPrevious = TabPosition > 0;
                HasNext = TabPosition < Tabs.Count - 1;
                RaisePropertyChanged(nameof(TabPosition));
            }
        }

        private void OnSlideTab(string direction)
        {
            var tabModifier = int.Parse(direction);
            TabPosition += tabModifier;
        }

        private void OnSlideToTab(string position)
        {
            TabPosition = int.Parse(position);
        }
    }
}
