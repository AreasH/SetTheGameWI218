using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    class OptionsViewModel : ObservableObject, PageViewModel
    {

        public OptionsViewModel(MainWindowViewModel mainwindow)
        {
            mwvm = mainwindow;
            data = new Options(this);
            FirstSelectedColor = "red";  //Default colors for the cards of the playset
            SecondSelectedColor = "green";
            ThirdSelectedColor = "blue"; //Contains the colors of the playset cards.

        }

        #region Fields
        MainWindowViewModel mwvm;
        Options data;
        private string name = "OptionsViewModel";
        #endregion

        #region Properties

        public List<string> ColorSource
        { get { return data.ColorSource; } }

        public string FirstSelectedColor
        { get { return data.FirstSelectedColor; }
          set { data.FirstSelectedColor = value;
                OnPropertyChanged("FirstSelectedColor");
                OnPropertyChanged("SaveColorsCommandVisibility");
            }
        }

        public string SecondSelectedColor
        {
            get { return data.SecondSelectedColor; }
            set
            {
                data.SecondSelectedColor = value;
                OnPropertyChanged("SecondSelectedColor");
                OnPropertyChanged("SaveColorsCommandVisibility");
            }
         }

        public string ThirdSelectedColor
        {
            get { return data.ThirdSelectedColor; }
            set
            {
                data.ThirdSelectedColor = value;
                OnPropertyChanged("ThirdSelectedColor");
                OnPropertyChanged("SaveColorsCommandVisibility");
            }
        }

        public bool SaveColorsCommandVisibility
        { get { return data.AreColorsDifferent(); } }

        public DelegateCommand SaveColorsCommand
        { get { return new DelegateCommand(param => data.SaveColors()); } }

        public List<string> GameModes { get => data.GameModes; set => data.GameModes = value; }

        public string SelectedGameMode { get => data.SelectedGameMode; set => data.SelectedGameMode = value; }

        public Object Data
        {  get { return data; } }

        public string Name { get => name; set => name = value; }

        #endregion

        #region methods
        public void RefreshPage()
        {
            data.RefreshOptions();
        }
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
