using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Domain;

namespace TestTesk.Application.Interfaces
{
    public interface IDeviceRepository
    {
        Task<List<Device>> GetAllDevicesAsync();
        Task<Device> GetDeviceAsync(string deviceToken);
        Task AddDeviceAsync(string deviceToken, string experiment, string receivedValue);
    }
}
