using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Model
{
    public class DataRepositoryBase<t> : Interfaces.IHasNewDataAdded<t> where t : Interfaces.IHasUnixTime
    {
        public List<t> Items = new List<t>();
        public bool ReplaceOnly = false;

        public void AddItems(t[] items)
        {
            if(ReplaceOnly) { Items.Clear(); }
            List<t> changeditems = new List<t>();
            foreach(t item in items)
            {
                if(Items.Where(x => x.UnixTime == item.UnixTime).Any())
                {
                    int index = Items.IndexOf(Items.Where(x => x.UnixTime == item.UnixTime).Single());
                    var currentien = Items[index];
                    if(!(Helpers.PropertyComparison.PublicInstancePropertiesEqual(currentien, item)))
                    {
                        Items.RemoveAt(index);
                        Items.Insert(index, item);
                        changeditems.Add(item);
                    }
                }
                else
                {
                    Items.Add(item);
                    changeditems.Add(item);
                }
            }
            if(items.Any()) { OnNewDataAdded(changeditems.ToArray()); }
        }

        public void Clear()
        {
            Items.Clear();
            OnDataCleared();
        }

        public void OnNewDataAdded(t[] items)
        {
            EventHandler<Services.DataServiceNewDataEventArgs<t>> tmpevent = DataChanged;
            if(tmpevent != null)
            {
                tmpevent(this, new Services.DataServiceNewDataEventArgs<t>() { Items = items });
            }
        }
        public void OnDataCleared()
        {
            EventHandler tmpevent = DataCleared;
            if (tmpevent != null)
            {
                tmpevent(this, null);
            }
        }
        public event EventHandler<Services.DataServiceNewDataEventArgs<t>> DataChanged;
        public event EventHandler DataCleared;
    }
}
