using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using Binding = System.Windows.Data.Binding;
using System.Windows.Data;
using System.Windows;

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

            cryptoChart1.AnimationsEnabled = false;
            cryptoChart2.AnimationsEnabled = false;
            cryptoChart3.AnimationsEnabled = false;
            ChartDataSource.AnimationsEnabled = false;

            _MainViewModel.Context = System.Threading.SynchronizationContext.Current;
            _MainViewModel.StartOHCLService();
            //_MainViewModel.GetNews();
            _MainViewModel.StartTickerService();
            //_MainViewModel.StartSocialStatsService();


            TickerContainer.SetItems(_MainViewModel.Ticker.Items);

            cryptoChart1.MaxItems = 800;
            //cryptoChart1.AddSeries(new Controls.Chart.ChartSeriesVolume(_MainViewModel.OHCLDay.Items, "Volume", _MainViewModel.BaseCurrency + " Volume"));
            cryptoChart1.AddSeries(new Controls.Chart.ChartSeriesAverage(_MainViewModel.OHCLDay.Items, "Price", _MainViewModel.BaseCurrency + " Daily Price"));
            //cryptoChart1.AddSeries(new Controls.Chart.ChartSeriesSocialStats(_MainViewModel.SocialStatsDay.Items, "RedditDailyComments", _MainViewModel.BaseCurrency + "RedditDailyComments", "RedditDailyComments"));

            cryptoChart2.MaxItems = 150;
            //cryptoChart2.AddSeries(new Controls.Chart.ChartSeriesVolume(_MainViewModel.OHCLHour.Items, "Volume", _MainViewModel.BaseCurrency + " Hourly Volume"));
            cryptoChart2.AddSeries(new Controls.Chart.ChartSeriesOHCL(_MainViewModel.OHCLHour.Items, "Price", _MainViewModel.BaseCurrency + " Hourly Price"));
            cryptoChart2.AddSeries(new Controls.Chart.ChartSeriesSingleValue(_MainViewModel.PredictedHour.Items, "Prediced Price", _MainViewModel.BaseCurrency + " Prediced Price", "Column"));

            cryptoChart3.MaxItems = 60;
            cryptoChart3.AddSeries(new Controls.Chart.ChartSeriesVolume(_MainViewModel.OHCLMinute.Items, "Volume", _MainViewModel.BaseCurrency + " Minutely Volume"));
            cryptoChart3.AddSeries(new Controls.Chart.ChartSeriesOHCL(_MainViewModel.OHCLMinute.Items, "Price", _MainViewModel.BaseCurrency + " Minutely Price"));

            ChartDataSource.AddSeries(new Controls.Chart.ChartSeriesAverage(_MainViewModel.OHCLHour.Items, "Price", _MainViewModel.BaseCurrency + " Price"));
            ChartDataSource.Chart.AxisY.Clear();

            DataGridSourceData.DataBindings.Add("DataSource", _MainViewModel, "SourceData");

            label1.DataBindings.Add("Text", _MainViewModel, "ComputedCloseChange1");
            label2.DataBindings.Add("Text", _MainViewModel, "ComputedCloseChange2");
            label3.DataBindings.Add("Text", _MainViewModel, "TrainingStatus");

            NeuroNetworkProgressBar.DataBindings.Add("Maximum", _MainViewModel, "TrainingEpochs");
            NeuroNetworkProgressBar.DataBindings.Add("Value", _MainViewModel, "FinishedTrainingEpochs");

            TickerContainer.TickerItemDoubleClicked += TickerTileDoubleClicked;

        }
        #endregion

        void TickerTileDoubleClicked(object sender, Events.TickerTileItemClickedEventArgs args)
        {
            _MainViewModel.ChangeCoin(args.Item.Coin);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _MainViewModel.GenerateSourceData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _MainViewModel.TrainNetwork();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _MainViewModel.ComputeLast();
        }
    }
}
