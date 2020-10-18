namespace CRTLC
{
    partial class WindowI
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WindowI));
            this.dataLog = new System.Windows.Forms.ListView();
            this.Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // dataLog
            // 
            this.dataLog.BackColor = System.Drawing.Color.White;
            this.dataLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Date,
            this.value});
            this.dataLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLog.HideSelection = false;
            this.dataLog.Location = new System.Drawing.Point(0, 0);
            this.dataLog.Name = "dataLog";
            this.dataLog.Size = new System.Drawing.Size(704, 441);
            this.dataLog.TabIndex = 0;
            this.dataLog.UseCompatibleStateImageBehavior = false;
            this.dataLog.View = System.Windows.Forms.View.Details;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 200;
            // 
            // value
            // 
            this.value.Text = "Value";
            this.value.Width = 400;
            // 
            // WindowI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.dataLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(720, 2000);
            this.MinimumSize = new System.Drawing.Size(720, 480);
            this.Name = "WindowI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CTRL+L";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView dataLog;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader value;
    }
}

