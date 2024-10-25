using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assigenmet2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2Controller : ControllerBase
    {
        [HttpPost(template: "Epidemiology")]
        [Consumes("application/x-www-form-urlencoded")]
        /// <summary>
        /// Calculates the number of days required for total infections to exceed a specified limit.
        /// </summary>
        /// <param name="A">The maximum allowable total number of infections.</param>
        /// <param name="B">The initial number of infections on the first day.</param>
        /// <param name="C">The multiplication factor of new infections per day.</param>
        /// <returns>The number of days it takes for total infections to exceed the maximum limit.</returns>
        /// <example>
        /// POST: api/J2/Epidemiology
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// Post data: A=1000&B=1&C=2
        /// 
        /// Response:
        /// 8
        /// 
        /// In this example, the calculation is as follows:
        /// - Day 0: 1 infected
        /// - Day 1: 1 * 2 = 2 new infections, total = 1 + 2 = 3
        /// - Day 2: 2 * 2 = 4 new infections, total = 3 + 4 = 7
        /// - Day 3: 4 * 2 = 8 new infections, total = 7 + 8 = 15
        /// - Day 4: 8 * 2 = 16 new infections, total = 15 + 16 = 31
        /// - Day 5: 16 * 2 = 32 new infections, total = 31 + 32 = 63
        /// - Day 6: 32 * 2 = 64 new infections, total = 63 + 64 = 127
        /// - Day 7: 64 * 2 = 128 new infections, total = 127 + 128 = 255
        /// - Day 8: 128 * 2 = 256 new infections, total = 255 + 256 = 511
        /// - Day 9: 256 * 2 = 512 new infections, total = 511 + 512 = 1023 (exceeds 1000)
        /// 
        /// Thus, it takes 8 days for the total infections to exceed the maximum limit of 1000.
        /// </example>

        public int Firstdays([FromForm]int A,[FromForm] int B,[FromForm] int C)
        {
            int totalInfection = B; 
            int currentInfected = B; 
            int day = 0; 
            while (totalInfection <= A)
            {
                day++; 
                currentInfected *= C; 
                totalInfection += currentInfected; 
            }
            return day;
        }

    }
}
