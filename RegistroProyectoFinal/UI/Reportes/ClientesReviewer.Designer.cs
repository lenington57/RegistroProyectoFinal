namespace RegistroProyectoFinal.UI.Reportes
{
    partial class ClientesReviewer
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
            this.ClientesCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ClientesCrystalReportViewer
            // 
            this.ClientesCrystalReportViewer.ActiveViewIndex = -1;
            this.ClientesCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ClientesCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ClientesCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientesCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.ClientesCrystalReportViewer.Name = "ClientesCrystalReportViewer";
            this.ClientesCrystalReportViewer.Size = new System.Drawing.Size(800, 450);
            this.ClientesCrystalReportViewer.TabIndex = 0;
            this.ClientesCrystalReportViewer.Load += new System.EventHandler(this.ClientesCrystalReportViewer_Load);
            // 
            // ClientesReviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ClientesCrystalReportViewer);
            this.Name = "ClientesReviewer";
            this.Text = "ClientesReviewer";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer ClientesCrystalReportViewer;
    }
}