using AutomatedHumanContactMonitorySystemApp.IRepositories;
using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using AutomatedHumanContactMonitorySystemApp.Models.Dtos;
using AutomatedHumanContactMonitorySystemApp.Models.Dtos.AttendanceDtos;
using AutomatedHumanContactMonitorySystemApp.Properties;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomatedHumanContactMonitorySystemApp.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly string ApiAddress = Settings.Default.ApiAddress;
        public List<AttendanceDto> GetAttendances()
        {
            var client = new RestClient(ApiAddress);
            var request = new RestRequest("api/attendance/");
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
            var attendances = JsonConvert.DeserializeObject<List<AttendanceDto>>(response.Content);
            return attendances.ToList();
        }

        public void PostAttendance(Attendance attendance)
        {
            var client = new RestClient(ApiAddress);
            var request = new RestRequest("api/attendance/", Method.POST);
            request.AddJsonBody(attendance);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
        }

        public void DeleteAttendance(int id)
        {
            var client = new RestClient(ApiAddress);
            var request = new RestRequest("api/attendance/" + id, Method.DELETE);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute(request);
        }

        public void UpdateAttendanceStatus(Attendance attendance)
        {
            var client = new RestClient(ApiAddress);
            var request = new RestRequest("api/attendance/UpdateAttendanceStatus/", Method.POST);
            request.AddJsonBody(attendance);
            var response = client.Execute(request);
        }

        public List<AttendanceDto> GetAttendanceBySearchParameter(SearchDto searchDto)
        {
            var client = new RestClient(ApiAddress);
            var request = new RestRequest("api/attendance/GetAttendanceBySearchParameter/", Method.POST);
            request.AddJsonBody(searchDto);
            var response = client.Execute(request);
            var attendances = JsonConvert.DeserializeObject<List<AttendanceDto>>(response.Content);
            return attendances.ToList();
        }

        public List<AttendanceDto> GetAttendanceByDate(SearchDto searchDto)
        {
            var client = new RestClient(ApiAddress);
            var request = new RestRequest("api/attendance/GetAttendanceByDate/", Method.POST);
            request.AddJsonBody(searchDto);
            var response = client.Execute(request);
            var attendances = JsonConvert.DeserializeObject<List<AttendanceDto>>(response.Content);
            return attendances.ToList();
        }


    }
}
