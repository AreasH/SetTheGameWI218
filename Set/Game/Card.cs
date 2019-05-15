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

        public Card(string shape, string color, string filling, string numberOfObjects, bool selected, string imageSource)
        {
            this.shape = shape;
            this.color = color;
            this.filling = filling;
            this.numberOfObjects = numberOfObjects;
            this.selected = selected;
            this.imageSource = Path.Combine(Environment.CurrentDirectory,imageSource);


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
