using System;

using WebFormsMvp;
using WebFormsMvp.Web;

using WhenItsDone.MVP.DetailsMVP;

namespace WhenItsDone.WebFormsClient
{
    [PresenterBinding(typeof(IDetailsPresenter))]
    public partial class Details : MvpPage<DetailsViewModel>, IDetailsView
    {
        public event EventHandler<DetailsGetDishDetailsEventArgs> OnGetDishDetails;
        public event EventHandler<DetailsRatingVoteEventArgs> OnLikeVote;
        public event EventHandler<DetailsRatingVoteEventArgs> OnDislikeVote;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var itemid = this.Request.QueryString["itemid"];
            var detailsGetDishDetailsEventArgs = new DetailsGetDishDetailsEventArgs(itemid);
            this.OnGetDishDetails?.Invoke(null, detailsGetDishDetailsEventArgs);

            this.EnableVotingOnLoggedUser();
        }

        public void OnLikeLinkButtonClick(object sender, EventArgs e)
        {
            var detailsRatingVoteEventArgs = this.CreateDetailsRatingVoteEventArgs();
            this.OnLikeVote?.Invoke(null, detailsRatingVoteEventArgs);
        }

        public void OnDislikeLinkButtonClick(object sender, EventArgs e)
        {
            var detailsRatingVoteEventArgs = this.CreateDetailsRatingVoteEventArgs();
            this.OnDislikeVote?.Invoke(null, detailsRatingVoteEventArgs);
        }

        private DetailsRatingVoteEventArgs CreateDetailsRatingVoteEventArgs()
        {
            var dishId = this.DishIdHiddenField.Value;
            var detailsRatingVoteEventArgs = new DetailsRatingVoteEventArgs(dishId);

            return detailsRatingVoteEventArgs;
        }

        private void EnableVotingOnLoggedUser()
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                this.RatingHeaderLabel.Text = string.Format("<a href='/account/login?ReturnUrl={0}'>Login to enable voting.</a>", this.Request.RawUrl);

                this.LikeLinkButton.Enabled = false;
                this.LikeLinkButton.CssClass += " disabled";
                this.LikeLinkButton.ToolTip = "Login to enable voting.";

                this.DislikeLinkButton.Enabled = false;
                this.DislikeLinkButton.CssClass += " disabled";
                this.DislikeLinkButton.ToolTip = "Login to enable voting.";
            }
            else
            {
                this.LikeLinkButton.ToolTip = string.Format("Like: {0}", this.Model.DishDetails.Name);
                this.DislikeLinkButton.ToolTip = string.Format("Dislike: {0}", this.Model.DishDetails.Name);
            }
        }
    }
}