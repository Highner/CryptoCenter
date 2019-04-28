using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Controls
{
    class TickerTile: BindableTile
    {
        #region properties
        private ViewModels.ItemViewModelTicker _ViewModel;
        public ViewModels.ItemViewModelTicker ViewModel
        {
            get
            {
                return _ViewModel;
            }
            set
            {
                _ViewModel = value;
            }
        }
        #endregion

        #region constructor
        public TickerTile()
        {
            InitializeComponent();
        }

        #endregion

        #region public methods
        public void SetDataBindings()
        {
            LabelName.DataBindings.Add("Text", ViewModel, "Coin");
            LabelPrice.DataBindings.Add("Text", ViewModel, "Price");
            LabelChange.DataBindings.Add("Text", ViewModel, "Change");
            LabelVolume.DataBindings.Add("Text", ViewModel, "Volume");
            PictureBox.Image = ViewModel.Image;
        }
        #endregion

        private void InitializeComponent()
        {
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.LabelName = new System.Windows.Forms.Label();
            this.LabelPrice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LabelChange = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LabelVolume = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(3, 3);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(100, 100);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(109, 13);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(56, 13);
            this.LabelName.TabIndex = 1;
            this.LabelName.Text = "CoinName";
            // 
            // LabelPrice
            // 
            this.LabelPrice.AutoSize = true;
            this.LabelPrice.Location = new System.Drawing.Point(190, 34);
            this.LabelPrice.Name = "LabelPrice";
            this.LabelPrice.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LabelPrice.Size = new System.Drawing.Size(16, 13);
            this.LabelPrice.TabIndex = 2;
            this.LabelPrice.Text = "...";
            this.LabelPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Price:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Change:";
            // 
            // LabelChange
            // 
            this.LabelChange.AutoSize = true;
            this.LabelChange.Location = new System.Drawing.Point(190, 57);
            this.LabelChange.Name = "LabelChange";
            this.LabelChange.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LabelChange.Size = new System.Drawing.Size(16, 13);
            this.LabelChange.TabIndex = 5;
            this.LabelChange.Text = "...";
            this.LabelChange.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Volume:";
            // 
            // LabelVolume
            // 
            this.LabelVolume.AutoSize = true;
            this.LabelVolume.Location = new System.Drawing.Point(190, 80);
            this.LabelVolume.Name = "LabelVolume";
            this.LabelVolume.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LabelVolume.Size = new System.Drawing.Size(16, 13);
            this.LabelVolume.TabIndex = 7;
            this.LabelVolume.Text = "...";
            this.LabelVolume.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TickerTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.LabelVolume);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LabelChange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LabelPrice);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.PictureBox);
            this.Name = "TickerTile";
            this.Size = new System.Drawing.Size(318, 107);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.Label LabelPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LabelChange;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LabelVolume;
    }
}
