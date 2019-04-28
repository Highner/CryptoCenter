using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Model
{
    public class NewsItemData : Interfaces.IIsListViewItem, Interfaces.IHasUnixTime
    {
        public string ID { get; set; }
        public string ListID { get; set; }
        public string Title;
        public string Body;
        public string Source;
        public string Url;
        public string ImageLink;
        public System.Drawing.Image Image;
        public string Tags;
        public string Categories;
        public int UnixTime { get; set; }
        public DateTime Time;
    }
}
