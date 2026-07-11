using System;
using System.Collections.Generic;
using System.Text;
using VidyaMitra.Domain.Dto;
using VidyaMitra.Domain.Entities;

namespace VidyaMitra.Application.Interfaces
{
    public interface IStudentService
    {
        Task<ProfileDetailDto> GetStudentDetailAsync(string email);

        Task<ResponseDto> SaveStudentDetail(ProfileDetailDto profile);
    }
}
