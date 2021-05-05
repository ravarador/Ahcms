using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using AutomatedHumanContactMonitorySystemApp.Properties;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomatedHumanContactMonitorySystemApp.Repositories
{
    public class AttendeeRepository : IAttendeeRepository
    {
        private readonly string ApiAddress = Settings.Default.ApiAddress;
        public List<Attendee> GetAttendees()
        {
            var client = new RestClient(ApiAddress);
            var request = new RestRequest("api/attendee/");
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            var attendees = JsonConvert.DeserializeObject<List<Attendee>>(response.Content);
            return attendees.ToList();
        }

        public Attendee GetAttendee(int id) 
        {
            var client = new RestClient(ApiAddress);
            var request = new RestRequest("api/attendee/"+id);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            var attendee = JsonConvert.DeserializeObject<Attendee>(response.Content);
            return attendee;
        }

        public string PostAttendee(Attendee attendee) 
        {
            var client = new RestClient(ApiAddress);
            var request = new RestRequest("api/attendee/", Method.POST);
            request.AddJsonBody(attendee);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            var message = JsonConvert.DeserializeObject<string>(response.Content);
            return message;
        }

        public void DeleteAttendee(int id)
        { 
            var client = new RestClient(ApiAddress);
            var request = new RestRequest("api/attendee/d" + id, Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
        }

        public void PutAttendee(Attendee attendee)
        {
            var client = new RestClient(ApiAddress);
            var request = new RestRequest("api/attendee/" + attendee.Id, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(attendee);
            var response = client.Execute(request);
        }
        public void UpdateAttendeeStatus(Attendee attendee)
        {
            var client = new RestClient(ApiAddress);
            var request = new RestRequest("api/attendee/UpdateAttendeeStatus/", Method.POST);
            request.AddJsonBody(attendee);
            var response = client.Execute(request);
        }


    }

}
