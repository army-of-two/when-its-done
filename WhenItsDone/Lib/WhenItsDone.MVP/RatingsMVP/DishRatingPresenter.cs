using System;

using WebFormsMvp;

namespace WhenItsDone.MVP.RatingsMVP
{
    public class DishRatingPresenter : Presenter<IDishRatingView>, IDishRatingPresenter
    {
        public DishRatingPresenter(IDishRatingView view)
            : base(view)
        {
            this.View.OnLikeVote += this.OnLikeVote;
            this.View.OnDislikeVote += this.OnDislikeVote;
        }

        private void OnLikeVote(object sender, DishRatingVoteEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnDislikeVote(object sender, DishRatingVoteEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
