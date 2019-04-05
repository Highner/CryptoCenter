using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoCenter
{
    public partial class CryptoCenterMainForm : Form
    {
        public CryptoCenterMainForm()
        {
            InitializeComponent();
            var cont = new Data.DataControllers.CryptoCompareDataController(Enumerables.DataIntervalTypeEnum.Minute, "BTC", "USD");
            var repo = new Model.DataRepositoryBase<Model.OHCLData>();
            var serv = new Services.DataServiceBase<Model.OHCLData>(cont, repo, 10000);
            repo.NewDataAdded += dataadded;
            serv.Start();
        }

        private void dataadded(object sender, Services.DataServiceNewDataEventArgs<Model.OHCLData> e)
        {
            System.Windows.Forms.MessageBox.Show("new data added with: " + e.Items.LastOrDefault().Time.ToShortTimeString());
        }
    }
}
