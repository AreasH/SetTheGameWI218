using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;



namespace Set
{

    class Game
    {

        GameViewModel _gameViewModel;
        Options options;
        private string gameMode;
        List<Card> AllCards;  //Includes really all Cards possible, even if not used in this game instance
        List<Card> Playset; //Includes only the 81 Selected Cards that are used for this game instance
        List<Card> lastFoundSet; // Includes all Cards that were found to be a set (found by the player)
        List<Card> removedCards; //All Cards that were removed due to the player not being able to find a set
        List<Card> setCards; //The twelve cards that are actually up for finding a set inside them.
        List<Card> selectedCards; //The cards selected by the player -- not allowed to be more than 3.
        List<Card> lastAddedCards  = new List<Card>(); //List that contains the last three cards which were added to the playSet, to check if there is a Set possible
        int NumberOfPossibleSets;
        int CountSelectedCards = 0;
        int foundSets;
        DispatcherTimer timer; //timer displaying the time passed by since the game was started (in seconds). 
        int timeseconds = 0;
        int playSetEmptyCount;

        private bool finalPhase;
        private List<String> foundSetsList;



        public List<Card> AllCards1 { get => AllCards; set => AllCards = value; }
        public List<Card> Playset1 { get => Playset; set => Playset = value; }
        public List<Card> LastFoundSet { get => lastFoundSet; set => lastFoundSet = value; }
        public List<Card> RemovedCards { get => removedCards; set => removedCards = value; }
        public List<Card> SetCards { get => setCards; set => setCards = value; }
        public List<Card> SelectedCards { get => selectedCards; set => selectedCards = value; }
        private List<Card> LastAddedCards { get => lastAddedCards; set => lastAddedCards = value; }
        public int FoundSets { get => foundSets; set => foundSets = value; }
        public int NumberOfPossibleSets1 { get => NumberOfPossibleSets; set => NumberOfPossibleSets = value; }
        public int CountSelectedCards1 { get => CountSelectedCards; set => CountSelectedCards = value; }
        public int PlaySetEmptyCount { get => playSetEmptyCount; set => playSetEmptyCount = value; }
        public string GameMode { get => gameMode; set => gameMode = value; }


        public List<string> FoundSetsList { get => foundSetsList; set => foundSetsList = value; }


        public int TimeSeconds
        {
            get { return timeseconds; }
            set
            {
                timeseconds = value;
                _gameViewModel.UpdateTime();
            }
        }

        public string Time
        {
            get
            {
                string Hrs;    //number of Hours
                string Min;    //number of Minutes
                string Sec;    //number of Seconds

                Sec = (TimeSeconds % 60 < 10) ? "0" + (TimeSeconds % 60).ToString() : (TimeSeconds % 60).ToString();
                Min = (TimeSeconds / 60 < 10) ? "0" + (TimeSeconds / 60).ToString() : (TimeSeconds / 60).ToString();
                Hrs = (TimeSeconds / 3600 < 10) ? "0" + (TimeSeconds / 3600).ToString() : (TimeSeconds / 3600).ToString();

                return Hrs.ToString() + " : " + Min.ToString() + " : " + Sec.ToString();
            }
        }

        public Game(GameViewModel g, Object options)
        {
            _gameViewModel = g;
            this.options = (Options)options;
            initalizeAllCards();
            StartNewGame();
            initializeTimer();
            timer.Start();
        }

        public void StartNewGame()
        {
            GameMode = options.SelectedGameMode;
            generatePlaySet();
            FoundSets = 0;
            PlaySetEmptyCount = 0;
            SetCards = null;
            LastFoundSet = null;
            finalPhase = false;
            initializeSetCards();
            setImageSource();
            _gameViewModel.RefreshSelection();
            switch(GameMode)
            {
                case "Normal":
                    TimeSeconds = 0;
                    break;
                case "Gegen die Zeit (5 min)":
                    TimeSeconds = 300;
                    break;
                case "Hardcore":
                    TimeSeconds = 30;
                    break;
            }

        }


        public void initializeSetCards()
        {

            Random rnd = new Random();
            int i = rnd.Next(Playset1.Count);

            if (SetCards == null)
            {
                SetCards = new List<Card>();
                
                while (SetCards.Count < 12)
                    {

                        i = rnd.Next(Playset1.Count);
                        if (!SetCards.Contains(Playset1[i]))
                        {
                            SetCards.Add(Playset1[i]);
                            Playset1.RemoveAt(i);
                        }
                    }
                while (FindOutNumberOfPossibleSets() == 0)
                {
                    Playset1.Add(SetCards[0]);
                    SetCards.RemoveAt(0);
                    i = rnd.Next(Playset1.Count);
                    SetCards.Add(Playset1[i]);
                    Playset1.RemoveAt(i);
                }
            }
            _gameViewModel.UpdateFoundSets();
            _gameViewModel.UpdateCardsLeft();
            _gameViewModel.UpdateNumberOfPossibleSets();
            setImageSource();
        }

