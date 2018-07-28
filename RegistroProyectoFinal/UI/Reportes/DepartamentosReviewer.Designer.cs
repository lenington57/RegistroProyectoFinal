namespace RegistroProyectoFinal.UI.Reportes
{
    partial class DepartamentosReviewer
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
            this.DepartamentoCrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // DepartamentoCrystalReportViewer
            // 
            this.DepartamentoCrystalReportViewer.ActiveViewIndex = -1;
            this.DepartamentoCrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DepartamentoCrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.DepartamentoCrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DepartamentoCrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.DepartamentoCrystalReportViewer.Name = "DepartamentoCrystalReportViewer";
            this.DepartamentoCrystalReportViewer.Size = new System.Drawing.Size(800, 450);
            this.DepartamentoCrystalReportViewer.TabIndex = 0;
            this.DepartamentoCrystalReportViewer.Load += new System.EventHandler(this.crystalReportViewer1_Load);
            // 
            // DepartamentosReviewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DepartamentoCrystalReportViewer);
            this.Name = "DepartamentosReviewer";
            this.Text = "DepartamentosReviewer";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer DepartamentoCrystalReportViewer;
    }
}