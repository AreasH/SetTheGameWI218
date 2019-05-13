using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{   
    /// <summary>
    /// This class is used to provide all functions for the menu view.
    /// </summary>
    class MenuViewModel: ObservableObject, PageViewModel
    {
        public MenuViewModel(MainWindowViewModel mainwindow)
        {
            mwvm = mainwindow;
        }

        #region Fields
        MainWindowViewModel mwvm;
        #endregion
        /// <summary>
        /// This region is used for all the bindings in the view.
        /// </summary>
        #region Properties 
        public DelegateCommand StartNewGameCommand
        {
            get { return new DelegateCommand(param => StartNewGame()); }
        }


        #endregion 

        #region Methods
        public void StartNewGame()
        {
            mwvm.ChangePageToGame();
        }
        #endregion


    }
}
