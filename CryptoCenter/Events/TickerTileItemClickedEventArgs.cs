using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Events
{
    public class TickerTileItemClickedEventArgs : EventArgs
    {
        public ViewModels.ItemViewModelTicker Item;
    }
}
