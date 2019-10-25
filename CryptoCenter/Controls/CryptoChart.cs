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
using LiveCharts.Events;

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



        public int MaxItems = 0;

        List<Interfaces.IIsChartSeries> _SeriesSource { get; set; } = new List<Interfaces.IIsChartSeries>();


        public CryptoChart()
        {
            InitializeComponent();
            Chart.Series = new LiveCharts.SeriesCollection();
            LiveCharts.Wpf.Axis xaxis = new LiveCharts.Wpf.Axis() { Title = "Time", ShowLabels = true };
            xaxis.Labels = new[] { "" };

            Chart.AxisX.Add(xaxis);
            Chart.AxisY.Clear();
            Chart.Zoom = LiveCharts.ZoomingOptions.None;
            Chart.Pan = LiveCharts.PanningOptions.None;
           
        }


        public void AddSeries(Interfaces.IIsChartSeries series)
        {
            series.ChangedData += ItemChanged;
            series.NewData += ItemAdded;
            series.DataCleared += ItemsCleared;
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
                    chartseriesline.PointGeometry = null;
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
            int index = series.Values.Count - 1 - args.ReversedIndex;
            if(!(index > series.Values.Count -1) && !(index < 0))
            {
                series.Values.RemoveAt(index);
                series.Values.Insert(index, args.Item);
            }
        }

        private void ItemAdded(object sender, ChartSeriesNewDataEventArgs args)
        {
            var series = (LiveCharts.Wpf.Series)Chart.Series.Where(x => x.Title == args.Title).Single();
            if (MaxItems > 0 && series.Values.Count > MaxItems - 1)
            {
                int difference = series.Values.Count - MaxItems + 1;
                for (int i = 0; i < difference; i++)
                {
                    series.Values.RemoveAt(0);
                }
            }
            series.Values.Add(args.Item);
            SetAxis(args.XAxisLabel, args.LabelItem);
        }

        private void ItemsCleared(object sender, ChartSeriesEventArgs args)
        {
            var series = (LiveCharts.Wpf.Series)Chart.Series.Where(x => x.Title == args.Title).Single();
            series.Values.Clear();
            
            var axis = Chart.AxisX.Where(x => x.Title == "Time").Single();
            axis.Labels = new[] { "" };
        }

        private void SetAxis(string axislabel, string value)
        {
            var axis = Chart.AxisX.Where(x => x.Title == axislabel).Single();
            List<string> currentlabels = axis.Labels.ToList();

            if (MaxItems > 0 && currentlabels.Count > MaxItems)
            {
                int difference = currentlabels.Count - (MaxItems);
                for (int i = 0; i < difference; i++)
                {
                    currentlabels.RemoveAt(0);
                }
            }

            currentlabels.Add(value);

            if(currentlabels.Where(x => x == "").Any())
            {
                currentlabels.RemoveAt(currentlabels.IndexOf(""));
            }
                   
            axis.Labels = currentlabels.Distinct().ToArray();
        }

    }
}
