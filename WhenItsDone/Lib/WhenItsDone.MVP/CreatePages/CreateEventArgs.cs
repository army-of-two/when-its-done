using System;

namespace WhenItsDone.MVP.CreatePages
{
    public class CreateEventArgs : EventArgs
    {
        public CreateEventArgs(string loggedUserUsername, string name, string price, string calories, string carbohydrates, string fats, string protein, string videoUrl, string photoUrl)
        {
            this.LoggedUserUsername = loggedUserUsername;
            this.Name = name;
            this.Price = price;
            this.Calories = calories;
            this.Carbohydrates = carbohydrates;
            this.Fats = fats;
            this.Protein = protein;
            this.VideoUrl = videoUrl;
            this.PhotoUrl = photoUrl;
        }

        public string LoggedUserUsername { get; private set; }

        public string Name { get; private set; }

        public string Price { get; private set; }

        public string Calories { get; private set; }

        public string Carbohydrates { get; private set; }

        public string Fats { get; private set; }

        public string Protein { get; private set; }

        public string VideoUrl { get; private set; }

        public string PhotoUrl { get; set; }
    }
}
