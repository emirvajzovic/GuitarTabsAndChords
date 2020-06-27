using GuitarTabsAndChords.WinUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuitarTabsAndChords.WinUI
{
    public partial class frmUserDetails : Form
    {
        private readonly APIService _serviceUsers = new APIService("Users");
        private readonly int _id;
        Model.Requests.UsersInsertRequest request = new Model.Requests.UsersInsertRequest();

        public frmUserDetails(int id = 0)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmUserDetails_Load(object sender, EventArgs e)
        {
            if (_id != 0)
            {
                var entity = await _serviceUsers.GetById<Model.Users>(_id);
                if (entity != null)
                {
                    txtUsername.Text = entity.Username;
                    txtEmail.Text = entity.Email;
                    txtFirstName.Text = entity.Name;
                    txtLastName.Text = entity.LastName;
                    if(entity.DateOfBirth.Date.Year < 1900)
                    {
                        entity.DateOfBirth = new DateTime(1900, 1, 1);
                    }
                    dtpDateOfBirth.Value = entity.DateOfBirth.Date;
                    if(entity.ProfilePicture.Length > 0)
                    {
                        MemoryStream ms = new MemoryStream(entity.ProfilePicture);
                        pictureBox.Image = Image.FromStream(ms);
                        request.ProfilePicture = entity.ProfilePicture;
                    }
                    else
                    {
                        MemoryStream ms = new MemoryStream(ImageHelper.GetDefaultProfileImage());
                        pictureBox.Image = Image.FromStream(ms);
                    }
                }
            }
        }


        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            request.DateOfBirth = dtpDateOfBirth.Value.Date;
            request.Username = txtUsername.Text;
            request.Email = txtEmail.Text;
            request.Name = txtFirstName.Text;
            request.LastName = txtLastName.Text;
            request.Password = txtPassword.Text;
            request.PasswordConfirmation = txtPasswordConfirm.Text;

            if (_id == 0)
            {
                var entity = await _serviceUsers.Insert<Model.Users>(request, "InsertAdmin");

                if (entity != null)
                {
                    MessageBox.Show("Admin added");
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                var entity = await _serviceUsers.Update<Model.Users>(_id, request);

                if (entity != null)
                {
                    MessageBox.Show("User updated");
                    DialogResult = DialogResult.OK;
                }
            }

        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;

                var file = File.ReadAllBytes(fileName);

                request.ProfilePicture = file;

                Image image = Image.FromFile(fileName);
                pictureBox.Image = image;
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "This field is required.");
            }
            else if(txtUsername.Text.Length < 2)
            {
                errorProvider1.SetError(txtUsername, "The minimum required length is 2.");
            }
            else
            {
                errorProvider1.SetError(txtUsername, null);
                return;
            }
            e.Cancel = true;
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "This field is required.");
            }
            else
            {
                try
                {
                    MailAddress address = new MailAddress(txtEmail.Text);

                    errorProvider1.SetError(txtEmail, null);
                    return;
                }
                catch (Exception)
                {
                    errorProvider1.SetError(txtEmail, "A valid email address is required.");
                }
            }
            e.Cancel = true;
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (_id == 0 && string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "This field is required.");
            }
            else if ((_id == 0 || !string.IsNullOrEmpty(txtPassword.Text))  && txtPassword.Text.Length < 8)
            {
                errorProvider1.SetError(txtPassword, "The minimum required length is 8.");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
                return;
            }
            e.Cancel = true;
        }

        private void txtPasswordConfirm_Validating(object sender, CancelEventArgs e)
        {
            if ((_id == 0 || !string.IsNullOrEmpty(txtPassword.Text)) && string.IsNullOrEmpty(txtPasswordConfirm.Text))
            {
                errorProvider1.SetError(txtPasswordConfirm, "This field is required.");
            }
            else if ((_id == 0 || !string.IsNullOrEmpty(txtPassword.Text)) && txtPassword.Text != txtPasswordConfirm.Text)
            {
                errorProvider1.SetError(txtPasswordConfirm, "The passwords must match.");
            }
            else
            {
                errorProvider1.SetError(txtPasswordConfirm, null);
                return;
            }
            e.Cancel = true;
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorProvider1.SetError(txtFirstName, "This field is required.");
            }
            else if (txtFirstName.Text.Length < 2)
            {
                errorProvider1.SetError(txtFirstName, "The minimum required length is 2.");
            }
            else
            {
                errorProvider1.SetError(txtFirstName, null);
                return;
            }
            e.Cancel = true;
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorProvider1.SetError(txtLastName, "This field is required.");
            }
            else if (txtLastName.Text.Length < 2)
            {
                errorProvider1.SetError(txtLastName, "The minimum required length is 2.");
            }
            else
            {
                errorProvider1.SetError(txtLastName, null);
                return;
            }
            e.Cancel = true;
        }
    }
}
