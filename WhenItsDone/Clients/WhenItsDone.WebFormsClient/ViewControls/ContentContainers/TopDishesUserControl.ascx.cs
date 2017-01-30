using System;

using WebFormsMvp;
using WebFormsMvp.Web;

using WhenItsDone.MVP.ContentContainers.TopDishesMVP;

namespace WhenItsDone.WebFormsClient.ViewControls.ContentContainers
{
    [PresenterBinding(typeof(ITopDishesPresenter))]
    public partial class TopDishesUserControl : MvpUserControl<TopDishesViewModel>, ITopDishesView
    {
        public event EventHandler<TopDishesEventArgs> GetTopDishes;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var topDishesEventArgs = new TopDishesEventArgs(3, true);
                this.GetTopDishes?.Invoke(null, topDishesEventArgs);

                this.TopDishesRepeater.DataSource = this.Model.TopDishes;
                this.TopDishesRepeater.DataBind();
            }
        }
    }
}