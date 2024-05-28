using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TS_Tool.Models;

namespace TS_Tool.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetInfoController : ControllerBase
    {
        private readonly IConfiguration _configuration;

    }
}
