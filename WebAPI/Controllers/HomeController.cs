using System.Collections.Generic;
using HungarianAlgoritm;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public IActionResult Index(TaskData data)
        {
            var distributer = new Distributer();
            List<DistributedGood> res = distributer.Distribute(data.Matrix, data.Goods, data.Needs);
            
            return Ok(res);
        }
    }
}