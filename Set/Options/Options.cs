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
        }

        OptionsViewModel viewModel;

        public List<string> Color //Property for the list with colors, only allows for three colors to be saved.
        { 
            get { return color; }
            set { color = value; }
        }

        #region Properties
        public string FirstSelectedColor { get => _firstSelectedColor; set => _firstSelectedColor = value; }
        public string SecondSelectedColor { get => _secondSelectedColor; set => _secondSelectedColor = value; }
        public string ThirdSelectedColor { get => _thirdSelectedColor; set => _thirdSelectedColor = value; }
        public List<string> ColorSource { get => _ColorSource; set => _ColorSource = value; }
        #endregion

        #region Methods

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
            Color.Add(FirstSelectedColor);
            Color.Add(SecondSelectedColor);
            Color.Add(ThirdSelectedColor);
        }
        #endregion
    }
}
