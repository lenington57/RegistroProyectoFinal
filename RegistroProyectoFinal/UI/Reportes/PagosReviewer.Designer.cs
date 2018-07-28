namespace RegistroProyectoFinal.UI.Reportes
{
    partial class PagosReviewer
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
            this.PagosCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // PagosCrystalReportViewer
            // 
            this.PagosCrystalReportViewer.ActiveViewIndex = -1;
            this.PagosCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PagosCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.PagosCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PagosCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.PagosCrystalReportViewer.Name = "PagosCrystalReportViewer";
            this.PagosCrystalReportViewer.Size = new System.Drawing.Size(800, 450);
            this.PagosCrystalReportViewer.TabIndex = 0;
            this.PagosCrystalReportViewer.Load += new System.EventHandler(this.PagosCrystalReportViewer_Load);
            // 
            // PagosReviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PagosCrystalReportViewer);
            this.Name = "PagosReviewer";
            this.Text = "PagosReviewer";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer PagosCrystalReportViewer;
    }
}