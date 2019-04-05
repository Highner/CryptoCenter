using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoCenter.Enumerables;
using CryptoCenter.Model;

namespace CryptoCenter.Data.DataControllers
{
    class CryptoCompareDataController: OHCLDataControllerBase
    {

        #region constructor
        public CryptoCompareDataController(DataIntervalTypeEnum interval, string currency1, string currency2)
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

            int limit = 2000;
            int maxintervals = 5;
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
                string url = "https://min-api.cryptocompare.com/data/histo" + _Interval.ToString().ToLower() + "?fsym=" + _Currency1 + "&tsym=" + _Currency2 + "&limit=" + limit + timestamp;
                using (var wc = new System.Net.WebClient())
                    contents = wc.DownloadString(url);

                var responsedata = Newtonsoft.Json.JsonConvert.DeserializeObject<Model.CryptoCompare.CryptoCompareDataObject>(contents);
                cryptocomparefinaldata.AddRange(responsedata.Data.ToList());
            }

            foreach(Model.CryptoCompare.CryptoCompareOHLCDataObject item in cryptocomparefinaldata)
            {
                finaldata.Add(ConvertFromSource(item));
            }
            return finaldata.OrderBy(x => x.Time).ToList();
        }

        private OHCLData ConvertFromSource(Model.CryptoCompare.CryptoCompareOHLCDataObject item)
        {
            return new OHCLData() {Open = item.open, Close = item.close, High = item.high, ID = item.time.ToString(), Low = item.low, Time = Helpers.Conversion.UnixTimeStampToDateTime(item.time), Volume = item.volumefrom, UnixTime = item.time};
        }
        #endregion
    }
}

