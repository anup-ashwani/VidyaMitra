using System;
using System.Collections.Generic;
using System.Text;
using VidyaMitra.Domain.Dto;
using VidyaMitra.Domain.Entities;

namespace VidyaMitra.Application.Interfaces
{
    public interface IStudentRepository
    {
        #region For fetching the data
        Task<StudentProfile> GetStudentProfileAsync(string email = "");
        Task<StudentContactDetail> GetStudentContactAsync(int id);
        Task<StudentEmeregencyContact> GetStudentEmergencyContactAsync(int id);
        Task<StudentParentDetail> GetStudentParentDetailsAsync(int id);
        Task<StudentNotification> GetStudentNotificationAsync(int id);
        #endregion

        #region For saving the data
        Task<ResponseDto> SaveStudentProfileAsync(ProfileDetailDto profile);
        #endregion
    }
}
