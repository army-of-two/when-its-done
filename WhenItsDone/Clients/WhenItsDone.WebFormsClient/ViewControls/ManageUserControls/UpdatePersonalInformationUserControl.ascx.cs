using System.Web.UI;

namespace WhenItsDone.WebFormsClient.ViewControls.ManageUserControls
{
    public partial class UpdatePersonalInformationUserControl : System.Web.UI.UserControl
    {
        public string LoggedUserUsernameFromIdentity
        {
            get
            {
                return Page.User.Identity.Name;
            }
        }
    }
}