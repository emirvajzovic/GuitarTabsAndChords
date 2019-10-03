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
    public partial class frmArtists : Form
    {
        private readonly APIService _serviceArtists = new APIService("Artists");
        public frmArtists()
        {
            InitializeComponent();
        }

        private void frmArtists_Load(object sender, EventArgs e)
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
            await loadArtists();
        }

        private async Task loadArtists()
        {
            var request = new Model.Requests.ArtistsSearchRequest
            {
                Name = txtSearch.Text,
                Filter = (cmbStatusFilter.SelectedItem as FilterItem).Id
            };
            var list = await _serviceArtists.Get<List<Model.Artists>>(request);

            foreach (var item in list)
            {
                if (item.Status == Model.ReviewStatus.Rejected)
                    item.Status = Model.ReviewStatus.Pending;
            }
            dgvArtists.AutoGenerateColumns = false;
            dgvArtists.DataSource = list;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new frmArtistDetails();
            frm.ShowDialog();

            await loadArtists();
        }

        private async void DgvArtists_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dgvArtists.SelectedRows[0].Cells["Id"].Value.ToString());
            var frm = new frmArtistDetails(id);
            frm.ShowDialog();

            await loadArtists();
        }

        private async void CmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await loadArtists();
        }
    }
}
