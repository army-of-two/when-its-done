namespace WhenItsDone.MVP.RatingsMVP
{
    public class DishRatingVoteEventArgs
    {
        public DishRatingVoteEventArgs(int dishId)
        {
            this.DishId = dishId;
        }

        public int DishId { get; private set; }
    }
}
