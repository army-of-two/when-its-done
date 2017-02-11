using System;

namespace WhenItsDone.WebFormsClient.ViewControls.ManageUserControls
{
    public partial class UpdateMedicalInformationUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.HeightInCmTextBox.Text = string.Empty;
            this.WeightInKgTextBox.Text = string.Empty;
        }

        public void OnUpdateMedicalInformation(object sender, EventArgs e)
        {

        }
    }
}