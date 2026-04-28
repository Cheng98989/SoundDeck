namespace Echo.Forms
{
    partial class AnaliysisForm
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
            this.plbTotalDuration = new ReaLTaiizor.Controls.PoisonLabel();
            this.plbAverageDuration = new ReaLTaiizor.Controls.PoisonLabel();
            this.plbPlaylistCount = new ReaLTaiizor.Controls.PoisonLabel();
            this.plvArtists = new ReaLTaiizor.Controls.PoisonListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.poisonLabel1 = new ReaLTaiizor.Controls.PoisonLabel();
            this.poisonLabel3 = new ReaLTaiizor.Controls.PoisonLabel();
            this.poisonLabel4 = new ReaLTaiizor.Controls.PoisonLabel();
            this.plvAlbums = new ReaLTaiizor.Controls.PoisonListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // plbTotalDuration
            // 
            this.plbTotalDuration.Location = new System.Drawing.Point(136, 80);
            this.plbTotalDuration.Name = "plbTotalDuration";
            this.plbTotalDuration.Size = new System.Drawing.Size(216, 19);
            this.plbTotalDuration.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.plbTotalDuration.TabIndex = 0;
            this.plbTotalDuration.Text = "poisonLabel1";
            // 
            // plbAverageDuration
            // 
            this.plbAverageDuration.Location = new System.Drawing.Point(136, 104);
            this.plbAverageDuration.Name = "plbAverageDuration";
            this.plbAverageDuration.Size = new System.Drawing.Size(216, 19);
            this.plbAverageDuration.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.plbAverageDuration.TabIndex = 3;
            this.plbAverageDuration.Text = "poisonLabel2";
            // 
            // plbPlaylistCount
            // 
            this.plbPlaylistCount.Location = new System.Drawing.Point(136, 56);
            this.plbPlaylistCount.Name = "plbPlaylistCount";
            this.plbPlaylistCount.Size = new System.Drawing.Size(216, 19);
            this.plbPlaylistCount.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.plbPlaylistCount.TabIndex = 5;
            this.plbPlaylistCount.Text = "poisonLabel3";
            // 
            // plvArtists
            // 
            this.plvArtists.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.plvArtists.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.plvArtists.FullRowSelect = true;
            this.plvArtists.GridLines = true;
            this.plvArtists.Location = new System.Drawing.Point(16, 136);
            this.plvArtists.Name = "plvArtists";
            this.plvArtists.OwnerDraw = true;
            this.plvArtists.Size = new System.Drawing.Size(336, 152);
            this.plvArtists.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.plvArtists.TabIndex = 6;
            this.plvArtists.UseCompatibleStateImageBehavior = false;
            this.plvArtists.UseSelectable = true;
            this.plvArtists.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Autori";
            this.columnHeader1.Width = 330;
            // 
            // poisonLabel1
            // 
            this.poisonLabel1.AutoSize = true;
            this.poisonLabel1.Location = new System.Drawing.Point(16, 56);
            this.poisonLabel1.Name = "poisonLabel1";
            this.poisonLabel1.Size = new System.Drawing.Size(97, 19);
            this.poisonLabel1.TabIndex = 10;
            this.poisonLabel1.Text = "Numero tracce";
            // 
            // poisonLabel3
            // 
            this.poisonLabel3.AutoSize = true;
            this.poisonLabel3.Location = new System.Drawing.Point(16, 104);
            this.poisonLabel3.Name = "poisonLabel3";
            this.poisonLabel3.Size = new System.Drawing.Size(89, 19);
            this.poisonLabel3.TabIndex = 8;
            this.poisonLabel3.Text = "Durata media";
            // 
            // poisonLabel4
            // 
            this.poisonLabel4.AutoSize = true;
            this.poisonLabel4.Location = new System.Drawing.Point(16, 80);
            this.poisonLabel4.Name = "poisonLabel4";
            this.poisonLabel4.Size = new System.Drawing.Size(85, 19);
            this.poisonLabel4.TabIndex = 7;
            this.poisonLabel4.Text = "Durata totale";
            // 
            // plvAlbums
            // 
            this.plvAlbums.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.plvAlbums.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.plvAlbums.FullRowSelect = true;
            this.plvAlbums.GridLines = true;
            this.plvAlbums.Location = new System.Drawing.Point(16, 304);
            this.plvAlbums.Name = "plvAlbums";
            this.plvAlbums.OwnerDraw = true;
            this.plvAlbums.Size = new System.Drawing.Size(336, 152);
            this.plvAlbums.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.plvAlbums.TabIndex = 11;
            this.plvAlbums.UseCompatibleStateImageBehavior = false;
            this.plvAlbums.UseSelectable = true;
            this.plvAlbums.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Album";
            this.columnHeader2.Width = 330;
            // 
            // AnaliysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 477);
            this.Controls.Add(this.plvAlbums);
            this.Controls.Add(this.poisonLabel1);
            this.Controls.Add(this.poisonLabel3);
            this.Controls.Add(this.poisonLabel4);
            this.Controls.Add(this.plvArtists);
            this.Controls.Add(this.plbPlaylistCount);
            this.Controls.Add(this.plbAverageDuration);
            this.Controls.Add(this.plbTotalDuration);
            this.MaximumSize = new System.Drawing.Size(372, 477);
            this.MinimumSize = new System.Drawing.Size(372, 477);
            this.Name = "AnaliysisForm";
            this.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.Text = "Analisi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.PoisonLabel plbTotalDuration;
        private ReaLTaiizor.Controls.PoisonLabel plbAverageDuration;
        private ReaLTaiizor.Controls.PoisonLabel plbPlaylistCount;
        private ReaLTaiizor.Controls.PoisonListView plvArtists;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel1;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel3;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel4;
        private ReaLTaiizor.Controls.PoisonListView plvAlbums;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}