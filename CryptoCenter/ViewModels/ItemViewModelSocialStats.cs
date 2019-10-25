using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.ViewModels
{
    public class ItemViewModelSocialStats : Base.ItemViewModelBase<Model.Main.SocialStatsData>, Interfaces.IIsChartItem
    {
        public double TwitterFollowers
        {
            get
            {
                return Data.TwitterFollowers;
            }
        }
        public double FacebookLikes
        {
            get
            {
                return Data.FacebookLikes;
            }
        }
        public double Followers
        {
            get
            {
                return Data.Followers;
            }
        }
        public double Posts
        {
            get
            {
                return Data.Posts;
            }
        }
        public double Points
        {
            get
            {
                return Data.Points;
            }
        }
        public double RedditDailyComments
        {
            get
            {
                return Data.RedditCommentsPerDay;
            }
        }
        public double RedditDailyPosts
        {
            get
            {
                return Data.RedditPostsPerDay;
            }
        }
        public DateTime Time
        {
            get
            {
                return Data.Time;
            }
        }
        public string XAxisValue { get { return Data.Time.ToString(); } }
    }
}
