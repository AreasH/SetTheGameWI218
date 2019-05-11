using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set {

    class Game
    {
        Set<Card> AllCards;
        Set<Card> Playset;
        Set<Card> foundSets;
        Set<Card> removedCards;
        List<Card> setCards;
        int NumberOfPossibleSets;
        int CountSelectedCards = 0;

        public Boolean IsASet(String first, String second, String third)
        { //Check if Selected Cards are a Set using the methods below


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