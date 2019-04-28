using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Data.DataControllers
{
    class CryptoCompareNewsDataController : CryptoDataControllerBase<Model.NewsItemData>
    {
        #region private methods
        protected override List<Model.NewsItemData> GetData(double since)
        {
            List<Model.NewsItemData> finaldata = new List<Model.NewsItemData>();
            string contents = "";
            string url = "https://min-api.cryptocompare.com/data/v2/news/";
            using (var wc = new System.Net.WebClient())
                contents = wc.DownloadString(url);

            var responsedata = Newtonsoft.Json.JsonConvert.DeserializeObject<Model.CryptoCompare.CryptoCompareDataObject<Model.CryptoCompare.CryptoCompareNewsItemDataObject>>(contents);

            foreach (Model.CryptoCompare.CryptoCompareNewsItemDataObject item in responsedata.Data)
            {
                finaldata.Add(ConvertFromSource(item)); 
            }
            double sinceunixtime;
            if(since == 0)
            {
                sinceunixtime = finaldata.Min(x => x.UnixTime);
            }
            else
            {
                sinceunixtime = since;
            }
            return finaldata.Where(x => x.UnixTime > sinceunixtime).OrderBy(x => x.Time).ToList();
        }
        private Model.NewsItemData ConvertFromSource(Model.CryptoCompare.CryptoCompareNewsItemDataObject item)
        {
            return new Model.NewsItemData() { Body = item.body, Categories = item.categories, ID = item.id.ToString(), ImageLink = item.imageurl, Source = item.source, Tags = item.tags, Time = Helpers.Conversion.UnixTimeStampToDateTime(item.published_on), Title = item.title, UnixTime = item.published_on, Url = item.url };
        }
        #endregion
    }
}
