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
        
        private string name = "MainWindowViewModel";
        private PageViewModel _currentPageViewModel;
        private List<PageViewModel> _pageViewModels;
        private IMsgBoxService messageService;

        public MainWindowViewModel()
        {
            // Add available pages
            messageService = new MsgBoxService();
            PageViewModels.Add(new MenuViewModel(this));
            PageViewModels.Add(new OptionsViewModel(this));
            PageViewModels.Add(new GameViewModel(this, PageViewModels[1], messageService));
            PageViewModels.Add(new RulesViewModel(this));

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
        }



        #region Properties
        public string Name
        {
            get {return name; }
        }

        public Object Data { get; }


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

        public void RefreshPage()
        { }

        public void ChangePageTo(string name)
        {
            foreach(PageViewModel page in PageViewModels)
            {
                if(name == page.Name)
                {
                    page.RefreshPage();
                    CurrentPageViewModel = page;
                }
            }
        }
        #endregion
    }

}
