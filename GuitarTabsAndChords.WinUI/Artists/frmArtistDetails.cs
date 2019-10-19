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
    public partial class frmArtistDetails : Form
    {
        private readonly APIService _serviceArtists = new APIService("Artists");
        private readonly int _id;
        private Model.Requests.ArtistsInsertRequest request = new Model.Requests.ArtistsInsertRequest();
        private Model.Artists entity;

        public frmArtistDetails(int id = 0)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmArtistDetails_Load(object sender, EventArgs e)
        {
            if (_id != 0)
            {
                entity = await _serviceArtists.GetById<Model.Artists>(_id);
                if (entity != null)
                {
                    if (entity.Status == Model.ReviewStatus.Pending)
                    {
                        btnSave.Text = "Approve";
                        btnReject.Visible = true;
                    }

                    txtName.Text = entity.Name;
                }
            }
        }


        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            request.Name = txtName.Text;
            request.Status = Model.ReviewStatus.Approved;

            if (_id == 0)
            {
                entity = await _serviceArtists.Insert<Model.Artists>(request);

                if (entity != null)
                {
                    MessageBox.Show("Artist added");
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                entity = await _serviceArtists.Update<Model.Artists>(_id, request);

                if (entity != null)
                {
                    MessageBox.Show("Artist updated");
                    DialogResult = DialogResult.OK;
                }
            }

        }

        private async void BtnReject_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            request.Name = txtName.Text;
            request.Status = Model.ReviewStatus.Rejected;

            entity = await _serviceArtists.Update<Model.Artists>(_id, request);

            if (entity != null)
            {
                MessageBox.Show("Artist rejected");
                DialogResult = DialogResult.OK;
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider1.SetError(txtName, "This field is required.");
            }
            else
            {
                errorProvider1.SetError(txtName, null);
                return;
            }
            e.Cancel = true;
        }
    }
}
