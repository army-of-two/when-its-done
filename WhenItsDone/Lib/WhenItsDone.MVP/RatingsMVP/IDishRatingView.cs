using System;

using WebFormsMvp;

namespace WhenItsDone.MVP.RatingsMVP
{
    public interface IDishRatingView : IView<DishRatingViewModel>
    {
        event EventHandler<DishRatingVoteEventArgs> OnLikeVote;

        event EventHandler<DishRatingVoteEventArgs> OnDislikeVote;
    }
}
