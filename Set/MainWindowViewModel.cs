﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Input;

namespace Set
{
    class MainWindowViewModel: ObservableObject
    {

        private DelegateCommand _changePageCommand;

        private PageViewModel _currentPageViewModel;
        private List<PageViewModel> _pageViewModels;

        public MainWindowViewModel()
        {
            // Add available pages
            PageViewModels.Add(new MenuViewModel());
            PageViewModels.Add(new GameViewModel());

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
        }

        #region Properties
        public DelegateCommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new DelegateCommand(
                        p => ChangeViewModel());
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

        private void ChangeViewModel()
        {
            CurrentPageViewModel = _currentPageViewModel == PageViewModels[0] ? PageViewModels[1] : PageViewModels[0];
        }

        #endregion
    }

}
