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
    public partial class frmNotationCorrectionDetails : Form
    {
        private readonly APIService _serviceNotationCorrections = new APIService("NotationCorrections");
        private readonly int _id;
        private Model.Requests.NotationCorrectionsUpdateRequest request = new Model.Requests.NotationCorrectionsUpdateRequest();
        private Model.NotationCorrections entity;

        public frmNotationCorrectionDetails(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmNotationCorrectionDetails_Load(object sender, EventArgs e)
        {
            entity = await _serviceNotationCorrections.GetById<Model.NotationCorrections>(_id);
            if (entity != null)
            {
                lblTuning.Text = entity.Notation.Tuning;
                lblTuningDescription.Text = entity.Notation.TuningDescription;

                if (entity.NotationContent.Contains('\r') && entity.NotationContent.Contains('\n') == false)
                {
                    txtContent.Text = entity.NotationContent.Replace("\r", "\r\n");
                }
                else
                {
                    txtContent.Text = entity.NotationContent;
                }
                lblSong.Text = entity.Notation.Song.Name;
                lblNotationType.Text = entity.Notation.Type.ToString();
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            request.NotationContent = txtContent.Text;
            request.Approved = true;

            entity = await _serviceNotationCorrections.Update<Model.NotationCorrections>(_id, request);

            if (entity != null)
            {
                MessageBox.Show("Notation correction accepted");
                Close();
            }

        }
        private async void BtnReject_Click(object sender, EventArgs e)
        {
            request.Approved = false;

            entity = await _serviceNotationCorrections.Update<Model.NotationCorrections>(_id, request);

            if (entity != null)
            {
                MessageBox.Show("Notation correction rejected");
                DialogResult = DialogResult.OK;
            }
        }

    }
}
