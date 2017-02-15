using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

using WebFormsMvp;
using WebFormsMvp.Web;

using WhenItsDone.MVP.CreatePages;

namespace WhenItsDone.WebFormsClient.Create
{
    [PresenterBinding(typeof(ICreatePresenter))]
    public partial class Default : MvpPage<CreateViewModel>, ICreateView
    {
        public event EventHandler<CreateEventArgs> CreateDish;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.Page.User.Identity.IsAuthenticated)
            {
                this.Response.Redirect("/account/login?ReturnUrl=/create");
            }
        }

        public void OnCreateFormSubmit(object sender, EventArgs e)
        {
            var createEventArgs = new CreateEventArgs(this.Page.User.Identity.Name, this.DishName.Value, this.DishPrice.Value, this.Calories.Value, this.Carbohydrates.Value, this.Fats.Value, this.Protein.Value, this.Video.Value, this.Photo.Value);
            this.CreateDish?.Invoke(null, createEventArgs);

            if (this.Model.IsSuccessful)
            {
                this.ClearInputControlsValues();
            }
        }

        private void ClearInputControlsValues()
        {
            foreach (Control item in this.Controls)
            {
                if (item is HtmlInputText)
                {
                    (item as HtmlInputText).Value = string.Empty;
                }
            }
        }
    }
}