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
    public partial class frmSongDetails : Form
    {
        private readonly APIService _serviceSongs = new APIService("Songs");
        private readonly APIService _serviceArtists = new APIService("Artists");
        private readonly APIService _serviceAlbums = new APIService("Albums");
        private readonly APIService _serviceGenres = new APIService("Genres");
        private readonly int _id;
        private Model.Requests.SongsInsertRequest request = new Model.Requests.SongsInsertRequest();
        private Model.Songs entity;

        public frmSongDetails(int id = 0)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmSongDetails_Load(object sender, EventArgs e)
        {
            if (_id != 0)
            {
                entity = await _serviceSongs.GetById<Model.Songs>(_id);
                if (entity != null)
                {
                    if (entity.Status == Model.ReviewStatus.Pending)
                    {
                        btnSave.Text = "Approve";
                        btnReject.Visible = true;
                    }

                    txtName.Text = entity.Name;
                    txtYear.Text = entity.Year.ToString();

                    await LoadCmbArtists();

                    foreach (var item in cmbArtist.Items)
                    {
                        if ((item as Model.Artists).Id == entity.ArtistId)
                        {
                            cmbArtist.SelectedItem = item;
                            break;
                        }
                    }

                    await LoadCmbAlbums();

                    foreach (var item in cmbAlbum.Items)
                    {
                        if ((item as Model.Albums).Id == entity.AlbumId)
                        {
                            cmbAlbum.SelectedItem = item;
                            break;
                        }
                    }

                    await LoadCmbGenres();

                    foreach (var item in cmbGenre.Items)
                    {
                        if ((item as Model.Genres).Id == entity.GenreId)
                        {
                            cmbGenre.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
            else
            {
                await LoadCmbArtists();
                await LoadCmbGenres();
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
        }
        private async Task LoadCmbAlbums()
        {
            var SelectedArtist = cmbArtist.SelectedItem as Model.Artists;
            if (SelectedArtist == null)
                return;

            bool isPending = (entity != null && entity.Status == ReviewStatus.Pending);

            var request = new Model.Requests.AlbumsSearchRequest
            {
                ArtistId = SelectedArtist.Id,
                Filter = isPending
                        ? (int)ReviewStatus.FilterPendingApproved
                        : (int)ReviewStatus.Approved
            };

            var list = await _serviceAlbums.Get<List<Model.Albums>>(request);
            if (isPending)
            {
                foreach (var item in list)
                {
                    if (item.Status == ReviewStatus.Pending)
                        item.Name = "(PENDING) " + item.Name;
                }
            }
            cmbAlbum.DataSource = list;
            cmbAlbum.ValueMember = "Id";
            cmbAlbum.DisplayMember = "Name";
        }
        private async Task LoadCmbGenres()
        {
            bool isPending = (entity != null && entity.Status == ReviewStatus.Pending);

            var request = new Model.Requests.GenresSearchRequest
            {
                Filter = isPending
                        ? (int)ReviewStatus.FilterPendingApproved
                        : (int)ReviewStatus.Approved
            };
            var list = await _serviceGenres.Get<List<Model.Genres>>(request);
            if (isPending)
            {
                foreach (var item in list)
                {
                    if (item.Status == ReviewStatus.Pending)
                        item.Name = "(PENDING) " + item.Name;
                }
            }
            cmbGenre.DataSource = list;
            cmbGenre.ValueMember = "Id";
            cmbGenre.DisplayMember = "Name";
        }


        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            request.Name = txtName.Text;
            request.Year = int.Parse(txtYear.Text);
            request.ArtistId = (cmbArtist.SelectedItem as Model.Artists).Id;
            request.AlbumId = (cmbAlbum.SelectedItem as Model.Albums).Id;
            request.GenreId = (cmbGenre.SelectedItem as Model.Genres).Id;
            request.Status = Model.ReviewStatus.Approved;

            if (_id == 0)
            {
                entity = await _serviceSongs.Insert<Model.Songs>(request);

                if (entity != null)
                {
                    MessageBox.Show("Song added");
                    Close();
                }
            }
            else
            {
                entity = await _serviceSongs.Update<Model.Songs>(_id, request);

                if (entity != null)
                {
                    MessageBox.Show("Song updated");
                    Close();
                }
            }

        }

        private async void CmbArtist_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadCmbAlbums();
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

        private async void BtnAddAlbum_Click(object sender, EventArgs e)
        {
            var SelectedAlbum = cmbAlbum.SelectedItem as Model.Albums;
            frmAlbumDetails frm = new frmAlbumDetails();
            if (SelectedAlbum != null && SelectedAlbum.Status == ReviewStatus.Pending)
            {
                frm = new frmAlbumDetails(SelectedAlbum.Id);
            }

            if (frm.ShowDialog() == DialogResult.OK)
                await LoadCmbAlbums();
        }

        private async void BtnAddGenre_Click(object sender, EventArgs e)
        {
            var SelectedGenre = cmbGenre.SelectedItem as Model.Genres;
            frmGenreDetails frm = new frmGenreDetails();
            if (SelectedGenre != null && SelectedGenre.Status == ReviewStatus.Pending)
            {
                frm = new frmGenreDetails(SelectedGenre.Id);
            }

            if (frm.ShowDialog() == DialogResult.OK)
                await LoadCmbGenres();
        }

        private async void BtnReject_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            request.Name = txtName.Text;
            request.Year = int.Parse(txtYear.Text);
            request.ArtistId = (cmbArtist.SelectedItem as Model.Artists).Id;
            request.AlbumId = (cmbAlbum.SelectedItem as Model.Albums).Id;
            request.GenreId = (cmbGenre.SelectedItem as Model.Genres).Id;
            request.Status = Model.ReviewStatus.Rejected;

            entity = await _serviceSongs.Update<Model.Songs>(_id, request);

            if (entity != null)
            {
                MessageBox.Show("Genre rejected");
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

        private void txtYear_Validating(object sender, CancelEventArgs e)
        {
            int minYear = 1930;

            if (string.IsNullOrWhiteSpace(txtYear.Text))
            {
                errorProvider1.SetError(txtYear, "This field is required.");
            }
            else if (!int.TryParse(txtYear.Text, out int year) || year < minYear || year > DateTime.Now.Year)
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
