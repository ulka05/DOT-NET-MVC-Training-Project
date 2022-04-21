using carstructure.Common.Model;
using carstructure.WebApp._2_Services.ServiceClass;
using carstructure.WebApp._2_Services.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace carstructure.WebApp._1_WebAPI.Controllers
{
    [Produces("application/json")]
    
    public class CARController : Controller
    {
        private readonly AudiInterface AudiInterface;

        public CARController(AudiInterface _audiInterface)
        {
            AudiInterface = _audiInterface;
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("api/SearchCar")]

        public async Task<IActionResult> Get(CarSearchingParameter carSearchingParamter)
        {
            var Cars = await AudiInterface.SearchCarAsync(carSearchingParamter);

            if(Cars == null || !Cars.Any())
            {
                return NotFound();
            }
            return Json(Cars);
        }

        [HttpPost]
        [Produces("application/json")]
        [Route("api/InsertCar")]

        public async Task<IActionResult> Post([FromBody]Car car)
        {
            if (await AudiInterface.SaveCarAsync(car))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Unable to save car.....");
            }
        }


        [HttpDelete("delete/{id}")]
        [ProducesResponseType(200, Type = typeof(List<Car>))]
        public async Task<IActionResult> Delete(int id)
        {
            if (await AudiInterface.DeleteCarAsync(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Unable to Delete Data");
            }

        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(List<Car>))]
        public async Task<IActionResult> UpdateCar([FromBody] Car car, [FromRoute] int id)
        {
            if (await AudiInterface.UpdateCarAsync(car, id))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Wrong Input");
            }
        }



    }
}
