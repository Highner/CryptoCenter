using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Model.Main
{
    public class SocialStatsData : Interfaces.IIsListViewItem, Interfaces.IHasUnixTime
    {
        public string ID { get; set; }
        public string ListID { get; set; }
        public double Comments { get; set; }
        public double Posts { get; set; }
        public double Followers { get; set; }
        public double Points { get; set; }
        public double PageViews { get; set; }
        public double FacebookLikes { get; set; }
        public double TwitterFollowers { get; set; }
        public double RedditSubscribers { get; set; }
        public double RedditPostsPerDay { get; set; }
        public double RedditCommentsPerDay { get; set; }
        public int UnixTime { get; set; }
        public DateTime Time;
    }
}
