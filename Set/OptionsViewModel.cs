using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    class OptionsViewModel: ObservableObject, PageViewModel
    {
        
        public OptionsViewModel(MainWindowViewModel mainwindow)
        {
            mwvm = mainwindow;
            color = new List<string>();
            color.Add("red"); //Default colors for the cards of the playset
            color.Add("green");
            color.Add("blue");
        }

        #region Fields
        MainWindowViewModel mwvm;
        List<string> color;  //List which contains the preset colors.
        private string name = "OptionsViewModel";
        #endregion

        #region Properties
        public List<string> Color { //Property for the list with colors
            get=>color;
            set=> color = value; }


        public string Name { get => name; set => name = value; }

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
