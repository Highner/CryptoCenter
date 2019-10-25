namespace CryptoCenter.Controls
{
    partial class CryptoChart
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.Chart = new LiveCharts.WinForms.CartesianChart();
            this.SuspendLayout();
            // 
            // Chart
            // 
            this.Chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Chart.Location = new System.Drawing.Point(0, 0);
            this.Chart.Name = "Chart";
            this.Chart.Size = new System.Drawing.Size(1119, 754);
            this.Chart.TabIndex = 0;
            this.Chart.Text = "cartesianChart1";
            // 
            // CryptoChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Chart);
            this.Name = "CryptoChart";
            this.Size = new System.Drawing.Size(1119, 754);
            this.ResumeLayout(false);

        }

        #endregion

        public LiveCharts.WinForms.CartesianChart Chart;
    }
}
