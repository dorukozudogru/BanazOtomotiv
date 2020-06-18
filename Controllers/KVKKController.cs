using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BanazOtomotiv.Controllers
{
    public class KVKKController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}