        public void refreshSetCards() //Remove the Selected Cards from the SetCards and add new Cards from PlaySet1,sticking to 
        {
            //Getting a random number to choose a card from the playset
            Random rnd = new Random();
            int r = 0;
            int count = 0;
            int firstIndex = 0;
            int secondIndex = 0;
            int thirdIndex = 0;

            foreach(Card card in SetCards) //get the indizes of the cards to remove
            {
                if(card.Selected)
                {
                    count++;
                    switch (count)
                    {
                        case 1:
                            firstIndex = SetCards.IndexOf(card);
                            break;
                        case 2:
                            secondIndex = SetCards.IndexOf(card);
                            break;
                        case 3:
                            thirdIndex = SetCards.IndexOf(card);
                            break;
                    }
                }
            }
            
            if(Playset1.Count == 0)
            {
                finalPhase = true;
                Playset1.AddRange(AllCards1.Where(card => card.Shape.Equals("block")));
            }

            for(int i= 0;i<3;i++)
            {
                r = rnd.Next(Playset1.Count);
                switch (i) //Add the cards at the right places
                {
                    case 0:
                        SetCards.Insert(firstIndex,Playset1[r]);
                        SetCards.RemoveAt(firstIndex + 1);
                        Playset1.RemoveAt(r);
                        break;
                    case 1:
                        SetCards.Insert(secondIndex, Playset1[r]);
                        SetCards.RemoveAt(secondIndex + 1);
                        Playset1.RemoveAt(r);
                        break;
                    case 2:
                        SetCards.Insert(thirdIndex, Playset1[r]);
                        SetCards.RemoveAt(thirdIndex + 1);
                        Playset1.RemoveAt(r);
                        break;
                }
            }

            int loopCounter = 100; //if there is no SetPossible after 50 times removing one card and adding another one, just end the game

            while (FindOutNumberOfPossibleSets() == 0)
            {
                loopCounter--;
                if (finalPhase || loopCounter==0)
                {
                    EndGame("Kein Set mehr möglich.");
                    break;
                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        r = rnd.Next(Playset1.Count);
                        switch (i) //Add the cards at the right places
                        {
                            case 0:
                                SetCards.Insert(firstIndex, Playset1[r]);
                                SetCards.RemoveAt(firstIndex + 1);
                                Playset1.RemoveAt(r);
                                break;
                            case 1:
                                SetCards.Insert(secondIndex, Playset1[r]);
                                SetCards.RemoveAt(secondIndex + 1);
                                Playset1.RemoveAt(r);
                                break;
                            case 2:
                                SetCards.Insert(thirdIndex, Playset1[r]);
                                SetCards.RemoveAt(thirdIndex + 1);
                                Playset1.RemoveAt(r);
                                break;
                        }
                    }
                }
            }


            _gameViewModel.UpdateFoundSets();
            _gameViewModel.UpdateCardsLeft();
            _gameViewModel.UpdateNumberOfPossibleSets();
            setImageSource();

            

        } //If SetCards is smaller than 12, get some random new Cards from the 81 Cards and make sure a Set is possible.

        public void initalizeAllCards()
        {
            //Build AllCards
            AllCards1 = new List<Card>();
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

            //Add the X Blocks to All Cards.
            AllCards1.Add(new Card("Images/block_x_red_1.png"));
            AllCards1.Add(new Card("Images/block_x_red_1.png"));
            AllCards1.Add(new Card("Images/block_x_red_1.png"));
            AllCards1.Add(new Card("Images/block_x_red_1.png"));
            AllCards1.Add(new Card("Images/block_x_red_1.png"));
            AllCards1.Add(new Card("Images/block_x_red_1.png"));
            AllCards1.Add(new Card("Images/block_x_red_1.png"));
            AllCards1.Add(new Card("Images/block_x_red_1.png"));
            AllCards1.Add(new Card("Images/block_x_red_1.png"));
            AllCards1.Add(new Card("Images/block_x_red_1.png"));
            AllCards1.Add(new Card("Images/block_x_red_1.png"));
            AllCards1.Add(new Card("Images/block_x_red_1.png"));
        } //All (currently 189) Cards are being set with the help of the image Source

        public void generatePlaySet() //if theres no PlaySet, generate a new one and fill it with the correctly colored cards.
        {
            
            if (Playset1 == null)
                Playset1 = new List<Card>();
            Playset1.Clear();
            foreach (Card card in AllCards1)
            {
                card.Selected = false;
                if ((card.Color == options.Color[0]) || (card.Color == options.Color[1]) || (card.Color == options.Color[2]))
                { // Note for Andi: Please implement the method Options.getColors which returns an Array containing the 3 selected colors Edit.: Done.

                    Playset1.Add(card);
                }
            }

        }

