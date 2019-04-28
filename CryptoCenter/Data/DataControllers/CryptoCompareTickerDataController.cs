using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;

namespace CryptoCenter.Data.DataControllers
{
    class CryptoCompareTickerDataController : TickerDataControllerBase
    {
        #region private fields
        Dictionary<string, System.Drawing.Image> CoinSymbols = new Dictionary<string, System.Drawing.Image>();
        #endregion

        #region public methods
        public CryptoCompareTickerDataController(string[] currenciesfrom, string[] currenciesto)
        {
            _CurrenciesFrom = currenciesfrom;
            _CurrenciesTo = currenciesto;
        }
        #endregion

        #region private methods
        protected override List<Model.Main.TickerData> GetData(double since)
        {
            List<Model.Main.TickerData> finaldata = new List<Model.Main.TickerData>();
            string contents = "";
            string url = "https://min-api.cryptocompare.com/data/pricemultifull?fsyms=" + _CurrenciesFrom.FirstOrDefault() + "&tsyms=" + _CurrenciesTo.FirstOrDefault() ;
            using (var wc = new System.Net.WebClient())
                contents = wc.DownloadString(url);

            Newtonsoft.Json.Linq.JObject o = Newtonsoft.Json.Linq.JObject.Parse(contents);

            Newtonsoft.Json.Linq.JToken a = o.Value< Newtonsoft.Json.Linq.JToken>("RAW");
 
            foreach ( Newtonsoft.Json.Linq.JToken p in a)
            {
                foreach( Newtonsoft.Json.Linq.JToken c in p)
               {
                    foreach (Newtonsoft.Json.Linq.JToken b in c)
                   {
                        foreach (Newtonsoft.Json.Linq.JToken x in b)
                        {
                            Model.CryptoCompare.CryptoCompareTickerDataObject responsedata = JsonConvert.DeserializeObject<Model.CryptoCompare.CryptoCompareTickerDataObject>(x.ToString());
                            finaldata.Add(ConvertFromSource(responsedata));
                        }
                    }
               }
            }
           
            return finaldata.OrderBy(x => x.Time).ToList();
        }
        private Model.Main.TickerData ConvertFromSource(Model.CryptoCompare.CryptoCompareTickerDataObject item)
        {
            System.Drawing.Image image;
            var id = item.FROMSYMBOL + item.TOSYMBOL;
            if(CoinSymbols.ContainsKey(id))
            {
                image = CoinSymbols[id];
            }
            else
            {
                string url = "https://www.cryptocompare.com" + item.IMAGEURL;
                WebClient client = new WebClient();
                System.IO.Stream stream = client.OpenRead(url);
                image = new System.Drawing.Bitmap(stream);
                CoinSymbols.Add(id, image);
            }
    

            return new Model.Main.TickerData() { Image = image, Volume24HourTo = item.VOLUME24HOURTO, Change24Hour = item.CHANGEPCT24HOUR, Close24Hour = item.CLOSE24HOUR, CurrencyFrom = item.FROMSYMBOL, CurrencyTo = item.TOSYMBOL, High24Hour = item.HIGH24HOUR, ID = id, Low24Hour = item.LOW24HOUR, Open24Hour = item.OPEN24HOUR, Price = item.PRICE, Time = Helpers.Conversion.UnixTimeStampToDateTime( item.LASTUPDATE), UnixTime = item.LASTUPDATE, Volume24Hour = item.VOLUME24HOUR };
        }
        #endregion
    }
}
