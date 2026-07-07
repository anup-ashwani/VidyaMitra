using System;
using System.Collections.Generic;
using System.Text;
using VidyaMitra.Domain.Dto;
using VidyaMitra.Domain.Entities;

namespace VidyaMitra.Application.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDetailDto> GetStudentDetailAsync(int id = 0, string name = "");
    }
}
