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
    public partial class frmSongs : Form
    {
        private readonly APIService _serviceSongs = new APIService("Songs");
        public frmSongs()
        {
            InitializeComponent();
        }

        private void frmSongs_Load(object sender, EventArgs e)
        {
            cmbStatusFilter.Items.Add(new FilterItem { Id = null, Name = "All" });
            int counter = 0;
            foreach (string name in Enum.GetNames(typeof(ReviewStatus)))
            {
                if (!name.Contains("Filter"))
                    cmbStatusFilter.Items.Add(new FilterItem { Id = counter++, Name = name });
            }
            cmbStatusFilter.ValueMember = "Id";
            cmbStatusFilter.DisplayMember = "Name";
            cmbStatusFilter.SelectedIndex = 0;
        }

        private async void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            await loadSongs();
        }

        private async Task loadSongs()
        {
            var request = new Model.Requests.SongsSearchRequest
            {
                SearchTerm = txtSearch.Text,
                Filter = (cmbStatusFilter.SelectedItem as FilterItem).Id
            };
            var list = await _serviceSongs.Get<List<Model.Songs>>(request);

            foreach (var item in list)
            {
                if (item.Status == Model.ReviewStatus.Rejected)
                    item.Status = Model.ReviewStatus.Pending;
            }
            dgvSongs.AutoGenerateColumns = false;
            dgvSongs.DataSource = list;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new frmSongDetails();
            frm.ShowDialog();

            await loadSongs();
        }

        private async void DgvSongs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dgvSongs.SelectedRows[0].Cells["Id"].Value.ToString());
            var frm = new frmSongDetails(id);
            frm.ShowDialog();

            await loadSongs();
        }

        private async void CmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await loadSongs();
        }
    }
}
