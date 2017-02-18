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

            this.EnableVotingOnLoggedUser();

            var itemid = this.Request.QueryString["itemid"];
            var detailsGetDishDetailsEventArgs = new DetailsGetDishDetailsEventArgs(itemid);
            this.OnGetDishDetails?.Invoke(null, detailsGetDishDetailsEventArgs);
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
                this.LikeLinkButton.Enabled = false;
                this.LikeLinkButton.CssClass += " disabled";

                this.DislikeLinkButton.Enabled = false;
                this.DislikeLinkButton.CssClass += "disabled";
            }
        }
    }
}