using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    class Options
    {

        #region fields
        List<string> color;  //List which contains the selected colors.
        private List<string> _ColorSource; //List that contains all colors.
        string _firstSelectedColor;
        string _secondSelectedColor;
        string _thirdSelectedColor;

        OptionsViewModel viewModel;
        private List<string> _gameModes;
        private string _selectedGameMode;
        #endregion

        public Options(OptionsViewModel ovm)
        {
            viewModel = ovm;
            ColorSource = new List<string>();
            ColorSource.Add("blue");
            ColorSource.Add("green");
            ColorSource.Add("red");
            ColorSource.Add("brown");
            ColorSource.Add("grey");
            ColorSource.Add("purple");
            ColorSource.Add("orange");

            FirstSelectedColor = ColorSource[0];
            SecondSelectedColor = ColorSource[1];
            ThirdSelectedColor = ColorSource[2];
            SaveColors();

            GameModes = new List<string>();
            GameModes.Add("Normal");
            GameModes.Add("Gegen die Zeit (5 min)");
            GameModes.Add("Hardcore");
            SelectedGameMode = GameModes[0];

        }


        public List<string> Color //Property for the list with colors, only allows for three colors to be saved.
        { 
            get { return color; }
            set { color = value; }
        }

        #region Properties
        public string FirstSelectedColor { get => _firstSelectedColor; set => _firstSelectedColor = value; }
        public string SecondSelectedColor { get => _secondSelectedColor; set => _secondSelectedColor = value; }
        public string ThirdSelectedColor { get => _thirdSelectedColor; set => _thirdSelectedColor = value; }
        public List<string> GameModes { get => _gameModes; set => _gameModes = value; }
        public string SelectedGameMode { get => _selectedGameMode; set => _selectedGameMode = value; }
        public List<string> ColorSource { get => _ColorSource; set => _ColorSource = value; }
        #endregion

        #region Methods
        public void RefreshOptions()
        {
            FirstSelectedColor = Color[0];
            SecondSelectedColor = Color[1];
            ThirdSelectedColor = Color[2];
            SaveColors();
        }

        public bool AreColorsDifferent()
        {
            if (FirstSelectedColor == SecondSelectedColor || SecondSelectedColor == ThirdSelectedColor || ThirdSelectedColor == FirstSelectedColor)
                return false;
            return true;
        }

        public void SaveColors()
        {
            if (Color == null)
            {
                Color = new List<string>();
            }
            Color.Clear();
            Color.Add(FirstSelectedColor);
            Color.Add(SecondSelectedColor);
            Color.Add(ThirdSelectedColor);
        }
        #endregion
    }
}
