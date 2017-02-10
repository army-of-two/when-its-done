using System;
using System.Web.UI;

namespace WhenItsDone.WebFormsClient.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.ProfilePictureButtonClick(null, null);
        }

        protected void ProfilePictureButtonClick(object sender, EventArgs e)
        {
            this.HideAllActivePanelControls();
            this.ManageProfilePictureUserControl.Visible = true;
        }

        protected void PersonalInformationButtonClick(object sender, EventArgs e)
        {
            this.HideAllActivePanelControls();
            this.UpdatePersonalInformationUserControl.Visible = true;
        }

        protected void MedicalInformationButtonClick(object sender, EventArgs e)
        {
            this.HideAllActivePanelControls();
            this.UpdateMedicalInformationUserControl.Visible = true;
        }

        protected void ContactInformationButtonClick(object sender, EventArgs e)
        {
            this.HideAllActivePanelControls();
            this.UpdateContactInformationUserControl.Visible = true;
        }

        private void HideAllActivePanelControls()
        {
            foreach (Control item in this.ActiveContent.Controls)
            {
                item.Visible = false;
            }
        }
    }
}