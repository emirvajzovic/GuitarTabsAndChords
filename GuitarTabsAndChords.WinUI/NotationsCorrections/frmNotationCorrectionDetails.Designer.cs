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
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(345, 780);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Approve";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(16, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Song";
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(215, 780);
            this.btnReject.Margin = new System.Windows.Forms.Padding(4);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(100, 28);
            this.btnReject.TabIndex = 66;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.BtnReject_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 68;
            this.label1.Text = "Notation type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 70;
            this.label2.Text = "Tuning";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 137);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 16);
            this.label4.TabIndex = 72;
            this.label4.Text = "Tuning description";
            // 
            // txtContent
            // 
            this.txtContent.AcceptsReturn = true;
            this.txtContent.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtContent.Location = new System.Drawing.Point(20, 190);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContent.Size = new System.Drawing.Size(655, 575);
            this.txtContent.TabIndex = 1;
            this.txtContent.WordWrap = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(17, 170);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 16);
            this.label5.TabIndex = 74;
            this.label5.Text = "Notation Content";
            // 
            // lblSong
            // 
            this.lblSong.AutoSize = true;
            this.lblSong.ForeColor = System.Drawing.Color.White;
            this.lblSong.Location = new System.Drawing.Point(143, 32);
            this.lblSong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSong.Name = "lblSong";
            this.lblSong.Size = new System.Drawing.Size(0, 16);
            this.lblSong.TabIndex = 75;
            // 
            // lblNotationType
            // 
            this.lblNotationType.AutoSize = true;
            this.lblNotationType.ForeColor = System.Drawing.Color.White;
            this.lblNotationType.Location = new System.Drawing.Point(143, 68);
            this.lblNotationType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNotationType.Name = "lblNotationType";
            this.lblNotationType.Size = new System.Drawing.Size(0, 16);
            this.lblNotationType.TabIndex = 76;
            // 
            // lblTuning
            // 
            this.lblTuning.AutoSize = true;
            this.lblTuning.ForeColor = System.Drawing.Color.White;
            this.lblTuning.Location = new System.Drawing.Point(143, 103);
            this.lblTuning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTuning.Name = "lblTuning";
            this.lblTuning.Size = new System.Drawing.Size(0, 16);
            this.lblTuning.TabIndex = 77;
            // 
            // lblTuningDescription
            // 
            this.lblTuningDescription.AutoSize = true;
            this.lblTuningDescription.ForeColor = System.Drawing.Color.White;
            this.lblTuningDescription.Location = new System.Drawing.Point(143, 137);
            this.lblTuningDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTuningDescription.Name = "lblTuningDescription";
            this.lblTuningDescription.Size = new System.Drawing.Size(0, 16);
            this.lblTuningDescription.TabIndex = 78;
            // 
            // frmNotationCorrectionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(687, 830);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNotationCorrectionDetails";
            this.Text = "Notation correction details";
            this.Load += new System.EventHandler(this.frmNotationCorrectionDetails_Load);
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
    }
}