using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CryptoCenter.ViewModels.Base
{
    public class ItemViewModelBase<data> : ViewModelBase where data : Interfaces.IIsListViewItem
    {
        private data _Data;
        [Browsable(false)]
        public data Data
        {
            get
            {
                return _Data;
            }
            set
            {
                _Data = value;
                AllPropertiesChanged();
            }
        }
        [Browsable(false)]
        public bool Selected;
    }
}
