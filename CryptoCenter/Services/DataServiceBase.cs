using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCenter.Services
{
    public class DataServiceBase<t> where t : Interfaces.IHasUnixTime
    {
        #region private fields
        private System.Windows.Forms.Timer _Timer = new System.Windows.Forms.Timer();
        private Interfaces.IHasGetNewData<t> _Controller;
        private Model.DataRepositoryBase<t> _Repository;
        private bool _FetchingData = false;
        #endregion

        #region constructor
        public DataServiceBase(Interfaces.IHasGetNewData<t> controller, Model.DataRepositoryBase<t> repository, int timerinterval)
        {
            _Controller = controller;
            _Repository = repository;
            _Timer.Interval = timerinterval;
            _Timer.Tick += TimerTick;
        }
        #endregion

        #region public methods
        public void Start()
        {
            _Timer.Start();
        }

        public void Stop()
        {
            _Timer.Stop();
        }
        public void SetTimerInterval(int milliseconds)
        {
            bool timerrunning = _Timer.Enabled;
            if (timerrunning) { _Timer.Stop(); };
            _Timer.Interval = milliseconds;
            if (timerrunning) { _Timer.Start(); };
        }
        public void GetData()
        {
            GetNewData();
        }
        #endregion

        #region private methods
        private void TimerTick(object sender, EventArgs e)
        {
            GetNewData();
        }
        async void GetNewData()
        {
            if (!(_FetchingData))
            {
                _FetchingData = true;
                var result = await Task.Run(() => _Controller.GetNewData(_Repository));
                _FetchingData = false;
                if (result.Any()) { OnNewData(result); }
            }
        }
        private void OnNewData(t[] items)
        {
            EventHandler<Services.DataServiceNewDataEventArgs<t>> tmpevent = NewData;
            if (tmpevent != null)
            {
                tmpevent(this, new Services.DataServiceNewDataEventArgs<t>() { Items = items });
            }
        }
        #endregion

        #region events
        private event EventHandler<DataServiceNewDataEventArgs<t>> NewData;
        #endregion
    }
}
