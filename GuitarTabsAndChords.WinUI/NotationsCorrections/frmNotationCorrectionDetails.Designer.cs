namespace GuitarTabsAndChords.WinUI
{
    partial class frmNotationCorrectionDetails
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnReject = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSong = new System.Windows.Forms.Label();
            this.lblNotationType = new System.Windows.Forms.Label();
            this.lblTuning = new System.Windows.Forms.Label();
            this.lblTuningDescription = new System.Windows.Forms.Label();
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
            this.btnSave.Text = "Approve";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
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
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(161, 634);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(75, 23);
            this.btnReject.TabIndex = 66;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
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
            this.txtContent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            // lblSong
            // 
            this.lblSong.AutoSize = true;
            this.lblSong.ForeColor = System.Drawing.Color.White;
            this.lblSong.Location = new System.Drawing.Point(107, 26);
            this.lblSong.Name = "lblSong";
            this.lblSong.Size = new System.Drawing.Size(0, 13);
            this.lblSong.TabIndex = 75;
            // 
            // lblNotationType
            // 
            this.lblNotationType.AutoSize = true;
            this.lblNotationType.ForeColor = System.Drawing.Color.White;
            this.lblNotationType.Location = new System.Drawing.Point(107, 55);
            this.lblNotationType.Name = "lblNotationType";
            this.lblNotationType.Size = new System.Drawing.Size(0, 13);
            this.lblNotationType.TabIndex = 76;
            // 
            // lblTuning
            // 
            this.lblTuning.AutoSize = true;
            this.lblTuning.ForeColor = System.Drawing.Color.White;
            this.lblTuning.Location = new System.Drawing.Point(107, 84);
            this.lblTuning.Name = "lblTuning";
            this.lblTuning.Size = new System.Drawing.Size(0, 13);
            this.lblTuning.TabIndex = 77;
            // 
            // lblTuningDescription
            // 
            this.lblTuningDescription.AutoSize = true;
            this.lblTuningDescription.ForeColor = System.Drawing.Color.White;
            this.lblTuningDescription.Location = new System.Drawing.Point(107, 111);
            this.lblTuningDescription.Name = "lblTuningDescription";
            this.lblTuningDescription.Size = new System.Drawing.Size(0, 13);
            this.lblTuningDescription.TabIndex = 78;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmNotationCorrectionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(515, 609);
            this.Controls.Add(this.lblTuningDescription);
            this.Controls.Add(this.lblTuning);
            this.Controls.Add(this.lblNotationType);
            this.Controls.Add(this.lblSong);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNotationCorrectionDetails";
            this.Text = "Notation correction details";
            this.Load += new System.EventHandler(this.frmNotationCorrectionDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSong;
        private System.Windows.Forms.Label lblNotationType;
        private System.Windows.Forms.Label lblTuning;
        private System.Windows.Forms.Label lblTuningDescription;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}