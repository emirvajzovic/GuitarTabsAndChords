using GuitarTabsAndChords.Model;
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
    public partial class frmAlbumDetails : Form
    {
        private readonly APIService _serviceAlbums = new APIService("Albums");
        private readonly APIService _serviceArtists = new APIService("Artists");
        private readonly int _id;
        private Model.Requests.AlbumsInsertRequest request = new Model.Requests.AlbumsInsertRequest();
        private Model.Albums entity;

        public frmAlbumDetails(int id = 0)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmAlbumDetails_Load(object sender, EventArgs e)
        {
            if (_id != 0)
            {
                entity = await _serviceAlbums.GetById<Model.Albums>(_id);
                if (entity != null)
                {
                    if (entity.Status == Model.ReviewStatus.Pending)
                    {
                        btnSave.Text = "Approve";
                        btnReject.Visible = true;
                    }

                    txtName.Text = entity.Name;
                    txtYear.Text = entity.Year.ToString();
                    foreach (var item in cmbArtist.Items)
                    {
                        if ((item as Model.Artists).Id == entity.ArtistId)
                        {
                            cmbArtist.SelectedItem = item;
                            break;
                        }
                    }

                    LoadPicture();

                }
            }
            await LoadCmbArtists();
        }

        private void LoadPicture()
        {
            if (entity.AlbumCover.Length > 0)
            {
                MemoryStream ms = new MemoryStream(entity.AlbumCover);
                pictureBox.Image = Image.FromStream(ms);
                request.AlbumCover = entity.AlbumCover;
            }
            else
            {
                MemoryStream ms = new MemoryStream(ImageHelper.GetDefaultAlbumArt());
                pictureBox.Image = Image.FromStream(ms);
            }
        }

        private async Task LoadCmbArtists()
        {
            bool isPending = (entity != null && entity.Status == ReviewStatus.Pending);

            var request = new Model.Requests.ArtistsSearchRequest
            {
                Filter = isPending
                        ? (int)ReviewStatus.FilterPendingApproved
                        : (int)ReviewStatus.Approved
            };
            var list = await _serviceArtists.Get<List<Model.Artists>>(request);
            if (isPending)
            {
                foreach (var item in list)
                {
                    if (item.Status == ReviewStatus.Pending)
                        item.Name = "(PENDING) " + item.Name;
                }
            }
            cmbArtist.DataSource = list;
            cmbArtist.ValueMember = "Id";
            cmbArtist.DisplayMember = "Name";

            if(entity != null)
            {
                foreach (var item in list)
                {
                    if (item.Id == entity.ArtistId)
                    {
                        cmbArtist.SelectedItem = item;
                        break;
                    }
                }
            }
        }


        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            request.Name = txtName.Text;
            request.Year = int.Parse(txtYear.Text);
            request.ArtistId = (cmbArtist.SelectedItem as Model.Artists).Id;
            request.Status = Model.ReviewStatus.Approved;

            if (_id == 0)
            {
                entity = await _serviceAlbums.Insert<Model.Albums>(request);

                if (entity != null)
                {
                    MessageBox.Show("Album added");
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                entity = await _serviceAlbums.Update<Model.Albums>(_id, request);

                if (entity != null)
                {
                    MessageBox.Show("Album updated");
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

                request.AlbumCover = file;

                Image image = Image.FromFile(fileName);
                pictureBox.Image = image;
            }
        }

        private async void BtnAddArtist_Click(object sender, EventArgs e)
        {
            var SelectedArtist = cmbArtist.SelectedItem as Model.Artists;
            frmArtistDetails frm = new frmArtistDetails();
            if (SelectedArtist != null && SelectedArtist.Status == ReviewStatus.Pending)
            {
                frm = new frmArtistDetails(SelectedArtist.Id);
            }

            if (frm.ShowDialog() == DialogResult.OK)
                await LoadCmbArtists();
        }

        private async void BtnReject_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            request.Name = txtName.Text;
            request.Year = int.Parse(txtYear.Text);
            request.ArtistId = (cmbArtist.SelectedItem as Model.Artists).Id;
            request.Status = Model.ReviewStatus.Rejected;

            entity = await _serviceAlbums.Update<Model.Albums>(_id, request);

            if (entity != null)
            {
                MessageBox.Show("Album rejected");
                DialogResult = DialogResult.OK;
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtName.Text))
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

        private void txtYear_Validating(object sender, CancelEventArgs e)
        {
            int minYear = 1930;

            if (string.IsNullOrWhiteSpace(txtYear.Text))
            {
                errorProvider1.SetError(txtYear, "This field is required.");
            }
            else if(!int.TryParse(txtYear.Text, out int year) || year < minYear || year > DateTime.Now.Year)
            {
                errorProvider1.SetError(txtYear, "You need to enter a number between " + minYear + " and " + DateTime.Now.Year + ".");
            }
            else
            {
                errorProvider1.SetError(txtYear, null);
                return;
            }
            e.Cancel = true;
        }
    }
}
