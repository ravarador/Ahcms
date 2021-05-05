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
    public class AttendeeController : ControllerBase
    {
        private AhcmsContext _ahcmsContext;
        private readonly ILogger<AttendeeController> _logger;
        public AttendeeController(ILogger<AttendeeController> logger, AhcmsContext ahcmsContext)
        {
            _logger = logger;
            _ahcmsContext = ahcmsContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var attendees = _ahcmsContext.Attendees.ToList();
            return Ok(attendees);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var attendee = _ahcmsContext.Attendees.Where(a => a.Id == id).SingleOrDefault();
            return Ok(attendee);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Attendee attendeeToAdd)
        {
            if (_ahcmsContext.Attendees.Where(a => a.AttendeeRFID == attendeeToAdd.AttendeeRFID).Any())
            {
                return ValidationProblem("RFID already registered");
            }
            else
            {
                _ahcmsContext.Attendees.Add(attendeeToAdd);
                _ahcmsContext.SaveChanges();
                return Ok("Registration successful");
            }

        }

        [HttpPut]
        public IActionResult Put([FromBody] Attendee attendee)
        {
            var attendeeToUpdate = _ahcmsContext.Attendees.Where(a => a.Id == attendee.Id).SingleOrDefault();
            attendeeToUpdate.Name = attendee.Name;
            attendeeToUpdate.AttendeeRFID = attendee.AttendeeRFID;
            attendeeToUpdate.Age = attendee.Age;
            attendeeToUpdate.Address = attendee.Address;
            return Ok(_ahcmsContext.SaveChanges());
        }

        [HttpPost]
        [Route("UpdateAttendeeStatus")]
        public IActionResult UpdateAttendeeStatus([FromBody] Attendee attendee)
        {
            var attendeeToUpdate = _ahcmsContext.Attendees.Where(a => a.Id == attendee.Id).SingleOrDefault();
            attendeeToUpdate.Status = attendee.Status;
            return Ok(_ahcmsContext.SaveChanges());
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var attendee = _ahcmsContext.Attendees.Where(a => a.Id == id).SingleOrDefault();
            _ahcmsContext.Attendees.Remove(attendee);
            return Ok(_ahcmsContext.SaveChanges());
        }

        [HttpPost]
        [Route("GetAttendeeBySearchParameter")]
        public IActionResult Get(SearchDto searchDto)
        {
            var attendees = _ahcmsContext.Attendees.AsEnumerable();

            switch (searchDto.SearchBy.ToUpper().Trim())
            {
                case "NAME":
                    attendees = attendees.Where(a => a.Name.Contains(searchDto.SearchText));
                    break;
                case "ADDRESS":
                    attendees = attendees.Where(a => a.Address.Contains(searchDto.SearchText));
                    break;
                default:
                    break;

            }

            return Ok(attendees.ToList());
        }

    }
}
