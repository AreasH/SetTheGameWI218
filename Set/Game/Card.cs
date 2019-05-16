using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    class Card

    {
        private string shape;
        private string color;
        private string filling;
        private string numberOfObjects;
        private bool selected;
        private string imageSource;

        public Card(string imageSource)
        {
            //Splitting the image source code into an array of strings to gain access to the attribute of the card.
            string imageName = imageSource.Substring(7, imageSource.Length-11);
            string[] meineStrings = imageName.Split(new Char[] { '_' });
            this.imageSource = Path.Combine(Environment.CurrentDirectory,imageSource);
            this.shape = meineStrings[0];
            this.color = meineStrings[1];
            this.filling = meineStrings[2];
            this.numberOfObjects = meineStrings[3];
            this.selected = false;


        }

        #region Properties
        public string ImageSource { get => imageSource; set => imageSource = value; }
        public string Shape { get => shape; set => shape = value; }
        public string Color { get => color; set => color = value; }
        public string Filling { get => filling; set => filling = value; }
        public string NumberOfObjects { get => numberOfObjects; set => numberOfObjects = value; }
        public bool Selected { get => selected; set => selected = value; }
        #endregion
    }

}
