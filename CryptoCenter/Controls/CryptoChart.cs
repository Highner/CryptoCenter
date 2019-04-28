using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CryptoCenter.Services;

namespace CryptoCenter.Controls
{
    public partial class CryptoChart : UserControl
    {

        public bool AnimationsEnabled
        {
            get
            {
                return !Chart.DisableAnimations;
            }
            set
            {
                Chart.DisableAnimations = !value;
            }
        }

        List<Interfaces.IIsChartSeries> _SeriesSource { get; set; } = new List<Interfaces.IIsChartSeries>();


        public CryptoChart()
        {
            InitializeComponent();
            Chart.Series = new LiveCharts.SeriesCollection();
            LiveCharts.Wpf.Axis xaxis = new LiveCharts.Wpf.Axis() { Title = "Time", ShowLabels = true };
            xaxis.Labels = new[] { "" };
            Chart.AxisX.Add(xaxis);

            Chart.AxisY.Clear();
            Chart.Zoom = LiveCharts.ZoomingOptions.X;
            Chart.Pan = LiveCharts.PanningOptions.X;
            
        }

        public void AddSeries(Interfaces.IIsChartSeries series)
        {
            series.ChangedData += ItemChanged;
            series.NewData += ItemAdded;
            _SeriesSource.Add(series);

            switch (series.SeriesType)
            {
                case "Candle":
                    LiveCharts.Wpf.OhlcSeries chartseries = new LiveCharts.Wpf.OhlcSeries();
                    chartseries.Title = series.SeriesLabel;
                    chartseries.Values = new LiveCharts.ChartValues<LiveCharts.Defaults.OhlcPoint>();
                    LiveCharts.Wpf.Axis axis = new LiveCharts.Wpf.Axis() { Title = series.YAxisLabel, ShowLabels = true };
                    Chart.AxisY.Add(axis);
                    chartseries.ScalesYAt = Chart.AxisY.IndexOf(axis);
                    Chart.Series.Add(chartseries);
                    break;
                case "Line":
                    LiveCharts.Wpf.LineSeries chartseriesline = new LiveCharts.Wpf.LineSeries();
                    chartseriesline.Title = series.SeriesLabel;
                    chartseriesline.Values = new LiveCharts.ChartValues<double>();
                    LiveCharts.Wpf.Axis axisline = new LiveCharts.Wpf.Axis() { Title = series.YAxisLabel, ShowLabels = true };
                    Chart.AxisY.Add(axisline);
                    chartseriesline.ScalesYAt = Chart.AxisY.IndexOf(axisline);
                    Chart.Series.Add(chartseriesline);
                    break;
                case "Column":
                    LiveCharts.Wpf.ColumnSeries chartseriescolumn = new LiveCharts.Wpf.ColumnSeries();
                    chartseriescolumn.Title = series.SeriesLabel;
                    chartseriescolumn.Values = new LiveCharts.ChartValues<double>();
                    LiveCharts.Wpf.Axis axiscolumn = new LiveCharts.Wpf.Axis() { Title = series.YAxisLabel, ShowLabels = true };
                    Chart.AxisY.Add(axiscolumn);
                    chartseriescolumn.ScalesYAt = Chart.AxisY.IndexOf(axiscolumn);
                    Chart.Series.Add(chartseriescolumn);
                    break;
                case "Bar":

                default:
                    break;
            }

        }

        private void ItemChanged(object sender, ChartSeriesDataChangedEventArgs args)
        {
            var series = (LiveCharts.Wpf.Series)Chart.Series.Where(x => x.Title == args.Title).Single();
            series.Values.RemoveAt(args.Index);
            series.Values.Insert(args.Index, args.Item);
        }

        private void ItemAdded(object sender, ChartSeriesNewDataEventArgs args)
        {
            var series = (LiveCharts.Wpf.Series)Chart.Series.Where(x => x.Title == args.Title).Single();
            series.Values.Add(args.Item);
            SetAxis(args.XAxisLabel, args.LabelItem);
        }

        private void SetAxis(string axislabel, string value)
        {
            var axis = Chart.AxisX.Where(x => x.Title == axislabel).Single();
            List<string> currentlabels = axis.Labels.ToList();
            currentlabels.Add(value);
            axis.Labels = currentlabels.ToArray();
        }
    }
}
