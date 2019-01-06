using System;
using System.Windows.Forms;
using Neasure.Properties;

namespace Neasure
{
    public partial class FirebaseForm : Form
    {
        Database db = new Database();
        private string _pingFile;
        private string _speedFile;

        public FirebaseForm(string pingFile, string speedFile)
        {
            InitializeComponent();
            _pingFile = pingFile;
            _speedFile = speedFile;
        }

        private void dropdownCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                btnSend.Enabled = false;
                btnCancel.Enabled = false;

                var send = db.Send(dropdownCountry.Text, textCity.Text, textPostal.Text, dropdownISP.Text,
                    dropdownType.Text, dropdownSpeed.Text, _pingFile, _speedFile);

                await send;

                if (send.Result == 1)
                {
                    MessageBox.Show(Resources.Info_UploadComplete, Resources.InfoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show(Resources.Info_UploadUnsuccessful, Resources.InfoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.Error_FirebaseSend + ex.Message, Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
