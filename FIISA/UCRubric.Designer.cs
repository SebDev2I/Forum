namespace FIISA
{
    partial class UCRubric
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlp1 = new System.Windows.Forms.TableLayoutPanel();
            this.tlp2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPseudo = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblTraining = new System.Windows.Forms.Label();
            this.tlp3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.tlp1.SuspendLayout();
            this.tlp2.SuspendLayout();
            this.tlp3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp1
            // 
            this.tlp1.AutoSize = true;
            this.tlp1.ColumnCount = 2;
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp1.Controls.Add(this.tlp2, 0, 0);
            this.tlp1.Controls.Add(this.tlp3, 1, 0);
            this.tlp1.Controls.Add(this.lblDesc, 1, 1);
            this.tlp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp1.Location = new System.Drawing.Point(0, 0);
            this.tlp1.Name = "tlp1";
            this.tlp1.RowCount = 2;
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.78761F));
            this.tlp1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.21239F));
            this.tlp1.Size = new System.Drawing.Size(541, 111);
            this.tlp1.TabIndex = 0;
            this.tlp1.MouseEnter += new System.EventHandler(this.UCRubric_MouseEnter);
            // 
            // tlp2
            // 
            this.tlp2.ColumnCount = 2;
            this.tlp2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp2.Controls.Add(this.lblPseudo, 0, 0);
            this.tlp2.Controls.Add(this.lblStatus, 1, 0);
            this.tlp2.Controls.Add(this.lblTraining, 0, 1);
            this.tlp2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp2.Location = new System.Drawing.Point(3, 3);
            this.tlp2.Name = "tlp2";
            this.tlp2.RowCount = 2;
            this.tlp2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.84615F));
            this.tlp2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.15385F));
            this.tlp2.Size = new System.Drawing.Size(264, 47);
            this.tlp2.TabIndex = 0;
            this.tlp2.MouseEnter += new System.EventHandler(this.UCRubric_MouseEnter);
            // 
            // lblPseudo
            // 
            this.lblPseudo.AutoSize = true;
            this.lblPseudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPseudo.Location = new System.Drawing.Point(3, 0);
            this.lblPseudo.Name = "lblPseudo";
            this.lblPseudo.Size = new System.Drawing.Size(126, 25);
            this.lblPseudo.TabIndex = 0;
            this.lblPseudo.Text = "Pseudo";
            this.lblPseudo.MouseEnter += new System.EventHandler(this.UCRubric_MouseEnter);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Location = new System.Drawing.Point(135, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(126, 25);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Statut";
            this.lblStatus.MouseEnter += new System.EventHandler(this.UCRubric_MouseEnter);
            // 
            // lblTraining
            // 
            this.lblTraining.AutoSize = true;
            this.lblTraining.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTraining.Location = new System.Drawing.Point(3, 25);
            this.lblTraining.Name = "lblTraining";
            this.lblTraining.Size = new System.Drawing.Size(126, 22);
            this.lblTraining.TabIndex = 3;
            this.lblTraining.Text = "Formation";
            this.lblTraining.MouseEnter += new System.EventHandler(this.UCRubric_MouseEnter);
            // 
            // tlp3
            // 
            this.tlp3.ColumnCount = 2;
            this.tlp3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.02256F));
            this.tlp3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.97744F));
            this.tlp3.Controls.Add(this.lblTitre, 0, 0);
            this.tlp3.Controls.Add(this.lblDate, 1, 0);
            this.tlp3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp3.Location = new System.Drawing.Point(273, 3);
            this.tlp3.Name = "tlp3";
            this.tlp3.RowCount = 1;
            this.tlp3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp3.Size = new System.Drawing.Size(265, 47);
            this.tlp3.TabIndex = 1;
            this.tlp3.MouseEnter += new System.EventHandler(this.UCRubric_MouseEnter);
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitre.Location = new System.Drawing.Point(3, 0);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(150, 47);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Titre";
            this.lblTitre.MouseEnter += new System.EventHandler(this.UCRubric_MouseEnter);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDate.Location = new System.Drawing.Point(159, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(103, 47);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblDate.MouseEnter += new System.EventHandler(this.UCRubric_MouseEnter);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDesc.Location = new System.Drawing.Point(273, 53);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(265, 58);
            this.lblDesc.TabIndex = 2;
            this.lblDesc.Text = "Description";
            this.lblDesc.MouseEnter += new System.EventHandler(this.UCRubric_MouseEnter);
            // 
            // UCRubric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tlp1);
            this.Name = "UCRubric";
            this.Size = new System.Drawing.Size(541, 111);
            this.tlp1.ResumeLayout(false);
            this.tlp1.PerformLayout();
            this.tlp2.ResumeLayout(false);
            this.tlp2.PerformLayout();
            this.tlp3.ResumeLayout(false);
            this.tlp3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp1;
        private System.Windows.Forms.TableLayoutPanel tlp2;
        private System.Windows.Forms.Label lblPseudo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblTraining;
        private System.Windows.Forms.TableLayoutPanel tlp3;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDesc;
    }
}
