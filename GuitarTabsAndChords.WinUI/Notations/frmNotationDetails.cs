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

                    txtTuning.Text = entity.Tuning;
                    txtTuningDescription.Text = entity.TuningDescription;
                    txtContent.Text = entity.NotationContent;

                    await LoadCmbSongs();
                    LoadNotationTypes();

                    foreach (var item in cmbSong.Items)
                    {
                        if ((item as Model.Songs).Id == entity.SongId)
                        {
                            cmbSong.SelectedItem = item;
                            break;
                        }
                    }
                    foreach (var item in cmbNotationType.Items)
                    {
                        if ((NotationType)item == entity.Type)
                        {
                            cmbNotationType.SelectedItem = item;
                            break;
                        }
                    }

                }
            }
            else
            {
                await LoadCmbSongs();
                LoadNotationTypes();
            }
        }

        private async Task LoadCmbSongs()
        {
            bool isPending = (entity != null && entity.Status == ReviewStatus.Pending);

            var request = new Model.Requests.SongsSearchRequest
            {
                Filter = isPending
                        ? (int)ReviewStatus.FilterPendingApproved
                        : (int)ReviewStatus.Approved
            };
            var list = await _serviceSongs.Get<List<Model.Songs>>(request);
            if (isPending)
            {
                foreach (var item in list)
                {
                    if (item.Status == ReviewStatus.Pending)
                        item.Name = "(PENDING) " + item.Name;
                }
            }
            cmbSong.DataSource = list;
            cmbSong.ValueMember = "Id";
            cmbSong.DisplayMember = "Name";
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            request.NotationContent = txtContent.Text;
            request.Tuning = txtTuning.Text;
            request.TuningDescription = txtTuningDescription.Text;
            request.SongId = (cmbSong.SelectedItem as Model.Songs).Id;
            request.Type = (NotationType)cmbNotationType.SelectedItem;

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

        private async void BtnAddSong_Click(object sender, EventArgs e)
        {
            var SelectedSong = cmbSong.SelectedItem as Model.Songs;
            frmSongDetails frm = new frmSongDetails();
            if (SelectedSong != null && SelectedSong.Status == ReviewStatus.Pending)
            {
                frm = new frmSongDetails(SelectedSong.Id);
            }

            if (frm.ShowDialog() == DialogResult.OK)
                await LoadCmbSongs();
        }

        private async void BtnReject_Click(object sender, EventArgs e)
        {
            request.NotationContent = txtContent.Text;
            request.Tuning = txtTuning.Text;
            request.TuningDescription = txtTuningDescription.Text;
            request.SongId = (cmbSong.SelectedItem as Model.Songs).Id;
            request.Type = (NotationType)cmbNotationType.SelectedItem;

            request.Status = Model.ReviewStatus.Rejected;

            entity = await _serviceNotations.Update<Model.Notations>(_id, request);

            if (entity != null)
            {
                MessageBox.Show("Notation rejected");
                DialogResult = DialogResult.OK;
            }
        }

        private void LoadNotationTypes()
        {
            cmbNotationType.DataSource = Enum.GetValues(typeof(NotationType));
        }
    }
}
