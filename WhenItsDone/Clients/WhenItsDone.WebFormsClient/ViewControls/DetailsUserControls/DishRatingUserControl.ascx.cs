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

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            //if (string.IsNullOrEmpty(this.DishId) && !this.IsPostBack)
            //{
            //    this.LikeLinkButton.Enabled = false;
            //    this.LikeLinkButton.CssClass += " disabled";

            //    this.DislikeLinkButton.Enabled = false;
            //    this.DislikeLinkButton.CssClass += " disabled";
            //}
        }

        public void OnButtonLikeClick(object sender, EventArgs e)
        {

        }

        public void OnButtonDislikeClick(object sender, EventArgs e)
        {

        }
    }
}