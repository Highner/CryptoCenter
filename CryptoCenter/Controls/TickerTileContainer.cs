using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;

namespace CryptoCenter.Controls
{
    public partial class TickerTileContainer : UserControl
    {
        #region properties
        BindingList<ViewModels.ItemViewModelTicker> _Items { get; set; }
        #endregion


        public TickerTileContainer()
        {
            InitializeComponent();
        }

        public void SetItems(BindingList<ViewModels.ItemViewModelTicker> items)
        {
            _Items = items;
            _Items.ListChanged += ListChanged;
        }

        private void ListChanged(object sender, ListChangedEventArgs e)
        {
            if(e.ListChangedType == ListChangedType.ItemAdded)
            {
                AddNewItem(_Items[e.NewIndex]);
            }
            else if(e.ListChangedType == ListChangedType.ItemChanged)
            {

            }
        }

        private void AddNewItem(ViewModels.ItemViewModelTicker item)
        {
            Controls.TickerTile tile = new TickerTile();
            tile.ViewModel = item;
            tile.SetDataBindings();
            FlowPanel.Controls.Add(tile);
        }

    }
}
