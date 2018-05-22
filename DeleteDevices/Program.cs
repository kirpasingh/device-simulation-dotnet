using System;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common.Exceptions;

namespace DeleteDevices
{
    class Program
    {
        private static RegistryManager _registryManager;
        private const string CONNECTION_STRING = "HostName=dronedelivery-hub.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=piyOLcq3OmNJQwahDp/RZ0Bxpwj+B4/x9iVK4Oyw7QU=";

        static void Main(string[] args)
        {
            _registryManager = RegistryManager.CreateFromConnectionString(CONNECTION_STRING);
            DeleteDevices.DeleteAllDevices(_registryManager).Wait();
        }
    }

    class DeleteDevices
    {
        public static async Task DeleteAllDevices(RegistryManager registryManager)
        {
            for (int i = 0; i < 100; i++)
            {
                var query = registryManager.CreateQuery("SELECT * FROM devices", 5000);
                while (query.HasMoreResults)
                {

                    var page = await query.GetNextAsTwinAsync();
                    foreach (var twin in page)
                    {
                        string deviceId = twin.DeviceId;
                        await registryManager.RemoveDeviceAsync(deviceId);
                        Console.WriteLine(deviceId + " deleted!");
                    }
                }
            }
        }
    }
}
