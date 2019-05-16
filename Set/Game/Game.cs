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
            initializeCards();
            setImageSource();
        }

        public void initializeCards()
        {
            //Build AllCards
            AllCards = new HashSet<Card>();
            AllCards.Add(new Card("Images/diamond_blue_empty_1.png"));
            AllCards.Add(new Card("Images/diamond_blue_empty_2.png"));
            AllCards.Add(new Card("Images/diamond_blue_empty_3.png"));
            AllCards.Add(new Card("Images/diamond_blue_filled_1.png"));
            AllCards.Add(new Card("Images/diamond_blue_filled_2.png"));
            AllCards.Add(new Card("Images/diamond_blue_filled_3.png"));
            AllCards.Add(new Card("Images/diamond_blue_striped_1.png"));
            AllCards.Add(new Card("Images/diamond_blue_striped_2.png"));
            AllCards.Add(new Card("Images/diamond_blue_striped_3.png"));
            AllCards.Add(new Card("Images/diamond_brown_empty_1.png"));
            AllCards.Add(new Card("Images/diamond_brown_empty_2.png"));
            AllCards.Add(new Card("Images/diamond_brown_empty_3.png"));
            AllCards.Add(new Card("Images/diamond_brown_filled_1.png"));
            AllCards.Add(new Card("Images/diamond_brown_filled_2.png"));
            AllCards.Add(new Card("Images/diamond_brown_filled_3.png"));
            AllCards.Add(new Card("Images/diamond_brown_striped_1.png"));
            AllCards.Add(new Card("Images/diamond_brown_striped_2.png"));
            AllCards.Add(new Card("Images/diamond_brown_striped_3.png"));
            AllCards.Add(new Card("Images/diamond_green_empty_1.png"));
            AllCards.Add(new Card("Images/diamond_green_empty_2.png"));
            AllCards.Add(new Card("Images/diamond_green_empty_3.png"));
            AllCards.Add(new Card("Images/diamond_green_filled_1.png"));
            AllCards.Add(new Card("Images/diamond_green_filled_2.png"));
            AllCards.Add(new Card("Images/diamond_green_filled_3.png"));
            AllCards.Add(new Card("Images/diamond_green_striped_1.png"));
            AllCards.Add(new Card("Images/diamond_green_striped_2.png"));
            AllCards.Add(new Card("Images/diamond_green_striped_3.png"));
            AllCards.Add(new Card("Images/diamond_grey_empty_1.png"));
            AllCards.Add(new Card("Images/diamond_grey_empty_2.png"));
            AllCards.Add(new Card("Images/diamond_grey_empty_3.png"));
            AllCards.Add(new Card("Images/diamond_grey_filled_1.png"));
            AllCards.Add(new Card("Images/diamond_grey_filled_2.png"));
            AllCards.Add(new Card("Images/diamond_grey_filled_3.png"));
            AllCards.Add(new Card("Images/diamond_grey_striped_1.png"));
            AllCards.Add(new Card("Images/diamond_grey_striped_2.png"));
            AllCards.Add(new Card("Images/diamond_grey_striped_3.png"));
            AllCards.Add(new Card("Images/diamond_orange_empty_1.png"));
            AllCards.Add(new Card("Images/diamond_orange_empty_2.png"));
            AllCards.Add(new Card("Images/diamond_orange_empty_3.png"));
            AllCards.Add(new Card("Images/diamond_orange_filled_1.png"));
            AllCards.Add(new Card("Images/diamond_orange_filled_2.png"));
            AllCards.Add(new Card("Images/diamond_orange_filled_3.png"));
            AllCards.Add(new Card("Images/diamond_orange_striped_1.png"));
            AllCards.Add(new Card("Images/diamond_orange_striped_2.png"));
            AllCards.Add(new Card("Images/diamond_orange_striped_3.png"));
            AllCards.Add(new Card("Images/diamond_purple_empty_1.png"));
            AllCards.Add(new Card("Images/diamond_purple_empty_2.png"));
            AllCards.Add(new Card("Images/diamond_purple_empty_3.png"));
            AllCards.Add(new Card("Images/diamond_purple_filled_1.png"));
            AllCards.Add(new Card("Images/diamond_purple_filled_2.png"));
            AllCards.Add(new Card("Images/diamond_purple_filled_3.png"));
            AllCards.Add(new Card("Images/diamond_purple_striped_1.png"));
            AllCards.Add(new Card("Images/diamond_purple_striped_2.png"));
            AllCards.Add(new Card("Images/diamond_purple_striped_3.png"));
            AllCards.Add(new Card("Images/diamond_red_empty_1.png"));
            AllCards.Add(new Card("Images/diamond_red_empty_2.png"));
            AllCards.Add(new Card("Images/diamond_red_empty_3.png"));
            AllCards.Add(new Card("Images/diamond_red_filled_1.png"));
            AllCards.Add(new Card("Images/diamond_red_filled_2.png"));
            AllCards.Add(new Card("Images/diamond_red_filled_3.png"));
            AllCards.Add(new Card("Images/diamond_red_striped_1.png"));
            AllCards.Add(new Card("Images/diamond_red_striped_2.png"));
            AllCards.Add(new Card("Images/diamond_red_striped_3.png"));
            AllCards.Add(new Card("Images/ellipse_blue_empty_1.png"));
            AllCards.Add(new Card("Images/ellipse_blue_empty_2.png"));
            AllCards.Add(new Card("Images/ellipse_blue_empty_3.png"));
            AllCards.Add(new Card("Images/ellipse_blue_filled_1.png"));
            AllCards.Add(new Card("Images/ellipse_blue_filled_2.png"));
            AllCards.Add(new Card("Images/ellipse_blue_filled_3.png"));
            AllCards.Add(new Card("Images/ellipse_blue_striped_1.png"));
            AllCards.Add(new Card("Images/ellipse_blue_striped_2.png"));
            AllCards.Add(new Card("Images/ellipse_blue_striped_3.png"));
            AllCards.Add(new Card("Images/ellipse_brown_empty_1.png"));
            AllCards.Add(new Card("Images/ellipse_brown_empty_2.png"));
            AllCards.Add(new Card("Images/ellipse_brown_empty_3.png"));
            AllCards.Add(new Card("Images/ellipse_brown_filled_1.png"));
            AllCards.Add(new Card("Images/ellipse_brown_filled_2.png"));
            AllCards.Add(new Card("Images/ellipse_brown_filled_3.png"));
            AllCards.Add(new Card("Images/ellipse_brown_striped_1.png"));
            AllCards.Add(new Card("Images/ellipse_brown_striped_2.png"));
            AllCards.Add(new Card("Images/ellipse_brown_striped_3.png"));
            AllCards.Add(new Card("Images/ellipse_green_empty_1.png"));
            AllCards.Add(new Card("Images/ellipse_green_empty_2.png"));
            AllCards.Add(new Card("Images/ellipse_green_empty_3.png"));
            AllCards.Add(new Card("Images/ellipse_green_filled_1.png"));
            AllCards.Add(new Card("Images/ellipse_green_filled_2.png"));
            AllCards.Add(new Card("Images/ellipse_green_filled_3.png"));
            AllCards.Add(new Card("Images/ellipse_green_striped_1.png"));
            AllCards.Add(new Card("Images/ellipse_green_striped_2.png"));
            AllCards.Add(new Card("Images/ellipse_green_striped_3.png"));
            AllCards.Add(new Card("Images/ellipse_grey_empty_1.png"));
            AllCards.Add(new Card("Images/ellipse_grey_empty_2.png"));
            AllCards.Add(new Card("Images/ellipse_grey_empty_3.png"));
            AllCards.Add(new Card("Images/ellipse_grey_filled_1.png"));
            AllCards.Add(new Card("Images/ellipse_grey_filled_2.png"));
            AllCards.Add(new Card("Images/ellipse_grey_filled_3.png"));
            AllCards.Add(new Card("Images/ellipse_grey_striped_1.png"));
            AllCards.Add(new Card("Images/ellipse_grey_striped_2.png"));
            AllCards.Add(new Card("Images/ellipse_grey_striped_3.png"));
            AllCards.Add(new Card("Images/ellipse_orange_empty_1.png"));
            AllCards.Add(new Card("Images/ellipse_orange_empty_2.png"));
            AllCards.Add(new Card("Images/ellipse_orange_empty_3.png"));
            AllCards.Add(new Card("Images/ellipse_orange_filled_1.png"));
            AllCards.Add(new Card("Images/ellipse_orange_filled_2.png"));
            AllCards.Add(new Card("Images/ellipse_orange_filled_3.png"));
            AllCards.Add(new Card("Images/ellipse_orange_striped_1.png"));
            AllCards.Add(new Card("Images/ellipse_orange_striped_2.png"));
            AllCards.Add(new Card("Images/ellipse_orange_striped_3.png"));
            AllCards.Add(new Card("Images/ellipse_purple_empty_1.png"));
            AllCards.Add(new Card("Images/ellipse_purple_empty_2.png"));
            AllCards.Add(new Card("Images/ellipse_purple_empty_3.png"));
            AllCards.Add(new Card("Images/ellipse_purple_filled_1.png"));
            AllCards.Add(new Card("Images/ellipse_purple_filled_2.png"));
            AllCards.Add(new Card("Images/ellipse_purple_filled_3.png"));
            AllCards.Add(new Card("Images/ellipse_purple_striped_1.png"));
            AllCards.Add(new Card("Images/ellipse_purple_striped_2.png"));
            AllCards.Add(new Card("Images/ellipse_purple_striped_3.png"));
            AllCards.Add(new Card("Images/ellipse_red_empty_1.png"));
            AllCards.Add(new Card("Images/ellipse_red_empty_2.png"));
            AllCards.Add(new Card("Images/ellipse_red_empty_3.png"));
            AllCards.Add(new Card("Images/ellipse_red_filled_1.png"));
            AllCards.Add(new Card("Images/ellipse_red_filled_2.png"));
            AllCards.Add(new Card("Images/ellipse_red_filled_3.png"));
            AllCards.Add(new Card("Images/ellipse_red_striped_1.png"));
            AllCards.Add(new Card("Images/ellipse_red_striped_2.png"));
            AllCards.Add(new Card("Images/ellipse_red_striped_3.png"));
            AllCards.Add(new Card("Images/square_blue_empty_1.png"));
            AllCards.Add(new Card("Images/square_blue_empty_2.png"));
            AllCards.Add(new Card("Images/square_blue_empty_3.png"));
            AllCards.Add(new Card("Images/square_blue_filled_1.png"));
            AllCards.Add(new Card("Images/square_blue_filled_2.png"));
            AllCards.Add(new Card("Images/square_blue_filled_3.png"));
            AllCards.Add(new Card("Images/square_blue_striped_1.png"));
            AllCards.Add(new Card("Images/square_blue_striped_2.png"));
            AllCards.Add(new Card("Images/square_blue_striped_3.png"));
            AllCards.Add(new Card("Images/square_brown_empty_1.png"));
            AllCards.Add(new Card("Images/square_brown_empty_2.png"));
            AllCards.Add(new Card("Images/square_brown_empty_3.png"));
            AllCards.Add(new Card("Images/square_brown_filled_1.png"));
            AllCards.Add(new Card("Images/square_brown_filled_2.png"));
            AllCards.Add(new Card("Images/square_brown_filled_3.png"));
            AllCards.Add(new Card("Images/square_brown_striped_1.png"));
            AllCards.Add(new Card("Images/square_brown_striped_2.png"));
            AllCards.Add(new Card("Images/square_brown_striped_3.png"));
            AllCards.Add(new Card("Images/square_green_empty_1.png"));
            AllCards.Add(new Card("Images/square_green_empty_2.png"));
            AllCards.Add(new Card("Images/square_green_empty_3.png"));
            AllCards.Add(new Card("Images/square_green_filled_1.png"));
            AllCards.Add(new Card("Images/square_green_filled_2.png"));
            AllCards.Add(new Card("Images/square_green_filled_3.png"));
            AllCards.Add(new Card("Images/square_green_striped_1.png"));
            AllCards.Add(new Card("Images/square_green_striped_2.png"));
            AllCards.Add(new Card("Images/square_green_striped_3.png"));
            AllCards.Add(new Card("Images/square_grey_empty_1.png"));
            AllCards.Add(new Card("Images/square_grey_empty_2.png"));
            AllCards.Add(new Card("Images/square_grey_empty_3.png"));
            AllCards.Add(new Card("Images/square_grey_filled_1.png"));
            AllCards.Add(new Card("Images/square_grey_filled_2.png"));
            AllCards.Add(new Card("Images/square_grey_filled_3.png"));
            AllCards.Add(new Card("Images/square_grey_striped_1.png"));
            AllCards.Add(new Card("Images/square_grey_striped_2.png"));
            AllCards.Add(new Card("Images/square_grey_striped_3.png"));
            AllCards.Add(new Card("Images/square_orange_empty_1.png"));
            AllCards.Add(new Card("Images/square_orange_empty_2.png"));
            AllCards.Add(new Card("Images/square_orange_empty_3.png"));
            AllCards.Add(new Card("Images/square_orange_filled_1.png"));
            AllCards.Add(new Card("Images/square_orange_filled_2.png"));
            AllCards.Add(new Card("Images/square_orange_filled_3.png"));
            AllCards.Add(new Card("Images/square_orange_striped_1.png"));
            AllCards.Add(new Card("Images/square_orange_striped_2.png"));
            AllCards.Add(new Card("Images/square_orange_striped_3.png"));
            AllCards.Add(new Card("Images/square_purple_empty_1.png"));
            AllCards.Add(new Card("Images/square_purple_empty_2.png"));
            AllCards.Add(new Card("Images/square_purple_empty_3.png"));
            AllCards.Add(new Card("Images/square_purple_filled_1.png"));
            AllCards.Add(new Card("Images/square_purple_filled_2.png"));
            AllCards.Add(new Card("Images/square_purple_filled_3.png"));
            AllCards.Add(new Card("Images/square_purple_striped_1.png"));
            AllCards.Add(new Card("Images/square_purple_striped_2.png"));
            AllCards.Add(new Card("Images/square_purple_striped_3.png"));
            AllCards.Add(new Card("Images/square_red_empty_1.png"));
            AllCards.Add(new Card("Images/square_red_empty_2.png"));
            AllCards.Add(new Card("Images/square_red_empty_3.png"));
            AllCards.Add(new Card("Images/square_red_filled_1.png"));
            AllCards.Add(new Card("Images/square_red_filled_2.png"));
            AllCards.Add(new Card("Images/square_red_filled_3.png"));
            AllCards.Add(new Card("Images/square_red_striped_1.png"));
            AllCards.Add(new Card("Images/square_red_striped_2.png"));
            AllCards.Add(new Card("Images/square_red_striped_3.png"));
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