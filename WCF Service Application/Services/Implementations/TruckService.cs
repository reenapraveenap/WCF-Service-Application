using WCF_Service_Application.Models;
using WCF_Service_Application.Services.Contracts;

namespace WCF_Service_Application.Services.Implementations
{
    public class TruckService: ITruckService
    {
        public TruckModel GetTruckById(int id)
        {
            return new TruckModel
            {
                TruckId = 1,
                TruckName = "FH16",
                DriverName = "TestingName",
                ServiceStatus = "Active"
            };
        }
    }

}
