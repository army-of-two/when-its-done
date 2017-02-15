using System;

namespace WhenItsDone.MVP.CreatePages
{
    public class CreateEventArgs : EventArgs
    {
        public string Name { get; set; }

        public string Price { get; set; }

        public string MyProperty { get; set; }

        public string Calories { get; set; }

        public string Carbohydrates { get; set; }

        public string Fats { get; set; }

        public string Protein { get; set; }

        public string Video { get; set; }
    }
}
