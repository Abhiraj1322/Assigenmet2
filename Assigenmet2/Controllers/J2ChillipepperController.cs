using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assigenmet2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J2ChillipepperController : ControllerBase
    {
        [HttpGet(template: "Chilli Pepper ={ingredients}")]
        /// <summary>
        /// Calculates the total spiciness based on the given list of chili pepper ingredients.
        /// </summary>
        /// <param name="ingredients">A comma-separated string of chili pepper names.</param>
        /// <returns>The total spiciness level calculated from the provided chili peppers.</returns>
        /// <example>
        /// GET: api/J2Chillipepper/Chilli Pepper=Poblano,Mirasol,Serrano
        /// 
        /// Response:
        /// 17600
        /// 
        /// In this example, the total spiciness is calculated as follows:
        /// - Poblano: 1500
        /// - Mirasol: 6000
        /// - Serrano: 15500
        /// - Total spiciness: 1500 + 6000 + 15500 = 23000
        /// </example>

        public int totalspice(string ingredients)
        {
            string[] pepperslist = ingredients.Split(',');
            int total = 0;

            foreach (var pepper in pepperslist)
            {
                switch (pepper)
                {
                    case "Poblano":
                        total += 1500;
                        break;
                    case "Mirasol":
                        total += 6000;
                        break;
                    case "Serrano":
                        total += 15500;
                        break;
                    case "Cayenne":
                        total += 40000;
                        break;
                    case "Thai":
                        total += 75000;
                        break;
                    case "Habanero":
                        total += 125000;
                        break;
                    default:

                        break;
                }
            }
            return total;
        }
    }
}
