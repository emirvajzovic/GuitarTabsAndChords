namespace GuitarTabsAndChords.WinUI
{
    partial class frmNotationDetails
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
            this.components = new System.ComponentModel.Container();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbSong = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddSong = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNotationType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTuning = new System.Windows.Forms.TextBox();
            this.txtTuningDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(259, 634);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // cmbSong
            // 
            this.cmbSong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSong.FormattingEnabled = true;
            this.cmbSong.Location = new System.Drawing.Point(110, 23);
            this.cmbSong.Name = "cmbSong";
            this.cmbSong.Size = new System.Drawing.Size(173, 21);
            this.cmbSong.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Song";
            // 
            // btnAddSong
            // 
            this.btnAddSong.Location = new System.Drawing.Point(288, 23);
            this.btnAddSong.Name = "btnAddSong";
            this.btnAddSong.Size = new System.Drawing.Size(21, 21);
            this.btnAddSong.TabIndex = 23;
            this.btnAddSong.Text = "+";
            this.btnAddSong.UseVisualStyleBackColor = true;
            this.btnAddSong.Click += new System.EventHandler(this.BtnAddSong_Click);
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(161, 634);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(75, 23);
            this.btnReject.TabIndex = 66;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Visible = false;
            this.btnReject.Click += new System.EventHandler(this.BtnReject_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "Notation type";
            // 
            // cmbNotationType
            // 
            this.cmbNotationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNotationType.FormattingEnabled = true;
            this.cmbNotationType.Location = new System.Drawing.Point(110, 52);
            this.cmbNotationType.Name = "cmbNotationType";
            this.cmbNotationType.Size = new System.Drawing.Size(173, 21);
            this.cmbNotationType.TabIndex = 67;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 70;
            this.label2.Text = "Tuning";
            // 
            // txtTuning
            // 
            this.txtTuning.Location = new System.Drawing.Point(110, 81);
            this.txtTuning.Margin = new System.Windows.Forms.Padding(2);
            this.txtTuning.Name = "txtTuning";
            this.txtTuning.Size = new System.Drawing.Size(173, 20);
            this.txtTuning.TabIndex = 71;
            this.txtTuning.Validating += new System.ComponentModel.CancelEventHandler(this.txtTuning_Validating);
            // 
            // txtTuningDescription
            // 
            this.txtTuningDescription.Location = new System.Drawing.Point(110, 109);
            this.txtTuningDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtTuningDescription.Name = "txtTuningDescription";
            this.txtTuningDescription.Size = new System.Drawing.Size(173, 20);
            this.txtTuningDescription.TabIndex = 73;
            this.txtTuningDescription.Validating += new System.ComponentModel.CancelEventHandler(this.txtTuningDescription_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 72;
            this.label4.Text = "Tuning description";
            // 
            // txtContent
            // 
            this.txtContent.AcceptsReturn = true;
            this.txtContent.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtContent.Location = new System.Drawing.Point(15, 154);
            this.txtContent.Margin = new System.Windows.Forms.Padding(2);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(492, 468);
            this.txtContent.TabIndex = 1;
            this.txtContent.WordWrap = false;
            this.txtContent.Validating += new System.ComponentModel.CancelEventHandler(this.txtContent_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(13, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 74;
            this.label5.Text = "Notation Content";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmNotationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(515, 675);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTuningDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTuning);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbNotationType);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnAddSong);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbSong);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNotationDetails";
            this.Text = "Notation details";
            this.Load += new System.EventHandler(this.frmNotationDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbSong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddSong;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNotationType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTuning;
        private System.Windows.Forms.TextBox txtTuningDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}