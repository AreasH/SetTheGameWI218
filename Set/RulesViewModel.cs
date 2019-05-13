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

        public string Name { get => name; }
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
    }
}
