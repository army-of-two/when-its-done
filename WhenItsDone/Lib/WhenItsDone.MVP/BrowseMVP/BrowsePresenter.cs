using System;

using WebFormsMvp;

namespace WhenItsDone.MVP.BrowseMVP
{
    public class BrowsePresenter : Presenter<IBrowseView>, IBrowsePresenter
    {
        public BrowsePresenter(IBrowseView view)
            : base(view)
        {
            base.View.OnBrowseDishesGetData += this.OnBrowseDishesGetData;
        }

        private void OnBrowseDishesGetData(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
