using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoCenter
{
    public partial class CryptoCenterMainForm : Form
    {
        #region private fields
        ViewModels.MainViewModel _MainViewModel = new ViewModels.MainViewModel();
        #endregion

        #region constructor
        public CryptoCenterMainForm()
        {
            InitializeComponent();
            _MainViewModel.Context = System.Threading.SynchronizationContext.Current;
            _MainViewModel.StartOHCLService();
            _MainViewModel.GetNews();
            _MainViewModel.StartTickerService();
            _MainViewModel.StartSocialStatsService();

            dataGridView2.DataBindings.Add("DataSource", _MainViewModel, "SocialStatsDay.Items", true, DataSourceUpdateMode.OnPropertyChanged);

            TickerContainer.SetItems(_MainViewModel.Ticker.Items);
            cryptoChart1.AddSeries(new Controls.Chart.ChartSeriesVolume(_MainViewModel.OHCLMinute.Items, "BTC Volume Minute", "BTC to USD Volume"));
            cryptoChart1.AddSeries(new Controls.Chart.ChartSeriesOHCL(_MainViewModel.OHCLMinute.Items, "BTC Price Minute", "BTC to USD Price"));

            cryptoChart1.AnimationsEnabled = false;
            
        }
        #endregion





    }
}
