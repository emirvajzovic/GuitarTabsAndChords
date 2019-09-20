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
    public partial class frmNotationDetails : Form
    {
        private readonly APIService _serviceNotations = new APIService("Notations");
        private readonly APIService _serviceSongs = new APIService("Songs");
        private readonly APIService _serviceArtists = new APIService("Artists");
        private readonly APIService _serviceAlbums = new APIService("Albums");
        private readonly APIService _serviceGenres = new APIService("Genres");
        private readonly int _id;
        private Model.Requests.NotationsInsertRequest request = new Model.Requests.NotationsInsertRequest();
        private Model.Notations entity;

        public frmNotationDetails(int id = 0)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmNotationDetails_Load(object sender, EventArgs e)
        {
            if (_id != 0)
            {
                entity = await _serviceNotations.GetById<Model.Notations>(_id);
                if (entity != null)
                {
                    if (entity.Status == Model.ReviewStatus.Pending)
                    {
                        btnSave.Text = "Approve";
                        btnReject.Visible = true;
                    }

                    //txtName.Text = entity.Name;
                    //txtYear.Text = entity.Year.ToString();

                    await LoadCmbSongs();

                    foreach (var item in cmbArtist.Items)
                    {
                        if ((item as Model.Songs).Id == entity.SongId)
                        {
                            cmbArtist.SelectedItem = item;
                            break;
                        }
                    }

                }
            }
            else
            {
                await LoadCmbSongs();
            }
        }

        private async Task LoadCmbSongs()
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

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            //request.Name = txtName.Text;
            //request.Year = int.Parse(txtYear.Text);
            //request.ArtistId = (cmbArtist.SelectedItem as Model.Artists).Id;
            //request.AlbumId = (cmbAlbum.SelectedItem as Model.Albums).Id;
            //request.GenreId = (cmbGenre.SelectedItem as Model.Genres).Id;
            request.Status = Model.ReviewStatus.Approved;

            if (_id == 0)
            {
                entity = await _serviceNotations.Insert<Model.Notations>(request);

                if (entity != null)
                {
                    MessageBox.Show("Notation added");
                    Close();
                }
            }
            else
            {
                entity = await _serviceNotations.Update<Model.Notations>(_id, request);

                if (entity != null)
                {
                    MessageBox.Show("Notation updated");
                    Close();
                }
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
                await LoadCmbSongs();
        }

        private async void BtnReject_Click(object sender, EventArgs e)
        {
            //request.Name = txtName.Text;
            //request.ArtistId = (cmbArtist.SelectedItem as Model.Artists).Id;
            //request.AlbumId = (cmbAlbum.SelectedItem as Model.Albums).Id;
            //request.GenreId = (cmbGenre.SelectedItem as Model.Genres).Id;
            request.Status = Model.ReviewStatus.Rejected;

            entity = await _serviceNotations.Update<Model.Notations>(_id, request);

            if (entity != null)
            {
                MessageBox.Show("Genre rejected");
                DialogResult = DialogResult.OK;
            }
        }
    }
}
