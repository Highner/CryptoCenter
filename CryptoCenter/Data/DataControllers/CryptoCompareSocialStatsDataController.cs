using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoCenter.Enumerables;

namespace CryptoCenter.Data.DataControllers
{
    class CryptoCompareSocialStatsDataController : CryptoDataControllerBase<Model.Main.SocialStatsData>
    {
        #region private fields
        protected DataIntervalTypeEnum _Interval;
        #endregion

        #region constructor
        public CryptoCompareSocialStatsDataController(DataIntervalTypeEnum interval)
        {
            _Interval = interval;
        }
        #endregion

        #region private methods
        protected override List<Model.Main.SocialStatsData> GetData(double since)
        {
            List<Model.Main.SocialStatsData> finaldata = new List<Model.Main.SocialStatsData>();

            List<Model.CryptoCompare.CryptoCompareSocialStatsDataObject> cryptocomparefinaldata = new List<Model.CryptoCompare.CryptoCompareSocialStatsDataObject>();

            int limit = 1000;
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
                string url = "https://min-api.cryptocompare.com/data/social/coin/histo/" + _Interval.ToString().ToLower() + "?&limit=" + limit + timestamp + "&api_key=" + Settings.CryptoConstants.CryptoCompareAPIKey;
                using (var wc = new System.Net.WebClient())
                    contents = wc.DownloadString(url);

                var responsedata = Newtonsoft.Json.JsonConvert.DeserializeObject<Model.CryptoCompare.CryptoCompareDataObject<Model.CryptoCompare.CryptoCompareSocialStatsDataObject>>(contents);
                cryptocomparefinaldata.AddRange(responsedata.Data.ToList());
            }

            foreach (Model.CryptoCompare.CryptoCompareSocialStatsDataObject item in cryptocomparefinaldata)
            {
                finaldata.Add(ConvertFromSource(item));
            }
            double sinceunixtime;
            if (since == 0)
            {
                sinceunixtime = finaldata.Min(x => x.UnixTime);
            }
            else
            {
                sinceunixtime = since;
            }

         
            return finaldata.Where(x => x.UnixTime > sinceunixtime).OrderBy(x => x.Time).ToList();
        }
        private Model.Main.SocialStatsData ConvertFromSource(Model.CryptoCompare.CryptoCompareSocialStatsDataObject item)
        {
            return new Model.Main.SocialStatsData() { Comments = item.comments, FacebookLikes = item.fb_likes, Followers = item.followers, ID = item.time.ToString(), ListID = "CryptoCompareSocialStats" + _Interval.ToString(), PageViews = item.total_page_views, Points = item.points, Posts = item.posts, RedditCommentsPerDay = item.reddit_comments_per_day, RedditPostsPerDay = item.reddit_posts_per_day, RedditSubscribers = item.reddit_subscribers, Time = Helpers.Conversion.UnixTimeStampToDateTime(item.time), TwitterFollowers = item.twitter_followers, UnixTime = item.time };
        }
        #endregion
    }
}
