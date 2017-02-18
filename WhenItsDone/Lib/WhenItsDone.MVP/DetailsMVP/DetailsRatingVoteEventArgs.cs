namespace WhenItsDone.MVP.DetailsMVP
{
    public class DetailsRatingVoteEventArgs
    {
        public DetailsRatingVoteEventArgs(string dishId)
        {
            this.DishId = dishId;
        }

        public string DishId { get; private set; }
    }
}
