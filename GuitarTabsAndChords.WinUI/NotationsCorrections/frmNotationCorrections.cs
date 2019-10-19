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
    public partial class frmNotationCorrections : Form
    {
        private readonly APIService _serviceNotationCorrections = new APIService("NotationCorrections");
        public frmNotationCorrections()
        {
            InitializeComponent();
        }

        private async void frmNotationCorrections_Load(object sender, EventArgs e)
        {
            await loadNotationCorrections();
        }

        private async Task loadNotationCorrections()
        {
            var list = await _serviceNotationCorrections.Get<List<Model.NotationCorrections>>(null);

            dgvNotationCorrections.AutoGenerateColumns = false;
            dgvNotationCorrections.DataSource = list;
        }

        private async void DgvNotationCorrections_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dgvNotationCorrections.SelectedRows[0].Cells["Id"].Value.ToString());
            var frm = new frmNotationCorrectionDetails(id);
            frm.ShowDialog();

            await loadNotationCorrections();
        }

  
    }
}
