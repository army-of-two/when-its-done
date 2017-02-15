using System;

namespace WhenItsDone.MVP.CreatePages
{
    public class CreateEventArgs : EventArgs
    {
        public CreateEventArgs(string name, string price, string calories, string carbohydrates, string fats, string protein, string video)
        {
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.Carbohydrates = carbohydrates;
            this.Fats = fats;
            this.Protein = protein;
            this.Video = video;
        }

        public string Name { get; private set; }

        public string Price { get; private set; }

        public string Calories { get; private set; }

        public string Carbohydrates { get; private set; }

        public string Fats { get; private set; }

        public string Protein { get; private set; }

        public string Video { get; private set; }
    }
}
