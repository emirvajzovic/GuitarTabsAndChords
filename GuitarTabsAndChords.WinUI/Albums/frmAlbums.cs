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
    public partial class frmAlbums : Form
    {
        private readonly APIService _serviceAlbums = new APIService("Albums");
        public frmAlbums()
        {
            InitializeComponent();
        }

        private void frmAlbums_Load(object sender, EventArgs e)
        {
            cmbStatusFilter.Items.Add(new FilterItem { Id = null, Name = "All" });
            int counter = 0;
            foreach (string name in Enum.GetNames(typeof(ReviewStatus)))
            {
                cmbStatusFilter.Items.Add(new FilterItem { Id = counter++, Name = name });
            }
            cmbStatusFilter.ValueMember = "Id";
            cmbStatusFilter.DisplayMember = "Name";
            cmbStatusFilter.SelectedIndex = 0;
        }

        private async void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            await loadAlbums();
        }

        private async Task loadAlbums()
        {
            var request = new Model.Requests.AlbumsSearchRequest
            {
                Name = txtSearch.Text,
                Filter = (cmbStatusFilter.SelectedItem as FilterItem).Id
            };
            var list = await _serviceAlbums.Get<List<Model.Albums>>(request);
            foreach (var item in list)
            {
                if (item.AlbumCover.Length == 0)
                {
                    item.AlbumCover = ImageHelper.GetDefaultAlbumArt();
                }
                if (item.Status == Model.ReviewStatus.Rejected)
                {
                    item.Status = Model.ReviewStatus.Pending;
                }
            }
            dgvAlbums.AutoGenerateColumns = false;
            dgvAlbums.DataSource = list;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new frmAlbumDetails();
            frm.ShowDialog();

            await loadAlbums();
        }

        private async void DgvAlbums_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dgvAlbums.SelectedRows[0].Cells["Id"].Value.ToString());
            var frm = new frmAlbumDetails(id);
            frm.ShowDialog();

            await loadAlbums();
        }

        private async void CmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await loadAlbums();
        }
    }
}
