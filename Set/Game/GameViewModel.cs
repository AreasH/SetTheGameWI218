using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Set
{
    /// <summary>
    /// This class is used to connect all game logic to the view. 
    /// </summary>
    class GameViewModel : ObservableObject, PageViewModel
    {
        public GameViewModel(MainWindowViewModel mainwindow, PageViewModel options)
        {
            mwvm = mainwindow;
            gameLogic = new Game(this, options.Data);
        }

        #region Fields
        MainWindowViewModel mwvm;
        Game gameLogic;
        private string name = "GameViewModel";
        #endregion

        #region ImageSource Strings
        string _zeroButtonImageSource;
        string _oneButtonImageSource;
        string _twoButtonImageSource;
        string _threeButtonImageSource;
        string _fourButtonImageSource;
        string _fiveButtonImageSource;
        string _sixButtonImageSource;
        string _sevenButtonImageSource;
        string _eightButtonImageSource;
        string _nineButtonImageSource;
        string _tenButtonImageSource;
        string _elevenButtonImageSource;
        #endregion

        #region ButtonSelectedStrings
        string hidden = "White";
        string visible = "SkyBlue";
        #endregion

        #region Methods

        public void RefreshPage()
        {
            gameLogic.StartNewGame();
        }

        

        public void RefreshSelection()
        {
            OnPropertyChanged("zeroButtonSelected");
            OnPropertyChanged("oneButtonSelected");
            OnPropertyChanged("twoButtonSelected");
            OnPropertyChanged("threeButtonSelected");
            OnPropertyChanged("fourButtonSelected");
            OnPropertyChanged("fiveButtonSelected");
            OnPropertyChanged("sixButtonSelected");
            OnPropertyChanged("sevenButtonSelected");
            OnPropertyChanged("eightButtonSelected");
            OnPropertyChanged("nineButtonSelected");
            OnPropertyChanged("tenButtonSelected");
            OnPropertyChanged("elevenButtonSelected");
        }

        #endregion

        #region Button Selected Properties
        public string zeroButtonSelected
        {
            get
            {
                string temp = gameLogic.SetCards[0].Selected == true ? visible : hidden;
                return temp;
            }
        }

        public string oneButtonSelected
        {
            get
            {
                string temp = gameLogic.SetCards[1].Selected == true ? visible : hidden;
                return temp;
            }
        }

        public string twoButtonSelected
        {
            get
            {
                string temp = gameLogic.SetCards[2].Selected == true ? visible : hidden;
                return temp;
            }
        }

        public string threeButtonSelected
        {
            get
            {
                string temp = gameLogic.SetCards[3].Selected == true ? visible : hidden;
                return temp;
            }
        }

        public string fourButtonSelected
        {
            get
            {
                string temp = gameLogic.SetCards[4].Selected == true ? visible : hidden;
                return temp;
            }
        }

        public string fiveButtonSelected
        {
            get
            {
                string temp = gameLogic.SetCards[5].Selected == true ? visible : hidden;
                return temp;
            }
        }

        public string sixButtonSelected
        {
            get
            {
                string temp = gameLogic.SetCards[6].Selected == true ? visible : hidden;
                return temp;
            }
        }

        public string sevenButtonSelected
        {
            get
            {
                string temp = gameLogic.SetCards[7].Selected == true ? visible : hidden;
                return temp;
            }
        }

        public string eightButtonSelected
        {
            get
            {
                string temp = gameLogic.SetCards[8].Selected == true ? visible : hidden;
                return temp;
            }
        }

        public string nineButtonSelected
        {
            get
            {
                string temp = gameLogic.SetCards[9].Selected == true ? visible : hidden;
                return temp;
            }
        }

        public string tenButtonSelected
        {
            get
            {
                string temp = gameLogic.SetCards[10].Selected == true ? visible : hidden;
                return temp;
            }
        }

        public string elevenButtonSelected
        {
            get
            {
                string temp = gameLogic.SetCards[11].Selected == true ? visible : hidden;
                return temp;
            }
        }

        #endregion

        #region Button Pressed Properties

        public DelegateCommand zeroButton
        {
            get { return new DelegateCommand(p => gameLogic.CardSelected(0)); }
        }

        public DelegateCommand oneButton
        {
            get { return new DelegateCommand(p => gameLogic.CardSelected(1)); }
        }

        public DelegateCommand twoButton
        {
            get { return new DelegateCommand(p => gameLogic.CardSelected(2)); }
        }

        public DelegateCommand threeButton
        {
            get { return new DelegateCommand(p => gameLogic.CardSelected(3)); }
        }

        public DelegateCommand fourButton
        {
            get { return new DelegateCommand(p => gameLogic.CardSelected(4)); }
        }

        public DelegateCommand fiveButton
        {
            get { return new DelegateCommand(p => gameLogic.CardSelected(5)); }
        }

        public DelegateCommand sixButton
        {
            get { return new DelegateCommand(p => gameLogic.CardSelected(6)); }
        }

        public DelegateCommand sevenButton
        {
            get { return new DelegateCommand(p => gameLogic.CardSelected(7)); }
        }

        public DelegateCommand eightButton
        {
            get { return new DelegateCommand(p => gameLogic.CardSelected(8)); }
        }

        public DelegateCommand nineButton
        {
            get { return new DelegateCommand(p => gameLogic.CardSelected(9)); }
        }

        public DelegateCommand tenButton
        {
            get { return new DelegateCommand(p => gameLogic.CardSelected(10)); }
        }

        public DelegateCommand elevenButton
        {
            get { return new DelegateCommand(p => gameLogic.CardSelected(11)); }
        }
        #endregion

        #region Image Source Properties

        public string zeroButtonImageSource
        {
            get { return _zeroButtonImageSource; }
            set
            {
                if (zeroButtonImageSource != value)
                {
                    _zeroButtonImageSource = value;
                    OnPropertyChanged("zeroButtonImageSource");
                }
            }
        }

        public string oneButtonImageSource
        {
            get { return _oneButtonImageSource; }
            set
            {
                if (oneButtonImageSource != value)
                {
                    _oneButtonImageSource = value;
                    OnPropertyChanged("oneButtonImageSource");
                }
            }
        }

        public string twoButtonImageSource
        {
            get { return _twoButtonImageSource; }
            set
            {
                if (twoButtonImageSource != value)
                {
                    _twoButtonImageSource = value;
                    OnPropertyChanged("twoButtonImageSource");

                }
            }
        }

        public string threeButtonImageSource
        {
            get { return _threeButtonImageSource; }
            set
            {
                if (threeButtonImageSource != value)
                {
                    _threeButtonImageSource = value;
                    OnPropertyChanged("threeButtonImageSource");
                }
            }
        }

        public string fourButtonImageSource
        {
            get { return _fourButtonImageSource; }
            set
            {
                if (fourButtonImageSource != value)
                {
                    _fourButtonImageSource = value;
                    OnPropertyChanged("fourButtonImageSource");
                }
            }
        }

        public string fiveButtonImageSource
        {
            get { return _fiveButtonImageSource; }
            set
            {
                if (fiveButtonImageSource != value)
                {
                    _fiveButtonImageSource = value;
                    OnPropertyChanged("fiveButtonImageSource");
                }

            }
        }

        public string sixButtonImageSource
        {
            get { return _sixButtonImageSource; }
            set
            {
                if (sixButtonImageSource != value)
                {
                    _sixButtonImageSource = value;
                    OnPropertyChanged("sixButtonImageSource");
                }
            }
        }

        public string sevenButtonImageSource
        {
            get { return _sevenButtonImageSource; }
            set
            {
                if (sevenButtonImageSource != value)
                {
                    _sevenButtonImageSource = value;
                    OnPropertyChanged("sevenButtonImageSource");
                }
            }
        }

        public string eightButtonImageSource
        {
            get { return _eightButtonImageSource; }
            set
            {
                if (eightButtonImageSource != value)
                {
                    _eightButtonImageSource = value;
                    OnPropertyChanged("sevenButtonImageSource");
                }
            }
        }

        public string nineButtonImageSource
        {
            get { return _nineButtonImageSource; }
            set
            {
                if (nineButtonImageSource != value)
                {
                    _nineButtonImageSource = value;
                    OnPropertyChanged("nineButtonImageSource");
                }
            }
        }

        public string tenButtonImageSource
        {
            get { return _tenButtonImageSource; }
            set
            {
                if (tenButtonImageSource != value)
                {
                    _tenButtonImageSource = value;
                    OnPropertyChanged("tenButtonImageSource");
                }
            }
        }

        public string elevenButtonImageSource
        {
            get { return _elevenButtonImageSource; }
            set
            {
                if (elevenButtonImageSource != value)
                {
                    _elevenButtonImageSource = value;
                    OnPropertyChanged("elevenButtonImageSource");
                }
            }
        }

        public void UpdateFoundSet()
        {
            OnPropertyChanged("firstCardFoundSetImage");
            OnPropertyChanged("secondCardFoundSetImage");
            OnPropertyChanged("thirdCardFoundSetImage");
        }

        public string firstCardFoundSetImage
        {
            get { return gameLogic.LastFoundSet == null ? "Kein Set gefunden" : gameLogic.LastFoundSet[0].ImageSource; }
        }

        public string secondCardFoundSetImage
        {
            get { return gameLogic.LastFoundSet == null ? "Kein Set gefunden" : gameLogic.LastFoundSet[1].ImageSource; }
        }
        
        public string thirdCardFoundSetImage
        {
            get { return gameLogic.LastFoundSet == null ? "Kein Set gefunden" : gameLogic.LastFoundSet[2].ImageSource; }
        }


        #endregion

        #region Normal Properties
        public string Name { get => name; }

        public Object Data { get { return gameLogic; } }
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

        #region GameInfo Properties
        public void UpdateTime()
        {
            OnPropertyChanged("Time");
        }

        public string Time
        {
            get { return gameLogic.Time; }
        }

        public void UpdateCardsLeft()
        {
            OnPropertyChanged("CardsLeft");
        }

        public string CardsLeft
        {
            get { return "Noch " + gameLogic.Playset1.Count().ToString() + " Karten von 81 verbleibend"; }
        }


        public string numberOfPossibleSets
        {
            get { return gameLogic.FindOutNumberOfPossibleSets().ToString(); }
        }

        public void UpdateNumberOfPossibleSets()
        {
            OnPropertyChanged("numberOfPossibleSets");
        }

        public void UpdateFoundSets()
        {
            OnPropertyChanged("FoundSets");
        }

        public string FoundSets
        {
            get { return "Schon " +gameLogic.FoundSets.ToString()+ " Sets gefunden!"; }
        }
        #endregion





    }
}
