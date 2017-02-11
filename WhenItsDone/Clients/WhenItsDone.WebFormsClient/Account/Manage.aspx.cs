using System;
using System.Collections.Generic;
using System.Web.UI;

namespace WhenItsDone.WebFormsClient.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        private const string ManageProfilePictureUserControlId = "ManageProfilePictureUserControl";
        private const string UpdatePersonalInformationUserControlId = "UpdatePersonalInformationUserControl";
        private const string UpdateMedicalInformationUserControlId = "UpdateMedicalInformationUserControl";
        private const string UpdateContactInformationUserControlId = "UpdateContactInformationUserControl";

        private IDictionary<string, Control> manageControls;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.manageControls = this.BuildManageControlsDictionary();
            
            if (!this.IsPostBack)
            {
                this.ProfilePictureButtonClick(null, null);
            }
        }

        protected void ProfilePictureButtonClick(object sender, EventArgs e)
        {
            this.HideAllActivePanelControls();
            this.ActiveContent.Controls.Add(this.manageControls[Manage.ManageProfilePictureUserControlId]);
        }

        protected void PersonalInformationButtonClick(object sender, EventArgs e)
        {
            this.HideAllActivePanelControls();
            this.ActiveContent.Controls.Add(this.manageControls[Manage.UpdatePersonalInformationUserControlId]);
        }

        protected void MedicalInformationButtonClick(object sender, EventArgs e)
        {
            this.HideAllActivePanelControls();
            this.ActiveContent.Controls.Add(this.manageControls[Manage.UpdateMedicalInformationUserControlId]);
        }

        protected void ContactInformationButtonClick(object sender, EventArgs e)
        {
            this.HideAllActivePanelControls();
            this.ActiveContent.Controls.Add(this.manageControls[Manage.UpdateContactInformationUserControlId]);
        }

        private IDictionary<string, Control> BuildManageControlsDictionary()
        {
            var manageControls = new Dictionary<string, Control>();

            var controlsCount = this.ActiveContent.Controls.Count;
            for (int i = controlsCount - 1; i >= 0; i--)
            {
                Control control = this.ActiveContent.Controls[i];
                if (control.ID.Contains("UserControl"))
                {
                    manageControls.Add(control.ID, control);
                }

                this.ActiveContent.Controls.RemoveAt(i);
            }

            return manageControls;
        }

        private void HideAllActivePanelControls()
        {
            var controlsCount = this.ActiveContent.Controls.Count;
            for (int i = controlsCount - 1; i >= 0; i--)
            {
                this.ActiveContent.Controls.RemoveAt(i);
            }
        }
    }
}