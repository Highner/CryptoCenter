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
            NewData += OnNewData;
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
        #endregion

            #region private methods
        private void TimerTick(object sender, EventArgs e)
        {
            if (!(_FetchingData)) { GetNewData(); };
        }
        async void GetNewData()
        {
            _FetchingData = true;
            var result = await Task.Run(() => _Controller.GetNewData(_Repository));
            _FetchingData = false;
            if (result.Any()) { NewData(this, new DataServiceNewDataEventArgs<t>() { Items = result }); }
        }
        private void OnNewData(object sender, DataServiceNewDataEventArgs<t> e)
        {
            _Repository.OnNewDataAdded( e.Items );
        }
   
        #endregion

        #region events
        private event EventHandler<DataServiceNewDataEventArgs<t>> NewData;
        #endregion
    }
}
