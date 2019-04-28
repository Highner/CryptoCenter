using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.ViewModels
{
    public class ItemViewModelNews: Base.ItemViewModelBase<Model.NewsItemData>
    {
        public string Title
        {
            get
            {
                return Data.Title;
            }
        }
        public string Body
        {
            get
            {
                return Data.Body;
            }
        }
    }
}
