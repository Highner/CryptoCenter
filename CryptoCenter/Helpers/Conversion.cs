using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Helpers
{
    public static class Conversion
    {
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        public static double DateTimeToUnixTimeStamp(DateTime time)
        {
            Int32 unixTimestamp = (Int32)(time.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return unixTimestamp;
        }

        public static List<Model.BitThought.SourceData> CreateSourceData(List<Model.OHCLData> items)
        {
            List<Model.BitThought.SourceData> list = new List<Model.BitThought.SourceData>();

            for (int i = 1; i < items.Count(); i++)
            {
                var item = items[i];
                var newitem = new Model.BitThought.SourceData { Open = item.Open, Close = item.Close, High = item.High, Low = item.Low, UnixTime = item.UnixTime, Volume = item.Volume };
           
                    var previtem = items[i - 1];
                    var openchange = ((newitem.Open - previtem.Open) / Math.Abs(previtem.Open));
                    newitem.OpenChange = openchange;

                    var highchange = ((newitem.High - previtem.High) / Math.Abs(previtem.High));
                    newitem.HighChange = highchange;

                    var lowchange = ((newitem.Low - previtem.Low) / Math.Abs(previtem.Low));
                    newitem.LowChange = lowchange;

                    var closechange = ((newitem.Close - previtem.Close) / Math.Abs(previtem.Close));
                    newitem.CloseChange = closechange;

                    var volumechange = ((newitem.Volume - previtem.Volume) / Math.Abs(previtem.Volume));
                    newitem.VolumeChange = volumechange;
         
                list.Add(newitem);
            }

            return list;
        }
    }
}
