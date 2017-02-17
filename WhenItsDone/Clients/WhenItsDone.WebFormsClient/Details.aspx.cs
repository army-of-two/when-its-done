using System;
using System.Web.ModelBinding;

using WebFormsMvp;
using WebFormsMvp.Web;

using WhenItsDone.DTOs.DishViewsDTOs;
using WhenItsDone.MVP.DetailsMVP;

namespace WhenItsDone.WebFormsClient
{
    [PresenterBinding(typeof(IDetailsPresenter))]
    public partial class Details : MvpPage<DetailsViewModel>, IDetailsView
    {
        public event EventHandler<DetailsGetDishDetailsEventArgs> OnGetDishDetails;
        public event EventHandler<DetailsRatingVoteEventArgs> OnLikeVote;
        public event EventHandler<DetailsRatingVoteEventArgs> OnDislikeVote;

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public DishDetailsViewDTO Unnamed_GetItem([QueryString]int? itemid)
        {
            var detailsGetDishDetailsEventArgs = new DetailsGetDishDetailsEventArgs(itemid);
            this.OnGetDishDetails?.Invoke(null, detailsGetDishDetailsEventArgs);

            return this.Model.DishDetails;
        }

        public void OnLikeLinkButtonClick(object sender, EventArgs e)
        {

        }

        public void OnDislikeLinkButtonClick(object sender, EventArgs e)
        {

        }
    }
}