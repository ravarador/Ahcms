using AutomatedHumanContactMonitorySystemApp.Models.ContextModels;
using AutomatedHumanContactMonitorySystemApp.Models.Dtos;
using AutomatedHumanContactMonitorySystemApp.Models.Dtos.AttendanceDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomatedHumanContactMonitorySystemApp.IRepositories
{
    public interface IAttendanceRepository
    {
        List<AttendanceDto> GetAttendances();
        void PostAttendance(Attendance attendance);
        void DeleteAttendance(int id);
        void UpdateAttendanceStatus(Attendance attendance);
        List<AttendanceDto> GetAttendanceBySearchParameter(SearchDto searchDto);
        List<AttendanceDto> GetAttendanceByDate(SearchDto searchDto);
    }
}
