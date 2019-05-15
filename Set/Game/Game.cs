using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{

    class Game
    {
        GameViewModel _gameViewModel;
        HashSet<Card> AllCards;  //Includes really all Cards possible, even if not used in this game instance
        HashSet<Card> Playset; //Includes only the 81 Selected Cards that are used for this game instance
        HashSet<Card> foundSets; // Includes all Cards that were found to be a set (found by the player)
        HashSet<Card> removedCards; //All Cards that were removed due to the player not being able to find a set
        List<Card> setCards; //The twelve cards that are actually up for finding a set inside them.
        List<Card> selectedCards; //The cards selected by the player -- not allowed to be more than 3.
        int NumberOfPossibleSets;
        int CountSelectedCards = 0;

        public Game(GameViewModel g)
        {
            _gameViewModel = g;
            setCards = new List<Card>();
            Card c = new Card("diamond", "blue", "empty", "1", false, "Images/diamond_blue_empty_1.png");
            setCards.Add(c);
            setImageSource();
        }

        public void setImageSource() //Sets the Image Source of the Button in the ViewModel by using the ButtonImageSource properties
        {
            _gameViewModel.zeroButtonImageSource    = setCards[0].ImageSource;
            /*
            _gameViewModel.oneButtonImageSource     = setCards[1].ImageSource;
            _gameViewModel.twoButtonImageSource     = setCards[2].ImageSource;
            _gameViewModel.threeButtonImageSource   = setCards[3].ImageSource;
            _gameViewModel.fourButtonImageSource    = setCards[4].ImageSource;
            _gameViewModel.fiveButtonImageSource    = setCards[5].ImageSource;
            _gameViewModel.sixButtonImageSource     = setCards[6].ImageSource;
            _gameViewModel.sevenButtonImageSource   = setCards[7].ImageSource;
            _gameViewModel.eightButtonImageSource   = setCards[8].ImageSource;
            _gameViewModel.nineButtonImageSource    = setCards[9].ImageSource;
            _gameViewModel.tenButtonImageSource     = setCards[10].ImageSource;
            _gameViewModel.elevenButtonImageSource  = setCards[11].ImageSource;
            */

        }

        public void CardSelected(int i) //Card at index i from setCards is added to the selectedCards.
        {
            selectedCards.Add(setCards[i]);
            if(selectedCards.Count == 3)
            {
                IsASet("cardone", "cardtwo", "cardthree");
                selectedCards.Clear();
            }
        }

        public Boolean IsASet(String first, String second, String third)  //Check if Selected Cards are a Set using the methods below
        {


            if ((StringAllSame(first, second, third) || StringAllDifferent(first, second, third)) && (StringAllSame(first, second, third) || StringAllDifferent(first, second, third)) && (StringAllSame(first, second, third) || StringAllDifferent(first, second, third)) && (StringAllSame(first, second, third) || StringAllDifferent(first, second, third)))
            {
                return true;
            }

            else
            {

            }

            return false;

        }

        public Boolean StringAllSame(String first, String second, String third) //Generic check if the cards' attribute values are the same
        {
            if (first.Equals(second) && second.Equals(third))
            {

                return true;

            }

            return false;
        }
         
        public Boolean StringAllDifferent(String first, String second, String third) //Generic check if the cards' attribute values are all different
        {
            if ((first.Equals(second) == false) && (second.Equals(third) == false) && (third.Equals(first) == false))
            {

                return true;

            }

            return false;
        }

    }


}