using System;

using WebFormsMvp;
using WebFormsMvp.Web;

using WhenItsDone.MVP.RatingsMVP;

namespace WhenItsDone.WebFormsClient.ViewControls.DetailsUserControls
{
    [PresenterBinding(typeof(IDishRatingPresenter))]
    public partial class DishRatingUserControl : MvpUserControl<DishRatingViewModel>, IDishRatingView
    {
        public event EventHandler<DishRatingVoteEventArgs> OnLikeVote;
        public event EventHandler<DishRatingVoteEventArgs> OnDislikeVote;

        public string DishRating { get; set; }

        public string DishId { get; set; }
    }
}