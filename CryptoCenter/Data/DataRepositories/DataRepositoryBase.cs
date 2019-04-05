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

        public void AddItems(t[] items)
        {
            Items.AddRange(items);
        }

        public void OnNewDataAdded(t[] items)
        {
            NewDataAdded(this, new Services.DataServiceNewDataEventArgs<t>() { Items = items });
        }

        public event EventHandler<Services.DataServiceNewDataEventArgs<t>> NewDataAdded;
    }
}
