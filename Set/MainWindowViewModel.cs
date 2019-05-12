using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace Set
{
    class MainWindowViewModel: ObservableObject, PageViewModel
    {

        private DelegateCommand _changePageCommand;

        private PageViewModel _currentPageViewModel;
        private List<PageViewModel> _pageViewModels;

        public MainWindowViewModel()
        {
            // Add available pages
            PageViewModels.Add(new MenuViewModel(this));
            PageViewModels.Add(new GameViewModel(this));

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
        }

        #region Properties
        public DelegateCommand ChangePageToMenuShortcut
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new DelegateCommand(
                        p => ChangePageToMenu());
                }

                return _changePageCommand;
            }
        }

        public List<PageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<PageViewModel>();

                return _pageViewModels;
            }
        }

        public PageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }
        #endregion

        #region Methods


        public void ChangePageToGame()
        {
            CurrentPageViewModel = PageViewModels[1];
        }

        public void ChangePageToMenu()
        {
            CurrentPageViewModel = PageViewModels[0];
        }
        #endregion
    }

}
