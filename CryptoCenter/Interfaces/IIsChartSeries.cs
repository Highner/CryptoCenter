using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoCenter.Services;

namespace CryptoCenter.Interfaces
{
    public interface IIsChartSeries
    {
        string SeriesType { get; set; }
        string SeriesLabel { get; set; }
        string YAxisLabel { get; set; }
        string XAxisLabel { get; set; }
        int ID { get; set; }
        event EventHandler<ChartSeriesNewDataEventArgs> NewData;
        event EventHandler<ChartSeriesDataChangedEventArgs> ChangedData;
    }
}
