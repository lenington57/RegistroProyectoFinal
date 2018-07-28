namespace RegistroProyectoFinal.UI.Reportes
{
    partial class EntradasReviewer
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
            this.EntradasCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // EntradasCrystalReportViewer
            // 
            this.EntradasCrystalReportViewer.ActiveViewIndex = -1;
            this.EntradasCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EntradasCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.EntradasCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EntradasCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.EntradasCrystalReportViewer.Name = "EntradasCrystalReportViewer";
            this.EntradasCrystalReportViewer.Size = new System.Drawing.Size(800, 450);
            this.EntradasCrystalReportViewer.TabIndex = 0;
            this.EntradasCrystalReportViewer.Load += new System.EventHandler(this.EntradasCrystalReportViewer_Load);
            // 
            // EntradasReviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EntradasCrystalReportViewer);
            this.Name = "EntradasReviewer";
            this.Text = "EntradasReviewer";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer EntradasCrystalReportViewer;
    }
}