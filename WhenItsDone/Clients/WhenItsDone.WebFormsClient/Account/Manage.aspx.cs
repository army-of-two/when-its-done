using System;
using System.Web.UI;

using WhenItsDone.WebFormsClient.ViewControls.Contracts;

namespace WhenItsDone.WebFormsClient.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.IsPostBack)
            {
                this.ProfilePictureButtonClick(null, null);
            }
        }

        protected void ProfilePictureButtonClick(object sender, EventArgs e)
        {
            this.HideAllActivePanelControls();
            this.ManageProfilePictureUserControl.Visible = true;
            (this.ManageProfilePictureUserControl as IShouldLoad).ShouldLoad = true;
        }

        protected void PersonalInformationButtonClick(object sender, EventArgs e)
        {
            this.HideAllActivePanelControls();
            this.UpdatePersonalInformationUserControl.Visible = true;
            (this.UpdatePersonalInformationUserControl as IShouldLoad).ShouldLoad = true;
        }

        protected void MedicalInformationButtonClick(object sender, EventArgs e)
        {
            this.HideAllActivePanelControls();
            this.UpdateMedicalInformationUserControl.Visible = true;
            (this.UpdateMedicalInformationUserControl as IShouldLoad).ShouldLoad = true;
        }

        protected void ContactInformationButtonClick(object sender, EventArgs e)
        {
            this.HideAllActivePanelControls();
            this.UpdateContactInformationUserControl.Visible = true;
            (this.UpdateContactInformationUserControl as IShouldLoad).ShouldLoad = true;
        }

        private void HideAllActivePanelControls()
        {
            foreach (Control item in this.ActiveContent.Controls)
            {
                if (item is IShouldLoad)
                {
                    (item as IShouldLoad).ShouldLoad = false;
                    item.Visible = false;
                }
            }
        }
    }
}