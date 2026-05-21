using CoreWCF;
using WCF_Service_Application.Models;

namespace WCF_Service_Application.Services.Contracts
{
    [ServiceContract]
    public interface ITruckService
    {
        [OperationContract]
        TruckModel GetTruckById(int id);
    }
}
