using System.Collections.Generic;
using HungarianAlgoritm;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class Home : Controller
    {

        [HttpGet]
        public IActionResult GetSln()
        {
            return Ok();
        }
        
        [HttpPut]
        public IActionResult GetSolution([FromBody] ClassData data)
        {
            var a = 0;
            int[,] matrix = CopyMatrix(data);
            
            Distributer distributer = new Distributer();
            List<DistributedGood> result = distributer.Distribute(matrix, data.Goods, data.Needs);
            
            return Ok(result);
        }

        public int[,]  CopyMatrix(ClassData data)
        {
            
            int[,] matrix = new int[data.Goods.Length,data.Needs.Length];
            
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(0); j++)
                {
                    matrix[i, j] = data.Matrix[i][j];
                }
            }

            return matrix;
        }
    }
}