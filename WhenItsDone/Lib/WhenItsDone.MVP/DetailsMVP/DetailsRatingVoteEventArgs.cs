namespace WhenItsDone.MVP.DetailsMVP
{
    public class DetailsRatingVoteEventArgs
    {
        public DetailsRatingVoteEventArgs(int dishId)
        {
            this.DishId = dishId;
        }

        public int DishId { get; private set; }
    }
}
