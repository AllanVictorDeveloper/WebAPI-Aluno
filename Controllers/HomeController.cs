using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapi.ModelViews;

namespace webapi.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
    
        [HttpGet]
        // public HomeView Index()
        // {
        //     return new HomeView() ;
        // }

        public ActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}
