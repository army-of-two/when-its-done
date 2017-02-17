using System.Web.ModelBinding;

using WhenItsDone.DTOs.DishViewsDTOs;

namespace WhenItsDone.WebFormsClient
{
    public partial class Details : System.Web.UI.Page
    {
        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public DishDetailsViewDTO Unnamed_GetItem([QueryString]int? itemid)
        {
            this.Test.InnerHtml = "Details for " + itemid.ToString();
            return null;
        }
    }
}