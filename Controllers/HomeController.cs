using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Net.NetworkInformation;
using System.Reflection;
using TS_Tool.DataLayer;
using TS_Tool.Models;
using TS_Tool.Service.GetBetInfo;
using TS_Tool.Service.GetSWError;


namespace TS_Tool.Controllers
{
    public class HomeController : Controller
    {


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        private readonly IGetBetInfoService _GetBetInfoService;
        private readonly IGetSWErrorService _GetSWErrorService;
        public HomeController(IGetBetInfoService GetBetInfoService, IGetSWErrorService GetSWErrorService) {
            _GetBetInfoService = GetBetInfoService;
            _GetSWErrorService = GetSWErrorService;
        }
        [HttpPost]
        public IActionResult Index(string Webid, string Refno)
        {
            var betdetailist = _GetBetInfoService.GetBetInfoData(Webid,Refno);
            return PartialView("_BetDetailPartialView", betdetailist);
            

        }
        [HttpPost]
        public IActionResult SWError(string Webid, string Refno) {
            var SWError = _GetSWErrorService.GetSWErrorFromDB(Webid,Refno);
            return PartialView("_SWErrorPartialView", SWError);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
