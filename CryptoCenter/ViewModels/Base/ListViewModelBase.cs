using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CryptoCenter.ViewModels.Base
{

        public class ListViewModelBase<itemviewmodel, data> : ViewModelBase
        where itemviewmodel : ItemViewModelBase<data>
        where data : Interfaces.IIsListViewItem
    {

        #region properties
        private BindingList<itemviewmodel> _Items = new BindingList<itemviewmodel>();
        public BindingList<itemviewmodel> Items
        {
            get
            {
                return _Items;
            }
            set
            {
                _Items = value;
                OnPropertyChanged("Items");
            }
        }
        public Type DataType
        {
            get
            {
                return (typeof(data));
            }
        }
        #endregion


        #region constructor
        public ListViewModelBase()
        {

        }
        #endregion

        #region public methods
        public void ReplaceItemData(data newdata)
        {
            var items = Items.Where(x => x.Data.ID == newdata.ID);
            if( items.Any())
            {
                itemviewmodel item = items.FirstOrDefault();
                item.Data = newdata;
                item.AllPropertiesChanged();
            }
        }
        public void ReplaceOrAddItemData(data newdata)
        {
            var items = Items.Where(x => x.Data.ID == newdata.ID);
            if (items.Any())
            {
                itemviewmodel item = items.FirstOrDefault();
                item.Data = newdata;
                item.AllPropertiesChanged();
            }
            else
            {
                AddItem(newdata);
            }
        }
        public void ReplaceItemData(data[] newdata)
        {
            foreach(data data in newdata)
            {
                ReplaceItemData(data);
            }
        }
        public void ReplaceOrAddItemData(data[] newdata)
        {
            foreach (data data in newdata)
            {
                ReplaceOrAddItemData(data);
            }
        }
        public void AddItems(data[] newitems)
        {
            foreach(data item in newitems)
            {
                AddItem(item);
            }
        }
        public void AddItem(data newitem)
        {
            itemviewmodel newvmiten = (itemviewmodel)Activator.CreateInstance(typeof(itemviewmodel));
            newvmiten.Data = newitem;
            Items.Add(newvmiten);
        }
        #endregion
    }
}
