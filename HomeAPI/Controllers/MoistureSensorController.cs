using HomeAPI.Models;
using Microsoft.AspNetCore.Mvc;


namespace HomeAPI.Controllers
{

    [ApiController]
    [Route("/SensorInfo")]
    public class SensorInfoController : ControllerBase
    {
        [HttpGet]
        public SensorInformation[] AllSensors()
        {
  
            SensorInfoContext context = new();

            SensorInformation[] sensors = [.. context.Info];
            return sensors;
        }

        [HttpPost]
        [ProducesResponseType<String>(StatusCodes.Status200OK)]
        [ProducesResponseType<String>(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] SensorInfoModel model)
        {   
            SensorInfoContext db = new();

            SensorInformation sensorInfo = new() { Plant = model.Plant, MoistureLevel = model.MoistureLevel, SensorId = model.SensorID };

            try
            {
                db.Add(sensorInfo);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message + "   " + model.Plant);
            }


            return Ok("Success");

        }



    }
}
