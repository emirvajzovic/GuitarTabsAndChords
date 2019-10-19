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
    public partial class frmUsers : Form
    {
        private readonly APIService _serviceUsers = new APIService("Users");
        public frmUsers()
        {
            InitializeComponent();
        }

        private async void frmUsers_Load(object sender, EventArgs e)
        {
            await loadUsers();
        }

        private async void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            await loadUsers();
        }

        private async Task loadUsers()
        {
            var request = new Model.Requests.UsersSearchRequest
            {
                Search = txtSearch.Text
            };
            var list = await _serviceUsers.Get<List<Model.Users>>(request);
            foreach (var item in list)
            {
                if(item.ProfilePicture.Length == 0)
                {
                    item.ProfilePicture = ImageHelper.GetDefaultProfileImage();
                }
            }

            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.DataSource = list;
        }



        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            var frm = new frmUserDetails();
            if (frm.ShowDialog() == DialogResult.OK)
                await loadUsers();
        }

        private async void DgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dgvUsers.SelectedRows[0].Cells["Id"].Value.ToString());
            var frm = new frmUserDetails(id);
            if(frm.ShowDialog() == DialogResult.OK)
                await loadUsers();
        }
    }
}
