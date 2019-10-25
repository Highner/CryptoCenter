using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoCenter.Controls
{
    public partial class BindableTile: UserControl
    {

        #region constructor
        public BindableTile()
        {
           InitializeComponent();
           MouseDoubleClick += OnItemDoubleClicked;
        }
        #endregion

        #region events
        private void OnItemDoubleClicked(object sender, EventArgs e)
        {
            EventHandler tmpevent = ItemDoubleClicked;
            if (tmpevent != null)
            {
                tmpevent(sender, null);
            }
        }

        public event EventHandler ItemDoubleClicked;
        #endregion
    }
}
