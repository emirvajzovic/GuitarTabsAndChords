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
    public partial class frmGenreDetails : Form
    {
        private readonly APIService _serviceGenres = new APIService("Genres");
        private readonly int _id;
        private Model.Requests.GenresInsertRequest request = new Model.Requests.GenresInsertRequest();
        private Model.Genres entity;

        public frmGenreDetails(int id = 0)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmGenreDetails_Load(object sender, EventArgs e)
        {
            if (_id != 0)
            {
                entity = await _serviceGenres.GetById<Model.Genres>(_id);
                if (entity != null)
                {
                    if (entity.Status == Model.ReviewStatus.Pending)
                    {
                        btnSave.Text = "Approve";
                        btnReject.Visible = true;
                    }

                    txtName.Text = entity.Name;
                }
            }
        }


        private async void BtnSave_Click(object sender, EventArgs e)
        {
            request.Name = txtName.Text;
            request.Status = Model.ReviewStatus.Approved;

            if (_id == 0)
            {
                entity = await _serviceGenres.Insert<Model.Genres>(request);

                if (entity != null)
                {
                    MessageBox.Show("Genre added");
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                entity = await _serviceGenres.Update<Model.Genres>(_id, request);

                if (entity != null)
                {
                    MessageBox.Show("Genre updated");
                    DialogResult = DialogResult.OK;
                }
            }

        }

        private async void BtnReject_Click(object sender, EventArgs e)
        {
            request.Name = txtName.Text;
            request.Status = Model.ReviewStatus.Rejected;

            entity = await _serviceGenres.Update<Model.Genres>(_id, request);

            if (entity != null)
            {
                MessageBox.Show("Genre rejected");
                DialogResult = DialogResult.OK;
            }
        }
    }
}
