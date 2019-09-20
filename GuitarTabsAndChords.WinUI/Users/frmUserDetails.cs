using GuitarTabsAndChords.WinUI.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
                    Close();
                }
            }
            else
            {
                var entity = await _serviceUsers.Update<Model.Users>(_id, request);

                if (entity != null)
                {
                    MessageBox.Show("Admin updated");
                    Close();
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
    }
}
