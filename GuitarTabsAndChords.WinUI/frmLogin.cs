using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuitarTabsAndChords.WinUI
{
    public partial class frmLogin : Form
    {
        APIService _service = new APIService("Users");

        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            APIService.Username = txtUsername.Text;
            APIService.Password = txtPassword.Text;
            try
            {
                APIService.CurrentUser = await _service.Get<Model.Users>(null, "MyProfile");

                if(APIService.CurrentUser.Role.Name != "Administrator")
                {
                    MessageBox.Show("You don't have permission for this operation.", "Forbidden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception)
            {

            }

        }
    }
}
