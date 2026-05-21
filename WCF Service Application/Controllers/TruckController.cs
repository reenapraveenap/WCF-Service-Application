using Microsoft.AspNetCore.Mvc;
using WCF_Service_Application.Services.Contracts;

namespace WCF_Service_Application.Controllers
{
    public class TruckController : Controller
    {
        private readonly ITruckService _truckService;

        public TruckController(ITruckService truckService)
        {
            _truckService = truckService;
        }

        public IActionResult Index()
        {
            var truck = _truckService.GetTruckById(1);

            return View(truck);
        }
    }
}

