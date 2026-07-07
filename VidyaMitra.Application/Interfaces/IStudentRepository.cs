using System;
using System.Collections.Generic;
using System.Text;
using VidyaMitra.Domain.Entities;

namespace VidyaMitra.Application.Interfaces
{
    public interface IStudentRepository
    {
        Task<StudentProfile> GetStudentProfileAsync(int id = 0, string name = "");
        Task<StudentContactDetail> GetStudentContactAsync(int id);
        Task<StudentEmeregencyContact> GetStudentEmergencyContactAsync(int id);
        Task<StudentParentDetail> GetStudentParentDetailsAsync(int id);
        Task<StudentNotification> GetStudentNotificationAsync(int id);
    }
}
