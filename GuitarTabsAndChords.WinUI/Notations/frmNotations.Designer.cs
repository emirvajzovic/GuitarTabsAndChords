namespace GuitarTabsAndChords.WinUI
{
    partial class frmNotations
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
            this.dgvNotations = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Song = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tuning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastEditted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastEditor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Approved = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotations)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvNotations
            // 
            this.dgvNotations.AllowUserToAddRows = false;
            this.dgvNotations.AllowUserToDeleteRows = false;
            this.dgvNotations.BackgroundColor = System.Drawing.Color.White;
            this.dgvNotations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Song,
            this.Tuning,
            this.Type,
            this.LastEditted,
            this.LastEditor,
            this.Approved});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNotations.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNotations.Location = new System.Drawing.Point(8, 23);
            this.dgvNotations.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvNotations.MultiSelect = false;
            this.dgvNotations.Name = "dgvNotations";
            this.dgvNotations.ReadOnly = true;
            this.dgvNotations.RowHeadersWidth = 51;
            this.dgvNotations.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvNotations.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNotations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNotations.Size = new System.Drawing.Size(1264, 398);
            this.dgvNotations.TabIndex = 0;
            this.dgvNotations.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvNotations_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvNotations);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(16, 71);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1279, 427);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notations";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(997, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(1064, 25);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(229, 22);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtSearch_KeyUp);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(24, 22);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(100, 28);
            this.btnAddUser.TabIndex = 4;
            this.btnAddUser.Text = "Add Notation";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(169, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Status:";
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Location = new System.Drawing.Point(236, 25);
            this.cmbStatusFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(160, 24);
            this.cmbStatusFilter.TabIndex = 7;
            this.cmbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.CmbStatusFilter_SelectedIndexChanged);
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
            this.Song.DataPropertyName = "Song";
            this.Song.HeaderText = "Song name";
            this.Song.MinimumWidth = 6;
            this.Song.Name = "Song";
            this.Song.ReadOnly = true;
            this.Song.Width = 220;
            // 
            // Tuning
            // 
            this.Tuning.DataPropertyName = "Tuning";
            this.Tuning.HeaderText = "Tuning";
            this.Tuning.MinimumWidth = 6;
            this.Tuning.Name = "Tuning";
            this.Tuning.ReadOnly = true;
            this.Tuning.Width = 120;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Type";
            this.Type.HeaderText = "Type";
            this.Type.MinimumWidth = 6;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 125;
            // 
            // LastEditted
            // 
            this.LastEditted.DataPropertyName = "LastEditted";
            this.LastEditted.HeaderText = "Last edited on";
            this.LastEditted.MinimumWidth = 6;
            this.LastEditted.Name = "LastEditted";
            this.LastEditted.ReadOnly = true;
            this.LastEditted.Width = 180;
            // 
            // LastEditor
            // 
            this.LastEditor.DataPropertyName = "LastEditor";
            this.LastEditor.HeaderText = "Last edited by";
            this.LastEditor.MinimumWidth = 6;
            this.LastEditor.Name = "LastEditor";
            this.LastEditor.ReadOnly = true;
            this.LastEditor.Width = 125;
            // 
            // Approved
            // 
            this.Approved.DataPropertyName = "Status";
            this.Approved.FalseValue = "0";
            this.Approved.HeaderText = "Approved";
            this.Approved.IndeterminateValue = "2";
            this.Approved.MinimumWidth = 6;
            this.Approved.Name = "Approved";
            this.Approved.ReadOnly = true;
            this.Approved.TrueValue = "1";
            this.Approved.Width = 125;
            // 
            // frmNotations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(1311, 519);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbStatusFilter);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmNotations";
            this.Text = "Notations";
            this.Load += new System.EventHandler(this.frmNotations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotations)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNotations;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Song;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tuning;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastEditted;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastEditor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Approved;
    }
}