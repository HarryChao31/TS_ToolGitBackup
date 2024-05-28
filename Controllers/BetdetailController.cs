
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Net.NetworkInformation;
using System.Reflection;
using TS_Tool.Models;
namespace TS_Tool.Controllers
{
    public class BetdetailController : Controller
    {
        public IActionResult Betdetail(string webIdInput, string refnoInput)
        {
            ViewBag.WebId = webIdInput;
            ViewBag.Refno = refnoInput;
            var betdetail = new Betdetail { }; // Webid = 3, Refno = "33333", UserName = "TestHarry", Transid = 33333, MatchResultId = 1234567, Status = "Won", OsStatus = "Won", BetType = 1, BetOption = "H", Remark = "", Action = "Deduct", ErrorMessage = "No Error", HostName = "test-wl.com.tw", Request = "{Username = 'TestHarry',Refno = '33333',Amount = 10}" };

            return View(betdetail);
        }
    }
}
