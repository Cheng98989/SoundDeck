namespace Echo.Forms
{
    partial class SortForm
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
            this.pbtOrdina = new ReaLTaiizor.Controls.PoisonButton();
            this.poisonLabel1 = new ReaLTaiizor.Controls.PoisonLabel();
            this.pcbAscedent = new ReaLTaiizor.Controls.PoisonComboBox();
            this.pcbSortType = new ReaLTaiizor.Controls.PoisonComboBox();
            this.poisonLabel2 = new ReaLTaiizor.Controls.PoisonLabel();
            this.SuspendLayout();
            // 
            // pbtOrdina
            // 
            this.pbtOrdina.Location = new System.Drawing.Point(24, 136);
            this.pbtOrdina.Name = "pbtOrdina";
            this.pbtOrdina.Size = new System.Drawing.Size(197, 32);
            this.pbtOrdina.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.pbtOrdina.TabIndex = 0;
            this.pbtOrdina.Text = "ORDINA";
            this.pbtOrdina.UseSelectable = true;
            this.pbtOrdina.Click += new System.EventHandler(this.pbtOrdina_Click);
            // 
            // poisonLabel1
            // 
            this.poisonLabel1.AutoSize = true;
            this.poisonLabel1.Location = new System.Drawing.Point(23, 73);
            this.poisonLabel1.Name = "poisonLabel1";
            this.poisonLabel1.Size = new System.Drawing.Size(88, 19);
            this.poisonLabel1.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.poisonLabel1.TabIndex = 22;
            this.poisonLabel1.Text = "Ordinamento";
            // 
            // pcbSortType
            // 
            this.pcbAscedent.DropDownHeight = 100;
            this.pcbAscedent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.pcbAscedent.FontSize = ReaLTaiizor.Extension.Poison.PoisonComboBoxSize.Small;
            this.pcbAscedent.FormattingEnabled = true;
            this.pcbAscedent.IntegralHeight = false;
            this.pcbAscedent.ItemHeight = 19;
            this.pcbAscedent.Items.AddRange(new object[] {
            "Crescente",
            "Decrescente"});
            this.pcbAscedent.Location = new System.Drawing.Point(117, 67);
            this.pcbAscedent.Name = "pcbSortType";
            this.pcbAscedent.Size = new System.Drawing.Size(105, 25);
            this.pcbAscedent.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.pcbAscedent.TabIndex = 23;
            this.pcbAscedent.UseSelectable = true;
            this.pcbAscedent.UseStyleColors = true;
            // 
            // pcbReference
            // 
            this.pcbSortType.DropDownHeight = 100;
            this.pcbSortType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.pcbSortType.FontSize = ReaLTaiizor.Extension.Poison.PoisonComboBoxSize.Small;
            this.pcbSortType.FormattingEnabled = true;
            this.pcbSortType.IntegralHeight = false;
            this.pcbSortType.ItemHeight = 19;
            this.pcbSortType.Items.AddRange(new object[] {
            "Titolo",
            "Autore",
            "Album",
            "Durata",
            "Percorso File",
            "Moltiplicatore di Volume"});
            this.pcbSortType.Location = new System.Drawing.Point(117, 102);
            this.pcbSortType.Name = "pcbReference";
            this.pcbSortType.Size = new System.Drawing.Size(105, 25);
            this.pcbSortType.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.pcbSortType.TabIndex = 25;
            this.pcbSortType.UseSelectable = true;
            this.pcbSortType.UseStyleColors = true;
            // 
            // poisonLabel2
            // 
            this.poisonLabel2.AutoSize = true;
            this.poisonLabel2.Location = new System.Drawing.Point(23, 108);
            this.poisonLabel2.Name = "poisonLabel2";
            this.poisonLabel2.Size = new System.Drawing.Size(77, 19);
            this.poisonLabel2.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.poisonLabel2.TabIndex = 24;
            this.poisonLabel2.Text = "Riferimento";
            // 
            // SortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 184);
            this.Controls.Add(this.pcbSortType);
            this.Controls.Add(this.poisonLabel2);
            this.Controls.Add(this.pcbAscedent);
            this.Controls.Add(this.poisonLabel1);
            this.Controls.Add(this.pbtOrdina);
            this.Name = "SortForm";
            this.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Lime;
            this.Text = "SortForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.PoisonButton pbtOrdina;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel1;
        private ReaLTaiizor.Controls.PoisonComboBox pcbAscedent;
        private ReaLTaiizor.Controls.PoisonComboBox pcbSortType;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel2;
    }
}