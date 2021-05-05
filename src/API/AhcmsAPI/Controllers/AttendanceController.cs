using AhcmsAPI.Models;
using AhcmsAPI.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AhcmsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private AhcmsContext _ahcmsContext;
        private readonly ILogger<AttendanceController> _logger;

        public AttendanceController(ILogger<AttendanceController> logger, AhcmsContext ahcmsContext)
        {
            _logger = logger;
            _ahcmsContext = ahcmsContext;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var attendaces = _ahcmsContext.Attendances.Include(a => a.Attendee)
                                                 .Include(a => a.Place)
                                                 .Select(a => new AttendanceDto
                                                 {
                                                     Id = a.Id,
                                                     VisitedDateTime = a.VisitedDateTime,
                                                     Temperature = a.Temperature,
                                                     AttendeeId = a.Attendee.Id,
                                                     AttendeeRFID = a.Attendee.AttendeeRFID,
                                                     AttendeeStatus = a.Attendee.Status,
                                                     Status = a.Status,
                                                     ContactNumber = a.Attendee.ContactNumber,
                                                     Name = a.Attendee.Name,
                                                     Age = a.Attendee.Age,
                                                     Address = a.Attendee.Address,
                                                     PlaceId = a.Place.Id,
                                                     Location = a.Place.Location
                                                 })
                                                 .ToList();


            return Ok(attendaces);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(int id)
        {
            var attendance = _ahcmsContext.Attendances.Include(a => a.Attendee)
                                                 .Include(a => a.Place)
                                                 .Where(a => a.Id == id)
                                                 .SingleOrDefault();

            return Ok(attendance);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Attendance attendanceToAdd)
        {
            _ahcmsContext.Attendances.Add(attendanceToAdd);
            return Ok(_ahcmsContext.SaveChanges());
        }

        [HttpDelete]
        public void Delete(int id)
        {
            var attendance = _ahcmsContext.Attendances.Where(a => a.Id == id).SingleOrDefault();
            _ahcmsContext.Attendances.Remove(attendance);
            _ahcmsContext.SaveChanges();
        }

        [HttpPost]
        [Route("UpdateAttendanceStatus")]
        public ActionResult UpdateAttendanceStatus([FromBody] Attendance attendance)
        {
            var attendanceToUpdate = _ahcmsContext.Attendances.Where(a => a.Id == attendance.Id).SingleOrDefault();
            attendanceToUpdate.Status = attendance.Status;
            return Ok(_ahcmsContext.SaveChanges());
        }

        [HttpPost]
        [Route("GetAttendanceBySearchParameter")]
        public ActionResult GetAttendanceBySearchParameter(SearchDto searchDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var attendances = _ahcmsContext.Attendances.Include(a => a.Attendee)
                                                  .Include(a => a.Place)
                                                  .Where(a => a.PlaceId == searchDto.PlaceId)
                                                  .Select(a => new AttendanceDto
                                                  {
                                                      Id = a.Id,
                                                      VisitedDateTime = a.VisitedDateTime,
                                                      Temperature = a.Temperature,
                                                      AttendeeId = a.Attendee.Id,
                                                      AttendeeRFID = a.Attendee.AttendeeRFID,
                                                      AttendeeStatus = a.Attendee.Status,
                                                      Status = a.Status,
                                                      ContactNumber = a.Attendee.ContactNumber,
                                                      Name = a.Attendee.Name,
                                                      Age = a.Attendee.Age,
                                                      Address = a.Attendee.Address,
                                                      PlaceId = a.Place.Id,
                                                      Location = a.Place.Location

                                                  })
                                                  .AsEnumerable();

            switch (searchDto.SearchBy.ToUpper().Trim())
            {
                case "DATEANDTIME":
                    attendances = attendances.Where(a => a.VisitedDateTime.ToString().Contains(searchDto.SearchText));
                    break;
                case "TEMPERATURE":
                    attendances = attendances.Where(a => a.Temperature.ToString().Contains(searchDto.SearchText));
                    break;
                case "NAME":
                    attendances = attendances.Where(a => a.Name.ToString().Contains(searchDto.SearchText));
                    break;
                case "RFID":
                    attendances = attendances.Where(a => a.AttendeeRFID.ToString().Contains(searchDto.SearchText));
                    break;
                case "LOCATION":
                    attendances = attendances.Where(a => a.Location.ToString().Contains(searchDto.SearchText));
                    break;
                default:
                    break;

            }

            return Ok(attendances.ToList());
        }

        [HttpPost]
        [Route("GetAttendanceByDate")]
        public ActionResult GetAttendanceByDate([FromBody] SearchDto searchDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var attendances = _ahcmsContext.Attendances.Include(a => a.Attendee)
                                                  .Include(a => a.Place)
                                                  .Where(a => a.VisitedDateTime.Year == searchDto.Date.Value.Year &&
                                                              a.VisitedDateTime.Month == searchDto.Date.Value.Month &&
                                                              a.VisitedDateTime.Day == searchDto.Date.Value.Day)
                                                  .Select(a => new AttendanceDto
                                                  {
                                                      Id = a.Id,
                                                      VisitedDateTime = a.VisitedDateTime,
                                                      Temperature = a.Temperature,
                                                      AttendeeId = a.Attendee.Id,
                                                      AttendeeRFID = a.Attendee.AttendeeRFID,
                                                      AttendeeStatus = a.Attendee.Status,
                                                      Status = a.Status,
                                                      ContactNumber = a.Attendee.ContactNumber,
                                                      Name = a.Attendee.Name,
                                                      Age = a.Attendee.Age,
                                                      Address = a.Attendee.Address,
                                                      PlaceId = a.Place.Id,
                                                      Location = a.Place.Location

                                                  })
                                                  .AsEnumerable();

            return Ok(attendances.ToList());
        }
    }
}
