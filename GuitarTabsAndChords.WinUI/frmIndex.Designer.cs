﻿namespace GuitarTabsAndChords.WinUI
{
    partial class frmIndex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIndex));
            this.btnMusic = new System.Windows.Forms.Button();
            this.btnArtists = new System.Windows.Forms.Button();
            this.btnGenres = new System.Windows.Forms.Button();
            this.btnSongs = new System.Windows.Forms.Button();
            this.btnAlbums = new System.Windows.Forms.Button();
            this.btnNotations = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnNotationCorrections = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMusic
            // 
            this.btnMusic.BackColor = System.Drawing.Color.Transparent;
            this.btnMusic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMusic.BackgroundImage")));
            this.btnMusic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMusic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMusic.FlatAppearance.BorderSize = 0;
            this.btnMusic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnMusic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnMusic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMusic.Location = new System.Drawing.Point(231, 141);
            this.btnMusic.Name = "btnMusic";
            this.btnMusic.Size = new System.Drawing.Size(202, 113);
            this.btnMusic.TabIndex = 1;
            this.btnMusic.UseVisualStyleBackColor = false;
            this.btnMusic.Click += new System.EventHandler(this.btnMusic_Click);
            // 
            // btnArtists
            // 
            this.btnArtists.Location = new System.Drawing.Point(347, 185);
            this.btnArtists.Name = "btnArtists";
            this.btnArtists.Size = new System.Drawing.Size(75, 23);
            this.btnArtists.TabIndex = 2;
            this.btnArtists.Text = "Artists";
            this.btnArtists.UseVisualStyleBackColor = true;
            this.btnArtists.Visible = false;
            this.btnArtists.Click += new System.EventHandler(this.BtnArtists_Click);
            // 
            // btnGenres
            // 
            this.btnGenres.Location = new System.Drawing.Point(247, 185);
            this.btnGenres.Name = "btnGenres";
            this.btnGenres.Size = new System.Drawing.Size(75, 23);
            this.btnGenres.TabIndex = 3;
            this.btnGenres.Text = "Genres";
            this.btnGenres.UseVisualStyleBackColor = true;
            this.btnGenres.Visible = false;
            this.btnGenres.Click += new System.EventHandler(this.BtnGenres_Click);
            // 
            // btnSongs
            // 
            this.btnSongs.Location = new System.Drawing.Point(543, 185);
            this.btnSongs.Name = "btnSongs";
            this.btnSongs.Size = new System.Drawing.Size(75, 23);
            this.btnSongs.TabIndex = 4;
            this.btnSongs.Text = "Songs";
            this.btnSongs.UseVisualStyleBackColor = true;
            this.btnSongs.Visible = false;
            this.btnSongs.Click += new System.EventHandler(this.BtnSongs_Click);
            // 
            // btnAlbums
            // 
            this.btnAlbums.Location = new System.Drawing.Point(451, 185);
            this.btnAlbums.Name = "btnAlbums";
            this.btnAlbums.Size = new System.Drawing.Size(75, 23);
            this.btnAlbums.TabIndex = 5;
            this.btnAlbums.Text = "Albums";
            this.btnAlbums.UseVisualStyleBackColor = true;
            this.btnAlbums.Visible = false;
            this.btnAlbums.Click += new System.EventHandler(this.BtnAlbums_Click);
            // 
            // btnNotations
            // 
            this.btnNotations.BackColor = System.Drawing.Color.Transparent;
            this.btnNotations.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNotations.BackgroundImage")));
            this.btnNotations.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNotations.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNotations.FlatAppearance.BorderSize = 0;
            this.btnNotations.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNotations.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNotations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotations.Location = new System.Drawing.Point(439, 141);
            this.btnNotations.Name = "btnNotations";
            this.btnNotations.Size = new System.Drawing.Size(202, 113);
            this.btnNotations.TabIndex = 6;
            this.btnNotations.UseVisualStyleBackColor = false;
            this.btnNotations.Click += new System.EventHandler(this.BtnNotations_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(401, 353);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Visible = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.Transparent;
            this.btnUsers.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUsers.BackgroundImage")));
            this.btnUsers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnUsers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Location = new System.Drawing.Point(23, 141);
            this.btnUsers.Margin = new System.Windows.Forms.Padding(0);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(202, 113);
            this.btnUsers.TabIndex = 0;
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(785, 11);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // btnNotationCorrections
            // 
            this.btnNotationCorrections.BackColor = System.Drawing.Color.Transparent;
            this.btnNotationCorrections.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNotationCorrections.BackgroundImage")));
            this.btnNotationCorrections.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNotationCorrections.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNotationCorrections.FlatAppearance.BorderSize = 0;
            this.btnNotationCorrections.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNotationCorrections.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNotationCorrections.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotationCorrections.Location = new System.Drawing.Point(647, 141);
            this.btnNotationCorrections.Name = "btnNotationCorrections";
            this.btnNotationCorrections.Size = new System.Drawing.Size(202, 113);
            this.btnNotationCorrections.TabIndex = 9;
            this.btnNotationCorrections.UseVisualStyleBackColor = false;
            this.btnNotationCorrections.Click += new System.EventHandler(this.btnNotationCorrections_Click);
            // 
            // frmIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(870, 450);
            this.Controls.Add(this.btnAlbums);
            this.Controls.Add(this.btnSongs);
            this.Controls.Add(this.btnArtists);
            this.Controls.Add(this.btnNotationCorrections);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNotations);
            this.Controls.Add(this.btnGenres);
            this.Controls.Add(this.btnMusic);
            this.Controls.Add(this.btnUsers);
            this.Name = "frmIndex";
            this.Text = "GuiTabs";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnMusic;
        private System.Windows.Forms.Button btnArtists;
        private System.Windows.Forms.Button btnGenres;
        private System.Windows.Forms.Button btnSongs;
        private System.Windows.Forms.Button btnAlbums;
        private System.Windows.Forms.Button btnNotations;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnNotationCorrections;
    }
}