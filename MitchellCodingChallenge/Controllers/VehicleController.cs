using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using MitchellCodingChallenge.Models;
using MitchellCodingChallenge.Services;

namespace MitchellCodingChallenge.Controllers
{
    [EnableCors("AllowAllOrigin")]
    [Route("api/vehicles")]
    [ApiController]

    public class VehicleController : ControllerBase
    {
        VehiclePersistence vp = new VehiclePersistence();
 
        [HttpGet]
        public List<Vehicle> Get()//Get all
        {
            return vp.GetAllVehicles();
        }


        [HttpGet("{id}")]
        public Vehicle Get(int id)//Get by id
        {
            return vp.GetVehicleByID(id);
        }

        [HttpGet("filter")]
        public List<Vehicle> Get(string Id = " ", string Model = " ", string Make = " ", string Year = " ")//Get by parameters
        {
            return vp.GetAllVehiclesByFilter(Id, Year, Make, Model);
        }

        [HttpPost]
        public void Post([FromBody] Vehicle req)//Create new
        {
            vp.CreateNewVehicle(req);
        }

        [HttpPut]
        public void Put([FromBody] Vehicle req)//Update existing
        {
            vp.UpdateVehicle(req);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)//by id
        {
            vp.RemoveAVehicle(id);
        }




    }
}