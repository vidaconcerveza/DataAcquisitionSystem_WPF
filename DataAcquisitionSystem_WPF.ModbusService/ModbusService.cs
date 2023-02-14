using DataAcquisitionSystem_WPF.Infrastructure.PlcServices;
using Modbus.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DataAcquisitionSystem_WPF.ModbusService
{
    public class ModbusService : IModbusService
    {
        private readonly System.Timers.Timer _timer;
        private TcpClient _client;
        private ModbusIpMaster _mbMaster;
        private DateTime _lastUpdateTime;

        public ConnectionState ConnectionState { get; private set; }
        public TimeSpan ScanTime { get; private set; }

        public event EventHandler ValuesRefreshed;


        public ModbusService()
        {
            _timer = new System.Timers.Timer();
            _timer.Elapsed += OnTimerElapsed;
            _timer.Interval = 100;
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if(_mbMaster == null ||(ConnectionState != ConnectionState.Online))
            {
                return;
            }
            try
            {
                _timer.Stop();
                ScanTime = DateTime.Now - _lastUpdateTime;
                RefreshValues();
                OnValuesRefreshed();
            }
            finally
            {
                _timer.Start();
                _lastUpdateTime = DateTime.Now;
            }
        }

        private void RefreshValues()
        {
            var datas = _mbMaster.ReadInputRegisters(0, 2);
        }

        public void Connect()
        {
            ConnectionState = ConnectionState.Connecting;
            _client = new TcpClient("127.0.0.1", 502);
            _mbMaster = ModbusIpMaster.CreateIp(_client);

            ConnectionState = ConnectionState.Online;
            _timer.Start();
        }

        public void Disconnect()
        {
            _timer.Stop();
            _mbMaster.Dispose();
            _client.Close();

            ConnectionState = ConnectionState.Offline;
        }

        private void OnValuesRefreshed()
        {
            ValuesRefreshed?.Invoke(this, new EventArgs());
        }



        public Task WriteValue(int address, int value)
        {
            return _mbMaster.WriteSingleRegisterAsync(1, 0, (ushort)value);
            //throw new NotImplementedException();
        }
    }
}