        public void setImageSource() //Sets the Image Source of the Button in the ViewModel by using the ButtonImageSource properties
        {
            _gameViewModel.zeroButtonImageSource = setCards[0].ImageSource;
            _gameViewModel.oneButtonImageSource = setCards[1].ImageSource;
            _gameViewModel.twoButtonImageSource = setCards[2].ImageSource;
            _gameViewModel.threeButtonImageSource = setCards[3].ImageSource;
            _gameViewModel.fourButtonImageSource = setCards[4].ImageSource;
            _gameViewModel.fiveButtonImageSource = setCards[5].ImageSource;
            _gameViewModel.sixButtonImageSource = setCards[6].ImageSource;
            _gameViewModel.sevenButtonImageSource = setCards[7].ImageSource;
            _gameViewModel.eightButtonImageSource = setCards[8].ImageSource;
            _gameViewModel.nineButtonImageSource = setCards[9].ImageSource;
            _gameViewModel.tenButtonImageSource = setCards[10].ImageSource;
            _gameViewModel.elevenButtonImageSource = setCards[11].ImageSource;
        }

        public int PlaySetCountFake()
        {
            int t = finalPhase ? 0 : Playset1.Count();
            return t; 
        }

        public void CardSelected(int i) //Card at index i from setCards is added/removed to the selectedCards.
        {
            if (SelectedCards == null)
            {
                SelectedCards = new List<Card>();
            }
            if (SelectedCards.Contains(SetCards[i])) //Remove the card from Selected Cards
            {
                SelectedCards.Remove(SetCards[i]);
                SetCards[i].Selected = false;
                _gameViewModel.RefreshSelection();
            }
            else
            {
                SelectedCards.Add(SetCards[i]); //Add the card.
                SetCards[i].Selected = true;
                _gameViewModel.RefreshSelection();
                if (SelectedCards.Count >= 3)
                {
                    if (IsASet(SelectedCards[0], SelectedCards[1], SelectedCards[2])) //Found A Set! Yay
                    {

                        FoundSets++;
                        if (LastFoundSet == null)
                        {
                            LastFoundSet = new List<Card>();
                        }
                        LastFoundSet.Clear();
                        LastFoundSet.AddRange(SelectedCards);
                        _gameViewModel.UpdateFoundSet();
                        refreshSetCards();
                    }
                    SelectedCards.Clear();
                    foreach (Card card in SetCards)
                    {
                        card.Selected = false;
                    }
                    foreach (Card card in Playset1)
                    {
                        card.Selected = false;
                    }
                    TimeSeconds = GameMode == "Hardcore" ? 30 : TimeSeconds;
                    _gameViewModel.RefreshSelection();

                }
            }

        }

        #region FindOutNumbersOfPossibleSets
        public int FindOutNumberOfPossibleSets()
        {
            if (FoundSetsList == null)
            {
                FoundSetsList = new List<String>();
            }
            FoundSetsList.Clear();

            for (int i = 0; i < setCards.Count; i++)
            {


                for (int j = 0; j < setCards.Count; j++)
                {

                    if (i == j)
                    {
                        continue;
                    }
                    for (int k = 0; k < setCards.Count; k++)
                    {
                        if (i == k)
                        {
                            continue;
                        }

                        if (j == k)
                        {
                            continue;
                        }

                        if (IsASet(setCards[i], setCards[j], setCards[k]))
                        {

                            String testSet = orderInt(i, j, k);

                            if (!FoundSetsList.Contains(testSet))
                            {
                                FoundSetsList.Add(testSet);

                            }

                        }
                    }
                }



            }

            return FoundSetsList.Count();

        }

        public String orderInt(int a, int b, int c)
        {
            int number1 = a;
            int number2 = b;
            int number3 = c;


            if (number1 > number2)
            {
                int temp = number1;
                number1 = number2;
                number2 = temp;
            }

            if (number2 > number3)
            {
                int temp = number2;
                number2 = number3;
                number3 = temp;
            }

            if (number1 > number2)
            {
                int temp = number1;
                number1 = number2;
                number2 = temp;
            }

            return number1.ToString() + "_" + number2.ToString() + "_" + number3.ToString();
        }


        #endregion

        #region IsASet

        public Boolean IsASet(Card first, Card second, Card third)  //Check if Selected Cards are a Set using the methods below
        {

            if (first.Shape == "block" || second.Shape == "block" || third.Shape == "block")
            {
                return false;
            }
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

        public void EndGame(string reason)
        {
            GameMode = "Normal";
            _gameViewModel.ChangeToMenu(reason);
        }

        public void initializeTimer()
        {

            timer = null;
            timer = new DispatcherTimer(DispatcherPriority.Send);
            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = TimeSpan.FromSeconds(1);

        }

        public void timer_tick(object sender, EventArgs e)
        { //Counts the number of seconds since the game was started.

            switch (GameMode)
            {
                case "Normal":
                    TimeSeconds = TimeSeconds+1;
                    break;
                case "Gegen die Zeit (5 min)":
                    TimeSeconds = TimeSeconds-1;
                    if (TimeSeconds == 0)
                    {
                        EndGame("Die Zeit ist abgelaufen.");
                    }
                    break;
                case "Hardcore":
                    TimeSeconds = TimeSeconds-1;

                    if (TimeSeconds == 0)
                    {
                        EndGame("Die Zeit ist abgelaufen.");
                    }
                    break;
            }
            


        }

    }
}