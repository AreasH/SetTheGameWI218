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
            _ColorSource = new List<string>();
            _ColorSource.Add("blue");
            _ColorSource.Add("green");
            _ColorSource.Add("red");
            _ColorSource.Add("brown");
            _ColorSource.Add("grey");
            _ColorSource.Add("purple");
            _ColorSource.Add("orange");

            FirstSelectedColor = "red";  //Default colors for the cards of the playset
            SecondSelectedColor = "green";
            ThirdSelectedColor = "blue"; //Contains the colors of the playset cards.

        }

        #region Fields
        MainWindowViewModel mwvm;
        List<string> color;  //List which contains the preset colors.
        private string name = "OptionsViewModel";

        private List<string> _ColorSource;
        string _firstSelectedColor;
        string _secondSelectedColor;
        string _thirdSelectedColor;
        #endregion

        #region Properties


        public List<string> Color
        { //Property for the list with colors, only allows for three colors to be saved.
            get
            {
                if (color == null)
                    color = new List<string>();
                color.Clear();
                color.Add(FirstSelectedColor);
                color.Add(SecondSelectedColor);
                color.Add(ThirdSelectedColor);
                return color;
            }
        }

        public string FirstSelectedColor
        { get { return _firstSelectedColor; }
          set { _firstSelectedColor = value;
                OnPropertyChanged("FirstSelectedColor");
              }
        }

        public string SecondSelectedColor
        {
            get { return _secondSelectedColor; }
            set
            {
                _secondSelectedColor = value;
                OnPropertyChanged("SecondSelectedColor");
            }
         }

        public string ThirdSelectedColor
        {
            get { return _thirdSelectedColor; }
            set
            {
                _thirdSelectedColor = value;
                OnPropertyChanged("ThirdSelectedColor");
            }
        }


        public List<string> ColorSource
        {
            get { return _ColorSource; }
          
        }

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
