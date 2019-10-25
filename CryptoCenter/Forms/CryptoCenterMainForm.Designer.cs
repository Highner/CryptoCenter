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
            this.SplitContainerMain = new System.Windows.Forms.SplitContainer();
            this.SplitContainerLeft = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SplitContainerRight = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.DataGridSourceData = new System.Windows.Forms.DataGridView();
            this.NeuroNetworkProgressBar = new System.Windows.Forms.ProgressBar();
            this.cryptoChart1 = new CryptoCenter.Controls.CryptoChart();
            this.cryptoChart2 = new CryptoCenter.Controls.CryptoChart();
            this.cryptoChart3 = new CryptoCenter.Controls.CryptoChart();
            this.ChartDataSource = new CryptoCenter.Controls.CryptoChart();
            this.TickerContainer = new CryptoCenter.Controls.TickerTileContainer();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerMain)).BeginInit();
            this.SplitContainerMain.Panel1.SuspendLayout();
            this.SplitContainerMain.Panel2.SuspendLayout();
            this.SplitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerLeft)).BeginInit();
            this.SplitContainerLeft.Panel1.SuspendLayout();
            this.SplitContainerLeft.Panel2.SuspendLayout();
            this.SplitContainerLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerRight)).BeginInit();
            this.SplitContainerRight.Panel1.SuspendLayout();
            this.SplitContainerRight.Panel2.SuspendLayout();
            this.SplitContainerRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSourceData)).BeginInit();
            this.SuspendLayout();
            // 
            // SplitContainerMain
            // 
            this.SplitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerMain.Location = new System.Drawing.Point(0, 113);
            this.SplitContainerMain.Name = "SplitContainerMain";
            // 
            // SplitContainerMain.Panel1
            // 
            this.SplitContainerMain.Panel1.Controls.Add(this.SplitContainerLeft);
            // 
            // SplitContainerMain.Panel2
            // 
            this.SplitContainerMain.Panel2.Controls.Add(this.SplitContainerRight);
            this.SplitContainerMain.Size = new System.Drawing.Size(1682, 733);
            this.SplitContainerMain.SplitterDistance = 611;
            this.SplitContainerMain.TabIndex = 6;
            // 
            // SplitContainerLeft
            // 
            this.SplitContainerLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SplitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerLeft.Location = new System.Drawing.Point(0, 0);
            this.SplitContainerLeft.Name = "SplitContainerLeft";
            this.SplitContainerLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainerLeft.Panel1
            // 
            this.SplitContainerLeft.Panel1.Controls.Add(this.splitContainer1);
            // 
            // SplitContainerLeft.Panel2
            // 
            this.SplitContainerLeft.Panel2.Controls.Add(this.cryptoChart3);
            this.SplitContainerLeft.Size = new System.Drawing.Size(611, 733);
            this.SplitContainerLeft.SplitterDistance = 469;
            this.SplitContainerLeft.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cryptoChart1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cryptoChart2);
            this.splitContainer1.Size = new System.Drawing.Size(609, 467);
            this.splitContainer1.SplitterDistance = 230;
            this.splitContainer1.TabIndex = 7;
            // 
            // SplitContainerRight
            // 
            this.SplitContainerRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SplitContainerRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerRight.Location = new System.Drawing.Point(0, 0);
            this.SplitContainerRight.Name = "SplitContainerRight";
            this.SplitContainerRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainerRight.Panel1
            // 
            this.SplitContainerRight.Panel1.Controls.Add(this.ChartDataSource);
            // 
            // SplitContainerRight.Panel2
            // 
            this.SplitContainerRight.Panel2.Controls.Add(this.button3);
            this.SplitContainerRight.Panel2.Controls.Add(this.NeuroNetworkProgressBar);
            this.SplitContainerRight.Panel2.Controls.Add(this.label3);
            this.SplitContainerRight.Panel2.Controls.Add(this.label2);
            this.SplitContainerRight.Panel2.Controls.Add(this.label1);
            this.SplitContainerRight.Panel2.Controls.Add(this.button2);
            this.SplitContainerRight.Panel2.Controls.Add(this.button1);
            this.SplitContainerRight.Panel2.Controls.Add(this.DataGridSourceData);
            this.SplitContainerRight.Size = new System.Drawing.Size(1067, 733);
            this.SplitContainerRight.SplitterDistance = 179;
            this.SplitContainerRight.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(515, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(481, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(480, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(599, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(441, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DataGridSourceData
            // 
            this.DataGridSourceData.AllowUserToAddRows = false;
            this.DataGridSourceData.AllowUserToDeleteRows = false;
            this.DataGridSourceData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DataGridSourceData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridSourceData.Location = new System.Drawing.Point(3, 3);
            this.DataGridSourceData.Name = "DataGridSourceData";
            this.DataGridSourceData.ReadOnly = true;
            this.DataGridSourceData.RowHeadersVisible = false;
            this.DataGridSourceData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridSourceData.Size = new System.Drawing.Size(414, 542);
            this.DataGridSourceData.TabIndex = 0;
            // 
            // NeuroNetworkProgressBar
            // 
            this.NeuroNetworkProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NeuroNetworkProgressBar.Location = new System.Drawing.Point(423, 522);
            this.NeuroNetworkProgressBar.Name = "NeuroNetworkProgressBar";
            this.NeuroNetworkProgressBar.Size = new System.Drawing.Size(640, 23);
            this.NeuroNetworkProgressBar.TabIndex = 12;
            // 
            // cryptoChart1
            // 
            this.cryptoChart1.AnimationsEnabled = true;
            this.cryptoChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cryptoChart1.Location = new System.Drawing.Point(0, 0);
            this.cryptoChart1.Name = "cryptoChart1";
            this.cryptoChart1.Size = new System.Drawing.Size(605, 226);
            this.cryptoChart1.TabIndex = 5;
            // 
            // cryptoChart2
            // 
            this.cryptoChart2.AnimationsEnabled = true;
            this.cryptoChart2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cryptoChart2.Location = new System.Drawing.Point(0, 0);
            this.cryptoChart2.Name = "cryptoChart2";
            this.cryptoChart2.Size = new System.Drawing.Size(605, 229);
            this.cryptoChart2.TabIndex = 6;
            // 
            // cryptoChart3
            // 
            this.cryptoChart3.AnimationsEnabled = true;
            this.cryptoChart3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cryptoChart3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cryptoChart3.Location = new System.Drawing.Point(0, 0);
            this.cryptoChart3.Name = "cryptoChart3";
            this.cryptoChart3.Size = new System.Drawing.Size(609, 258);
            this.cryptoChart3.TabIndex = 7;
            // 
            // ChartDataSource
            // 
            this.ChartDataSource.AnimationsEnabled = true;
            this.ChartDataSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartDataSource.Location = new System.Drawing.Point(0, 0);
            this.ChartDataSource.Name = "ChartDataSource";
            this.ChartDataSource.Size = new System.Drawing.Size(1065, 177);
            this.ChartDataSource.TabIndex = 6;
            // 
            // TickerContainer
            // 
            this.TickerContainer.AutoScroll = true;
            this.TickerContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TickerContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.TickerContainer.Location = new System.Drawing.Point(0, 0);
            this.TickerContainer.Name = "TickerContainer";
            this.TickerContainer.Size = new System.Drawing.Size(1682, 113);
            this.TickerContainer.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(774, 111);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "test";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CryptoCenterMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1682, 846);
            this.Controls.Add(this.SplitContainerMain);
            this.Controls.Add(this.TickerContainer);
            this.Name = "CryptoCenterMainForm";
            this.Text = "Form1";
            this.SplitContainerMain.Panel1.ResumeLayout(false);
            this.SplitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerMain)).EndInit();
            this.SplitContainerMain.ResumeLayout(false);
            this.SplitContainerLeft.Panel1.ResumeLayout(false);
            this.SplitContainerLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerLeft)).EndInit();
            this.SplitContainerLeft.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.SplitContainerRight.Panel1.ResumeLayout(false);
            this.SplitContainerRight.Panel2.ResumeLayout(false);
            this.SplitContainerRight.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerRight)).EndInit();
            this.SplitContainerRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridSourceData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.TickerTileContainer TickerContainer;
        private Controls.CryptoChart cryptoChart1;
        private System.Windows.Forms.SplitContainer SplitContainerMain;
        private System.Windows.Forms.SplitContainer SplitContainerLeft;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Controls.CryptoChart cryptoChart2;
        private System.Windows.Forms.SplitContainer SplitContainerRight;
        private Controls.CryptoChart ChartDataSource;
        private Controls.CryptoChart cryptoChart3;
        private System.Windows.Forms.DataGridView DataGridSourceData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar NeuroNetworkProgressBar;
        private System.Windows.Forms.Button button3;
    }
}

