using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assigenmet2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class J3Controller : ControllerBase
    {


        [HttpPost(template: "SecretInstruction")]
        [Consumes("application/x-www-form-urlencoded")]
        /// <summary>
        /// Decodes a sequence of instructions to determine the direction and number of steps based on given input.
        /// </summary>
        /// <param name="a">A comma-separated list of 5-digit strings representing instructions.</param>
        /// <returns>A string indicating the direction (left or right) and the number of steps for each instruction.</returns>
        /// <example>
        /// POST: api/J3/SecretInstruction
        /// Headers: Content-Type: application/x-www-form-urlencoded
        /// Post data: a=57234,00907,34100,99999
        /// 
        /// Response:
        /// right 234
        /// right 907
        /// left 100
        /// 
        /// In this example:
        /// - The instruction "57234" results in a direction of "right" with 234 steps.
        /// - The instruction "00907" results in a direction of "right" with 907 steps.
        /// - The instruction "34100" results in a direction of "left" with 100 steps.
        /// 
        /// The sequence stops processing when "99999" is encountered.
        /// </example>

        public string StepsCounter([FromForm] string a)
        {

            string[] Command = a.Split(',');

            string result= "";
            string lastD = "";


            foreach (var i in Command)
            {

                if (i == "99999")
                {
                    break;
                }


             
                string direction;
                int c = int.Parse(i.Substring(0, 2));
                int d = int.Parse(i.Substring(2, 3));


                int sumOFfirsttwo = (c / 10) + (c % 10);

               
             
                if (sumOFfirsttwo == 0)
                {
                    direction = lastD; 
                }
                else if (sumOFfirsttwo % 2 == 0)
                {
                    direction = "right"; 
                }
                else
                {
                    direction = "left";
                }

              
              
                
                lastD = direction;

                result += $"{direction} {d}\n";
            }
            return result.TrimEnd('\n');
        }
    }
}
