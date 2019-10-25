using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CryptoCenter.Services;

namespace CryptoCenter.Controls.Chart
{
    public abstract class ChartSeriesBase<t>:Interfaces.IIsChartSeries
        where t : Interfaces.IIsChartItem
    {
        #region properties
        public string SeriesType { get; set; }
        public string SeriesLabel { get; set; }
        public string YAxisLabel { get; set; }
        public string XAxisLabel { get; set; }
        public int ID { get; set; }
        private BindingList<t> Items;
        #endregion

        #region constructor
        public ChartSeriesBase(BindingList<t> items, string type, string label, string xaxislabel, string yaxislabel)
        {
            Items = items;
            SeriesType = type;
            SeriesLabel = label;
            YAxisLabel = yaxislabel;
            XAxisLabel = xaxislabel;
            Items.ListChanged += ListChanged;
        }
        #endregion

        #region protected functions
        protected virtual object GenerateChartSeriesValue(t item)
        {
            return null;
        }
        #endregion

        #region private methods
        void AddNewItem(t item)
        {
            OnNewData(GenerateChartSeriesValue(item), XAxisLabel, item.XAxisValue);
        }

        void ChangeItem(t item, int index)
        {
            OnChangedData(GenerateChartSeriesValue(item), index);
        }

        void ClearItems()
        {
            OnDataCleared();
        }

        void ListChanged(object sender, ListChangedEventArgs e)
        {
            BindingList<t> items = (BindingList<t>)sender;
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                AddNewItem(items[e.NewIndex]);
            }
            else if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                ChangeItem(items[e.NewIndex], e.OldIndex);
            }
            else if (e.ListChangedType == ListChangedType.Reset)
            {
                ClearItems();
            }
        }
        #endregion

        #region events
        private void OnNewData(object item, string xaxislabel, string xaxislabelitem)
        {
            EventHandler<Services.ChartSeriesNewDataEventArgs> tmpevent = NewData;
            if (tmpevent != null)
            {
                tmpevent(this, new Services.ChartSeriesNewDataEventArgs() { Item = item , ID = ID , Title = SeriesLabel , LabelItem = xaxislabelitem, XAxisLabel = xaxislabel});
            }
        }

        private void OnChangedData(object item, int index)
        {
            EventHandler<Services.ChartSeriesDataChangedEventArgs> tmpevent = ChangedData;
            if (tmpevent != null)
            {
                tmpevent(this, new Services.ChartSeriesDataChangedEventArgs() { Item = item, Index = index, ReversedIndex = Items.Count -1 - index, ID = ID, Title = SeriesLabel });
            }
        }

        private void OnDataCleared()
        {
            EventHandler<Services.ChartSeriesEventArgs> tmpevent = DataCleared;
            if (tmpevent != null)
            {
                tmpevent(this, new Services.ChartSeriesEventArgs() { Title = SeriesLabel });
            }
        }

        public event EventHandler<ChartSeriesNewDataEventArgs> NewData;
        public event EventHandler<ChartSeriesDataChangedEventArgs> ChangedData;
        public event EventHandler<ChartSeriesEventArgs> DataCleared;
        #endregion
    }
}
