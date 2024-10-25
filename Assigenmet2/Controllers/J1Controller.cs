using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assigenmet2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J1Controller : ControllerBase
    {
        [HttpPost(template: "Delivedroid")]
        [Consumes("application/x-www-form-urlencoded")]

        /// <summary>
        /// Calculates the final score based on the number of deliveries and collisions.
        /// </summary>
        /// <param name="Delivery">The number of successful deliveries made.</param>
        /// <param name="Collision">The number of collisions that occurred.</param>
        /// <returns>The final score calculated from the deliveries and collisions, with additional points for a higher delivery count.</returns>
        /// <example>
        /// POST: api/J1/Delivedroid
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// Post data: Delivery=10&Collision=2
        /// 
        /// Response:
        /// 560
        /// 
        /// In this example, the final score is calculated as follows:
        /// - Delivery: 10 * 50 = 500
        /// - Collision: 2 * -10 = -20
        /// - Total score before bonus: 500 - 20 = 480
        /// - Bonus for more deliveries than collisions: 500
        /// - Final score: 480 + 500 = 980
        /// </example>

        public int FinalScore([FromForm] int Delivery, [FromForm] int Collision)
        {
            int total = Delivery * 50 + (Collision * -10);
            if (Delivery > Collision)
            {
                total += 500;
            }
            return total;
        }
    }
}
