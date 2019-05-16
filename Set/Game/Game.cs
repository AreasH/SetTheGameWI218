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

        public HashSet<Card> AllCards1 { get => AllCards; set => AllCards = value; }
        public HashSet<Card> Playset1 { get => Playset; set => Playset = value; }
        public HashSet<Card> FoundSets { get => foundSets; set => foundSets = value; }
        public HashSet<Card> RemovedCards { get => removedCards; set => removedCards = value; }
        public List<Card> SetCards { get => setCards; set => setCards = value; }
        public List<Card> SelectedCards { get => selectedCards; set => selectedCards = value; }
        public int NumberOfPossibleSets1 { get => NumberOfPossibleSets; set => NumberOfPossibleSets = value; }
        public int CountSelectedCards1 { get => CountSelectedCards; set => CountSelectedCards = value; }

        public Game(GameViewModel g)
        {
            _gameViewModel = g;
            initializeCards();
            setImageSource();
        }

        public void initializeCards()
        {
            //Build AllCards
            AllCards1 = new HashSet<Card>();
            AllCards1.Add(new Card("Images/diamond_blue_empty_1.png"));
            AllCards1.Add(new Card("Images/diamond_blue_empty_2.png"));
            AllCards1.Add(new Card("Images/diamond_blue_empty_3.png"));
            AllCards1.Add(new Card("Images/diamond_blue_filled_1.png"));
            AllCards1.Add(new Card("Images/diamond_blue_filled_2.png"));
            AllCards1.Add(new Card("Images/diamond_blue_filled_3.png"));
            AllCards1.Add(new Card("Images/diamond_blue_striped_1.png"));
            AllCards1.Add(new Card("Images/diamond_blue_striped_2.png"));
            AllCards1.Add(new Card("Images/diamond_blue_striped_3.png"));
            AllCards1.Add(new Card("Images/diamond_brown_empty_1.png"));
            AllCards1.Add(new Card("Images/diamond_brown_empty_2.png"));
            AllCards1.Add(new Card("Images/diamond_brown_empty_3.png"));
            AllCards1.Add(new Card("Images/diamond_brown_filled_1.png"));
            AllCards1.Add(new Card("Images/diamond_brown_filled_2.png"));
            AllCards1.Add(new Card("Images/diamond_brown_filled_3.png"));
            AllCards1.Add(new Card("Images/diamond_brown_striped_1.png"));
            AllCards1.Add(new Card("Images/diamond_brown_striped_2.png"));
            AllCards1.Add(new Card("Images/diamond_brown_striped_3.png"));
            AllCards1.Add(new Card("Images/diamond_green_empty_1.png"));
            AllCards1.Add(new Card("Images/diamond_green_empty_2.png"));
            AllCards1.Add(new Card("Images/diamond_green_empty_3.png"));
            AllCards1.Add(new Card("Images/diamond_green_filled_1.png"));
            AllCards1.Add(new Card("Images/diamond_green_filled_2.png"));
            AllCards1.Add(new Card("Images/diamond_green_filled_3.png"));
            AllCards1.Add(new Card("Images/diamond_green_striped_1.png"));
            AllCards1.Add(new Card("Images/diamond_green_striped_2.png"));
            AllCards1.Add(new Card("Images/diamond_green_striped_3.png"));
            AllCards1.Add(new Card("Images/diamond_grey_empty_1.png"));
            AllCards1.Add(new Card("Images/diamond_grey_empty_2.png"));
            AllCards1.Add(new Card("Images/diamond_grey_empty_3.png"));
            AllCards1.Add(new Card("Images/diamond_grey_filled_1.png"));
            AllCards1.Add(new Card("Images/diamond_grey_filled_2.png"));
            AllCards1.Add(new Card("Images/diamond_grey_filled_3.png"));
            AllCards1.Add(new Card("Images/diamond_grey_striped_1.png"));
            AllCards1.Add(new Card("Images/diamond_grey_striped_2.png"));
            AllCards1.Add(new Card("Images/diamond_grey_striped_3.png"));
            AllCards1.Add(new Card("Images/diamond_orange_empty_1.png"));
            AllCards1.Add(new Card("Images/diamond_orange_empty_2.png"));
            AllCards1.Add(new Card("Images/diamond_orange_empty_3.png"));
            AllCards1.Add(new Card("Images/diamond_orange_filled_1.png"));
            AllCards1.Add(new Card("Images/diamond_orange_filled_2.png"));
            AllCards1.Add(new Card("Images/diamond_orange_filled_3.png"));
            AllCards1.Add(new Card("Images/diamond_orange_striped_1.png"));
            AllCards1.Add(new Card("Images/diamond_orange_striped_2.png"));
            AllCards1.Add(new Card("Images/diamond_orange_striped_3.png"));
            AllCards1.Add(new Card("Images/diamond_purple_empty_1.png"));
            AllCards1.Add(new Card("Images/diamond_purple_empty_2.png"));
            AllCards1.Add(new Card("Images/diamond_purple_empty_3.png"));
            AllCards1.Add(new Card("Images/diamond_purple_filled_1.png"));
            AllCards1.Add(new Card("Images/diamond_purple_filled_2.png"));
            AllCards1.Add(new Card("Images/diamond_purple_filled_3.png"));
            AllCards1.Add(new Card("Images/diamond_purple_striped_1.png"));
            AllCards1.Add(new Card("Images/diamond_purple_striped_2.png"));
            AllCards1.Add(new Card("Images/diamond_purple_striped_3.png"));
            AllCards1.Add(new Card("Images/diamond_red_empty_1.png"));
            AllCards1.Add(new Card("Images/diamond_red_empty_2.png"));
            AllCards1.Add(new Card("Images/diamond_red_empty_3.png"));
            AllCards1.Add(new Card("Images/diamond_red_filled_1.png"));
            AllCards1.Add(new Card("Images/diamond_red_filled_2.png"));
            AllCards1.Add(new Card("Images/diamond_red_filled_3.png"));
            AllCards1.Add(new Card("Images/diamond_red_striped_1.png"));
            AllCards1.Add(new Card("Images/diamond_red_striped_2.png"));
            AllCards1.Add(new Card("Images/diamond_red_striped_3.png"));
            AllCards1.Add(new Card("Images/ellipse_blue_empty_1.png"));
            AllCards1.Add(new Card("Images/ellipse_blue_empty_2.png"));
            AllCards1.Add(new Card("Images/ellipse_blue_empty_3.png"));
            AllCards1.Add(new Card("Images/ellipse_blue_filled_1.png"));
            AllCards1.Add(new Card("Images/ellipse_blue_filled_2.png"));
            AllCards1.Add(new Card("Images/ellipse_blue_filled_3.png"));
            AllCards1.Add(new Card("Images/ellipse_blue_striped_1.png"));
            AllCards1.Add(new Card("Images/ellipse_blue_striped_2.png"));
            AllCards1.Add(new Card("Images/ellipse_blue_striped_3.png"));
            AllCards1.Add(new Card("Images/ellipse_brown_empty_1.png"));
            AllCards1.Add(new Card("Images/ellipse_brown_empty_2.png"));
            AllCards1.Add(new Card("Images/ellipse_brown_empty_3.png"));
            AllCards1.Add(new Card("Images/ellipse_brown_filled_1.png"));
            AllCards1.Add(new Card("Images/ellipse_brown_filled_2.png"));
            AllCards1.Add(new Card("Images/ellipse_brown_filled_3.png"));
            AllCards1.Add(new Card("Images/ellipse_brown_striped_1.png"));
            AllCards1.Add(new Card("Images/ellipse_brown_striped_2.png"));
            AllCards1.Add(new Card("Images/ellipse_brown_striped_3.png"));
            AllCards1.Add(new Card("Images/ellipse_green_empty_1.png"));
            AllCards1.Add(new Card("Images/ellipse_green_empty_2.png"));
            AllCards1.Add(new Card("Images/ellipse_green_empty_3.png"));
            AllCards1.Add(new Card("Images/ellipse_green_filled_1.png"));
            AllCards1.Add(new Card("Images/ellipse_green_filled_2.png"));
            AllCards1.Add(new Card("Images/ellipse_green_filled_3.png"));
            AllCards1.Add(new Card("Images/ellipse_green_striped_1.png"));
            AllCards1.Add(new Card("Images/ellipse_green_striped_2.png"));
            AllCards1.Add(new Card("Images/ellipse_green_striped_3.png"));
            AllCards1.Add(new Card("Images/ellipse_grey_empty_1.png"));
            AllCards1.Add(new Card("Images/ellipse_grey_empty_2.png"));
            AllCards1.Add(new Card("Images/ellipse_grey_empty_3.png"));
            AllCards1.Add(new Card("Images/ellipse_grey_filled_1.png"));
            AllCards1.Add(new Card("Images/ellipse_grey_filled_2.png"));
            AllCards1.Add(new Card("Images/ellipse_grey_filled_3.png"));
            AllCards1.Add(new Card("Images/ellipse_grey_striped_1.png"));
            AllCards1.Add(new Card("Images/ellipse_grey_striped_2.png"));
            AllCards1.Add(new Card("Images/ellipse_grey_striped_3.png"));
            AllCards1.Add(new Card("Images/ellipse_orange_empty_1.png"));
            AllCards1.Add(new Card("Images/ellipse_orange_empty_2.png"));
            AllCards1.Add(new Card("Images/ellipse_orange_empty_3.png"));
            AllCards1.Add(new Card("Images/ellipse_orange_filled_1.png"));
            AllCards1.Add(new Card("Images/ellipse_orange_filled_2.png"));
            AllCards1.Add(new Card("Images/ellipse_orange_filled_3.png"));
            AllCards1.Add(new Card("Images/ellipse_orange_striped_1.png"));
            AllCards1.Add(new Card("Images/ellipse_orange_striped_2.png"));
            AllCards1.Add(new Card("Images/ellipse_orange_striped_3.png"));
            AllCards1.Add(new Card("Images/ellipse_purple_empty_1.png"));
            AllCards1.Add(new Card("Images/ellipse_purple_empty_2.png"));
            AllCards1.Add(new Card("Images/ellipse_purple_empty_3.png"));
            AllCards1.Add(new Card("Images/ellipse_purple_filled_1.png"));
            AllCards1.Add(new Card("Images/ellipse_purple_filled_2.png"));
            AllCards1.Add(new Card("Images/ellipse_purple_filled_3.png"));
            AllCards1.Add(new Card("Images/ellipse_purple_striped_1.png"));
            AllCards1.Add(new Card("Images/ellipse_purple_striped_2.png"));
            AllCards1.Add(new Card("Images/ellipse_purple_striped_3.png"));
            AllCards1.Add(new Card("Images/ellipse_red_empty_1.png"));
            AllCards1.Add(new Card("Images/ellipse_red_empty_2.png"));
            AllCards1.Add(new Card("Images/ellipse_red_empty_3.png"));
            AllCards1.Add(new Card("Images/ellipse_red_filled_1.png"));
            AllCards1.Add(new Card("Images/ellipse_red_filled_2.png"));
            AllCards1.Add(new Card("Images/ellipse_red_filled_3.png"));
            AllCards1.Add(new Card("Images/ellipse_red_striped_1.png"));
            AllCards1.Add(new Card("Images/ellipse_red_striped_2.png"));
            AllCards1.Add(new Card("Images/ellipse_red_striped_3.png"));
            AllCards1.Add(new Card("Images/square_blue_empty_1.png"));
            AllCards1.Add(new Card("Images/square_blue_empty_2.png"));
            AllCards1.Add(new Card("Images/square_blue_empty_3.png"));
            AllCards1.Add(new Card("Images/square_blue_filled_1.png"));
            AllCards1.Add(new Card("Images/square_blue_filled_2.png"));
            AllCards1.Add(new Card("Images/square_blue_filled_3.png"));
            AllCards1.Add(new Card("Images/square_blue_striped_1.png"));
            AllCards1.Add(new Card("Images/square_blue_striped_2.png"));
            AllCards1.Add(new Card("Images/square_blue_striped_3.png"));
            AllCards1.Add(new Card("Images/square_brown_empty_1.png"));
            AllCards1.Add(new Card("Images/square_brown_empty_2.png"));
            AllCards1.Add(new Card("Images/square_brown_empty_3.png"));
            AllCards1.Add(new Card("Images/square_brown_filled_1.png"));
            AllCards1.Add(new Card("Images/square_brown_filled_2.png"));
            AllCards1.Add(new Card("Images/square_brown_filled_3.png"));
            AllCards1.Add(new Card("Images/square_brown_striped_1.png"));
            AllCards1.Add(new Card("Images/square_brown_striped_2.png"));
            AllCards1.Add(new Card("Images/square_brown_striped_3.png"));
            AllCards1.Add(new Card("Images/square_green_empty_1.png"));
            AllCards1.Add(new Card("Images/square_green_empty_2.png"));
            AllCards1.Add(new Card("Images/square_green_empty_3.png"));
            AllCards1.Add(new Card("Images/square_green_filled_1.png"));
            AllCards1.Add(new Card("Images/square_green_filled_2.png"));
            AllCards1.Add(new Card("Images/square_green_filled_3.png"));
            AllCards1.Add(new Card("Images/square_green_striped_1.png"));
            AllCards1.Add(new Card("Images/square_green_striped_2.png"));
            AllCards1.Add(new Card("Images/square_green_striped_3.png"));
            AllCards1.Add(new Card("Images/square_grey_empty_1.png"));
            AllCards1.Add(new Card("Images/square_grey_empty_2.png"));
            AllCards1.Add(new Card("Images/square_grey_empty_3.png"));
            AllCards1.Add(new Card("Images/square_grey_filled_1.png"));
            AllCards1.Add(new Card("Images/square_grey_filled_2.png"));
            AllCards1.Add(new Card("Images/square_grey_filled_3.png"));
            AllCards1.Add(new Card("Images/square_grey_striped_1.png"));
            AllCards1.Add(new Card("Images/square_grey_striped_2.png"));
            AllCards1.Add(new Card("Images/square_grey_striped_3.png"));
            AllCards1.Add(new Card("Images/square_orange_empty_1.png"));
            AllCards1.Add(new Card("Images/square_orange_empty_2.png"));
            AllCards1.Add(new Card("Images/square_orange_empty_3.png"));
            AllCards1.Add(new Card("Images/square_orange_filled_1.png"));
            AllCards1.Add(new Card("Images/square_orange_filled_2.png"));
            AllCards1.Add(new Card("Images/square_orange_filled_3.png"));
            AllCards1.Add(new Card("Images/square_orange_striped_1.png"));
            AllCards1.Add(new Card("Images/square_orange_striped_2.png"));
            AllCards1.Add(new Card("Images/square_orange_striped_3.png"));
            AllCards1.Add(new Card("Images/square_purple_empty_1.png"));
            AllCards1.Add(new Card("Images/square_purple_empty_2.png"));
            AllCards1.Add(new Card("Images/square_purple_empty_3.png"));
            AllCards1.Add(new Card("Images/square_purple_filled_1.png"));
            AllCards1.Add(new Card("Images/square_purple_filled_2.png"));
            AllCards1.Add(new Card("Images/square_purple_filled_3.png"));
            AllCards1.Add(new Card("Images/square_purple_striped_1.png"));
            AllCards1.Add(new Card("Images/square_purple_striped_2.png"));
            AllCards1.Add(new Card("Images/square_purple_striped_3.png"));
            AllCards1.Add(new Card("Images/square_red_empty_1.png"));
            AllCards1.Add(new Card("Images/square_red_empty_2.png"));
            AllCards1.Add(new Card("Images/square_red_empty_3.png"));
            AllCards1.Add(new Card("Images/square_red_filled_1.png"));
            AllCards1.Add(new Card("Images/square_red_filled_2.png"));
            AllCards1.Add(new Card("Images/square_red_filled_3.png"));
            AllCards1.Add(new Card("Images/square_red_striped_1.png"));
            AllCards1.Add(new Card("Images/square_red_striped_2.png"));
            AllCards1.Add(new Card("Images/square_red_striped_3.png"));
        }

        public void setImageSource() //Sets the Image Source of the Button in the ViewModel by using the ButtonImageSource properties
        {

            /*
            _gameViewModel.zeroButtonImageSource    = setCards[0].ImageSource;
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
            SelectedCards.Add(SetCards[i]);
            if(SelectedCards.Count == 3)
            {
                //IsASet();
                SelectedCards.Clear();
            }
        }

        #region FindOutNumbersOfPossibleSets
        public int FindOutNumberOfPossibleSets()
        {
            int numberOfSets = 0;
            for (int i = 0; i < setCards.Count; i++)
            {
                for (int j = 0; j < setCards.Count; j++)
                {
                    if (i == j)
                    {
                        j++;
                    }
                    for (int k = 0; k < setCards.Count; k++)
                    {
                        if (j == k)
                        {
                            k++;
                        }
                        if (IsASet(setCards[i], setCards[j], setCards[k]))
                        {

                            numberOfSets++;

                        }


                    }


                }



            }

            return numberOfSets;

        }
        #endregion

        #region IsASet

        public Boolean IsASet(Card first, Card second, Card third)  //Check if Selected Cards are a Set using the methods below
        {


            if ((StringAllSame(first.Color, second.Color, third.Color) || StringAllDifferent(first.Color, second.Color, third.Color)) && (StringAllSame(first.Filling, second.Filling, third.Filling) || StringAllDifferent(first.Filling, second.Filling, third.Filling)) && (StringAllSame(first.NumberOfObjects, second.NumberOfObjects, third.NumberOfObjects) || StringAllDifferent(first.NumberOfObjects, second.NumberOfObjects, third.NumberOfObjects)) && (StringAllSame(first.Shape, second.Shape, third.Shape) || StringAllDifferent(first.Shape, second.Shape, third.Shape)))
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


        #endregion



    }


}