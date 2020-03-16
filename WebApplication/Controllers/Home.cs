using System.Collections.Generic;
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
        public IActionResult GetSolution([FromBody] Data data)
        {
            var a = 0;
            int[,] matrix = CopyMatrix(data);
            
            var goods1 = new [] {140, 50, 260};
            var needs1 = new [] {150, 170, 30, 90, 10};
            var matrix1 = new [,]
            {
                { 3, 4, 6, 4, 10},
                { 9, 10, 15, 12, 6},
                { 8, 8, 14, 8, 5}
            };
            
            var distributer = new Distributer();
            List<DistributedGood> result = distributer.Distribute(matrix, data.Goods, data.Needs);
            
            return Ok(result);
        }

        public int[,]  CopyMatrix(Data data)
        {
            
            int[,] matrix = new int[data.Goods.Length, data.Needs.Length];
            
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = data.Matrix[i][j];
                }
            }

            return matrix;
        }
    }
}