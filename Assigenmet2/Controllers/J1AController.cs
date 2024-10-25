using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assigenmet2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /// <summary>
    /// Calculates the pressure based on the given boiling point and determines the altitude level.
    /// </summary>
    /// <param name="boil">The boiling point in degrees, used to calculate the pressure.</param>
    /// <returns>A list of integers where the first element is the calculated pressure value and the second element is the altitude level: 
    /// -1 for high altitude, 0 for sea level, and 1 for low altitude.</returns>
    /// <example>
    /// GET: api/J1A/Del?boil=120
    /// 
    /// Response:
    /// [100, 0]
    /// 
    /// In this example, the boiling point is 120, which results in a calculated pressure of 100 and an altitude level of 0 (sea level).
    /// </example>

    public class J1AController : ControllerBase
    {
      
        [HttpGet(template: "Del")]
      
        public List<int> CalculatePressure(int boil)
        {
            int v = (5 * boil) - 400;
            int altitudeLevel;
            if (v > 100)
            {
                altitudeLevel = -1;
            }
            else if (v == 100)
            {
                altitudeLevel = 0;

            }
            else
            {
                altitudeLevel = 1;
            }
            return new List<int> { v, altitudeLevel };
        }

    }
}
