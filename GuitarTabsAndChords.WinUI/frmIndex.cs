using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuitarTabsAndChords.WinUI
{
    public partial class frmIndex : Form
    {
        public frmIndex()
        {
            InitializeComponent();
        }

        private void btnMusic_Click(object sender, EventArgs e)
        {
            btnGenres.Visible = btnArtists.Visible = btnSongs.Visible = btnAlbums.Visible = btnBack.Visible = true;

            btnMusic.Visible = btnUsers.Visible = btnNotations.Visible = false;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            btnGenres.Visible = btnArtists.Visible = btnSongs.Visible = btnAlbums.Visible = btnBack.Visible = false;

            btnMusic.Visible = btnUsers.Visible = btnNotations.Visible = true;
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            var frm = new frmUsers();
            frm.ShowDialog();
        }

        private void BtnGenres_Click(object sender, EventArgs e)
        {
            var frm = new frmGenres();
            frm.ShowDialog();
        }

        private void BtnAlbums_Click(object sender, EventArgs e)
        {
            var frm = new frmAlbums();
            frm.ShowDialog();
        }

        private void BtnArtists_Click(object sender, EventArgs e)
        {
            var frm = new frmArtists();
            frm.ShowDialog();
        }

        private void BtnSongs_Click(object sender, EventArgs e)
        {
            var frm = new frmSongs();
            frm.ShowDialog();
        }

        private void BtnNotations_Click(object sender, EventArgs e)
        {
            var frm = new frmNotations();
            frm.ShowDialog();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            APIService.Username = null;
            APIService.Password = null;
            APIService.CurrentUser = null;

            frmLogin frm = new frmLogin();
            if (frm.ShowDialog() != DialogResult.OK)
            {
                Close();
            }
        }
    }
}
