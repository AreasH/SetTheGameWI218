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
        private string name = "MainWindowViewModel";
        private PageViewModel _currentPageViewModel;
        private List<PageViewModel> _pageViewModels;

        public MainWindowViewModel()
        {
            // Add available pages
            PageViewModels.Add(new MenuViewModel(this));
            PageViewModels.Add(new GameViewModel(this));
            PageViewModels.Add(new OptionsViewModel(this));
            PageViewModels.Add(new RulesViewModel(this));

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
        }



        #region Properties
        public string Name
        {
            get {return name; }
        }

        public DelegateCommand ChangePageToMenuShortcut
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new DelegateCommand(
                        p => ChangePageTo("MenuViewModel"));
                }

                return _changePageCommand;
            }
        }

        public DelegateCommand ChangePageToGameShortcut
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new DelegateCommand(
                        p => ChangePageTo("GameViewModel"));
                }

                return _changePageCommand;
            }
        }

        public DelegateCommand ChangePageToRulesShortcut
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new DelegateCommand(
                        p => ChangePageTo("RulesViewModel"));
                }

                return _changePageCommand;
            }
        }

        public DelegateCommand ChangePageToOptionsShortcut
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new DelegateCommand(
                        p => ChangePageTo("OptionsViewModel"));
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



        public void ChangePageTo(string name)
        {
            foreach(PageViewModel page in PageViewModels)
            {
                if(name == page.Name)
                {
                    CurrentPageViewModel = page;
                }
            }
        }
        #endregion
    }

}
