
using DataAcquisitionSystem_WPF.Infrastructure.PlcServices;

namespace DataAcquisitionSystem_WPF.ModbusService
{
    public interface IModbusService
    {
        ConnectionState ConnectionState { get; }
        TimeSpan ScanTime { get; }
        
        event EventHandler ValuesRefreshed;
        void Connect();
        void Disconnect();



        Task WriteValue(int address, int value);
    }
}