using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoCenter.Enumerables;
using CryptoCenter.Model;

namespace CryptoCenter.Data.DataControllers
{
    class CryptoCompareOHCLDataController: OHCLDataControllerBase
    {

        #region constructor
        public CryptoCompareOHCLDataController(DataIntervalTypeEnum interval, string currency1, string currency2)
        {
            _Interval = interval;
            _Currency1 = currency1;
            _Currency2 = currency2;
        }
        #endregion

        #region private methods
        protected override List<OHCLData> GetData(double since)
        {
            List<OHCLData> finaldata = new List<OHCLData>();

            List<Model.CryptoCompare.CryptoCompareOHLCDataObject> cryptocomparefinaldata = new List<Model.CryptoCompare.CryptoCompareOHLCDataObject>();

            int limit = 200;
            int maxintervals = 1;
            for (int x = 0; x < maxintervals; x++)
            {
                string timestamp = "";
                if (!(x == 0))
                {
                    double mindate = cryptocomparefinaldata.Min(z => z.time);
                    if (mindate < since) { break; }
                    timestamp = "&toTs=" + mindate;
                }


                string contents = "";
                string url = "https://min-api.cryptocompare.com/data/histo" + _Interval.ToString().ToLower() + "?fsym=" + _Currency1.ToUpper() + "&tsym=" + _Currency2.ToUpper() + "&limit=" + limit + timestamp;
                using (var wc = new System.Net.WebClient())
                    contents = wc.DownloadString(url);

                var responsedata = Newtonsoft.Json.JsonConvert.DeserializeObject<Model.CryptoCompare.CryptoCompareDataObject<Model.CryptoCompare.CryptoCompareOHLCDataObject>>(contents);
                cryptocomparefinaldata.AddRange(responsedata.Data.ToList());
            }

            foreach(Model.CryptoCompare.CryptoCompareOHLCDataObject item in cryptocomparefinaldata)
            {
                //if ((since > 0 && item.time >= since) || (cryptocomparefinaldata.IndexOf(item) == cryptocomparefinaldata.Count() - 1) || !(finaldata.Where(x => x.UnixTime == item.time).Any())) { finaldata.Add(ConvertFromSource(item)); }
                finaldata.Add(ConvertFromSource(item));
            }
            //return finaldata.Where(x => x.UnixTime >= since).OrderBy(x => x.Time).ToList();
            return finaldata.OrderBy(x => x.Time).ToList();
        }

        private OHCLData ConvertFromSource(Model.CryptoCompare.CryptoCompareOHLCDataObject item)
        {
            return new OHCLData() { ListID = _Currency1 + _Currency2, CurrencyTo = _Currency2, CurrencyFrom = _Currency1, Open = item.open, Close = item.close, High = item.high, ID = item.time.ToString(), Low = item.low, Time = Helpers.Conversion.UnixTimeStampToDateTime(item.time), Volume = item.volumefrom, UnixTime = item.time};
        }
        #endregion
    }
}

