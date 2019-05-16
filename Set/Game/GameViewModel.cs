using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    /// <summary>
    /// This class is used to connect all game logic to the view. 
    /// </summary>
    class GameViewModel: ObservableObject, PageViewModel
    {
        public GameViewModel(MainWindowViewModel mainwindow)
        {
            mwvm = mainwindow;
            gameLogic = new Game(this);
            

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

        #region Button Pressed Properties

        public DelegateCommand zeroButton
        {
            get {return new DelegateCommand(p => gameLogic.CardSelected(0)) ; }
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



        #endregion

        #region Normal Properties
        public string Name { get => name;}

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
