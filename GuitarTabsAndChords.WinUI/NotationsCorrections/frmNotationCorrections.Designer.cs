namespace GuitarTabsAndChords.WinUI
{
    partial class frmNotationCorrections
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvNotationCorrections = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Song = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateSubmitted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotationCorrections)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvNotationCorrections
            // 
            this.dgvNotationCorrections.AllowUserToAddRows = false;
            this.dgvNotationCorrections.AllowUserToDeleteRows = false;
            this.dgvNotationCorrections.BackgroundColor = System.Drawing.Color.White;
            this.dgvNotationCorrections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotationCorrections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Song,
            this.DateSubmitted,
            this.User});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNotationCorrections.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNotationCorrections.Location = new System.Drawing.Point(8, 23);
            this.dgvNotationCorrections.Margin = new System.Windows.Forms.Padding(4);
            this.dgvNotationCorrections.MultiSelect = false;
            this.dgvNotationCorrections.Name = "dgvNotationCorrections";
            this.dgvNotationCorrections.ReadOnly = true;
            this.dgvNotationCorrections.RowHeadersWidth = 51;
            this.dgvNotationCorrections.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvNotationCorrections.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNotationCorrections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotationCorrections.Size = new System.Drawing.Size(1264, 398);
            this.dgvNotationCorrections.TabIndex = 0;
            this.dgvNotationCorrections.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvNotationCorrections_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvNotationCorrections);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(16, 19);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1279, 427);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pending Notation Corrections";
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            this.Id.Width = 125;
            // 
            // Song
            // 
            this.Song.DataPropertyName = "Notation";
            this.Song.HeaderText = "Song name";
            this.Song.MinimumWidth = 6;
            this.Song.Name = "Song";
            this.Song.ReadOnly = true;
            this.Song.Width = 220;
            // 
            // DateSubmitted
            // 
            this.DateSubmitted.DataPropertyName = "DateSubmitted";
            this.DateSubmitted.HeaderText = "Date submitted";
            this.DateSubmitted.MinimumWidth = 6;
            this.DateSubmitted.Name = "DateSubmitted";
            this.DateSubmitted.ReadOnly = true;
            this.DateSubmitted.Width = 180;
            // 
            // User
            // 
            this.User.DataPropertyName = "User";
            this.User.HeaderText = "User";
            this.User.MinimumWidth = 6;
            this.User.Name = "User";
            this.User.ReadOnly = true;
            this.User.Width = 125;
            // 
            // frmNotationCorrections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1311, 469);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmNotationCorrections";
            this.Text = "Notation Corrections";
            this.Load += new System.EventHandler(this.frmNotationCorrections_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotationCorrections)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNotationCorrections;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Song;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateSubmitted;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
    }
}