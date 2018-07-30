namespace RegistroProyectoFinal.UI.Reportes
{
    partial class FacturasReviewer
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
            this.FacturasCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // FacturasCrystalReportViewer
            // 
            this.FacturasCrystalReportViewer.ActiveViewIndex = -1;
            this.FacturasCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FacturasCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.FacturasCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FacturasCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.FacturasCrystalReportViewer.Name = "FacturasCrystalReportViewer";
            this.FacturasCrystalReportViewer.Size = new System.Drawing.Size(800, 450);
            this.FacturasCrystalReportViewer.TabIndex = 0;
            this.FacturasCrystalReportViewer.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // FacturasReviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FacturasCrystalReportViewer);
            this.Name = "FacturasReviewer";
            this.Text = "FacturasReviewer";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer FacturasCrystalReportViewer;
    }
}