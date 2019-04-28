namespace CryptoCenter
{
    partial class CryptoCenterMainForm
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.cryptoChart1 = new CryptoCenter.Controls.CryptoChart();
            this.TickerContainer = new CryptoCenter.Controls.TickerTileContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(1205, 268);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(735, 375);
            this.dataGridView2.TabIndex = 3;
            // 
            // cryptoChart1
            // 
            this.cryptoChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cryptoChart1.AnimationsEnabled = true;
            this.cryptoChart1.Location = new System.Drawing.Point(12, 119);
            this.cryptoChart1.Name = "cryptoChart1";
            this.cryptoChart1.Size = new System.Drawing.Size(1017, 715);
            this.cryptoChart1.TabIndex = 5;
            // 
            // TickerContainer
            // 
            this.TickerContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.TickerContainer.Location = new System.Drawing.Point(0, 0);
            this.TickerContainer.Name = "TickerContainer";
            this.TickerContainer.Size = new System.Drawing.Size(1966, 113);
            this.TickerContainer.TabIndex = 4;
            // 
            // CryptoCenterMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1966, 846);
            this.Controls.Add(this.cryptoChart1);
            this.Controls.Add(this.TickerContainer);
            this.Controls.Add(this.dataGridView2);
            this.Name = "CryptoCenterMainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView2;
        private Controls.TickerTileContainer TickerContainer;
        private Controls.CryptoChart cryptoChart1;
    }
}

