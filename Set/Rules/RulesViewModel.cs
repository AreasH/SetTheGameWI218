using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    class RulesViewModel: ObservableObject, PageViewModel
    {
        public RulesViewModel(MainWindowViewModel mainwindow)
        {
            mwvm = mainwindow;
            
        }

        #region Fields
        MainWindowViewModel mwvm;
        private string name = "RulesViewModel";


        #endregion

        #region Properties
        public string Name { get => name; }

        public Object Data { get; }


        #endregion

        #region ToMenu
        public DelegateCommand ChangeToMenuShortcut
        {
            get
            {
                return new DelegateCommand(p => ChangeToMenu());
            }
        }

        public void ChangeToMenu()
        {
            mwvm.ChangePageTo("MenuViewModel");
        }

        #endregion

        #region Methods
        public void RefreshPage()
        { }
        #endregion
    }
}
