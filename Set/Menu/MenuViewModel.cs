using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        private string name = "MenuViewModel";
        #endregion
        /// <summary>
        /// This region is used for all the bindings in the view.
        /// </summary>
        #region Properties 
        public DelegateCommand StartNewGameCommand
        {
            get { return new DelegateCommand(param => StartNewGame()); }
        }

        public DelegateCommand OptionsCommand
        {
            get { return new DelegateCommand(param => OpenOptions()); }
        }
        public DelegateCommand RulesCommand
        {
            get { return new DelegateCommand(param => OpenRules()); }
        }
        public DelegateCommand ExitCommand
        {
            get { return new DelegateCommand(param => ExitProgram()); }
        }

        public string Name { get => name;}

        public Object Data { get; }
        #endregion

        #region Methods


        public void RefreshPage()
        { }

        public void StartNewGame()
        {
            mwvm.ChangePageTo("GameViewModel");
        }

        public void OpenOptions()
        {
            mwvm.ChangePageTo("OptionsViewModel");
        }

        public void OpenRules()
        {
            mwvm.ChangePageTo("RulesViewModel");
        }

        public void ExitProgram()
        {
            System.Environment.Exit(1);
        }


        #endregion


    }
}
