using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WhenItsDone.WebFormsClient.ViewControls.DetailsUserControls
{
    public partial class DishRatingUserControl : System.Web.UI.UserControl
    {
        public int DishRating { get; set; }

        public int DishId { get; set; }
    }
}