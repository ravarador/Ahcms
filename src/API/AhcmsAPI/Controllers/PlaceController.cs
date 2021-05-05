using AhcmsAPI.Models;
using AhcmsAPI.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AhcmsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private AhcmsContext _ahcmsContext;
        private readonly ILogger<PlaceController> _logger;
        public PlaceController(ILogger<PlaceController> logger, AhcmsContext ahcmsContext)
        {
            _logger = logger;
            _ahcmsContext = ahcmsContext;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var places = _ahcmsContext.Places.ToList();
            return Ok(places);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(int id)
        {
            var place = _ahcmsContext.Places.Where(a => a.Id == id).SingleOrDefault();
            return Ok(place);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Place placeToAdd)
        {
            _ahcmsContext.Places.Add(placeToAdd);
            return Ok(_ahcmsContext.SaveChanges());
        }

        [HttpPut]
        public ActionResult Put([FromBody] Place place)
        {
            var placeToUpdate = _ahcmsContext.Places.Where(a => a.Id == place.Id).SingleOrDefault();
            placeToUpdate.Location = place.Location;
            return Ok(_ahcmsContext.SaveChanges());
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var place = _ahcmsContext.Places.Where(a => a.Id == id).SingleOrDefault();
            _ahcmsContext.Places.Remove(place);
            return Ok(_ahcmsContext.SaveChanges());
        }

        [HttpPost]
        [Route("GetPlaceBySearchParameter")]
        public ActionResult GetPlaceBySearchParameter(SearchDto searchDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var places = _ahcmsContext.Places.AsEnumerable();

            switch (searchDto.SearchBy.ToUpper().Trim())
            {
                case "LOCATION":
                    places = places.Where(a => a.Location.Contains(searchDto.SearchText));
                    break;

                default:
                    break;

            }

            return Ok(places.ToList());
        }
    }
}
