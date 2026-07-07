using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VidyaMitra.Application.Interfaces;
using VidyaMitra.Domain.Entities;
using VidyaMitra.Repository.Data;

namespace VidyaMitra.Repository.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly VidyaMitraDbContext _context;
        public StudentRepository(VidyaMitraDbContext context)
        {
            _context = context;
        }

        public async Task<StudentProfile> GetStudentProfileAsync(int id = 0, string name = "")
        {
            if (string.IsNullOrEmpty(name))
            {
                return await _context.StudentProfiles.Where(x=> x.Id == id).FirstOrDefaultAsync();
            }
            else
            {
                return await _context.StudentProfiles.Where(x => string.Equals(x.FirstName, name)).FirstOrDefaultAsync();
            }
        }

        public async Task<StudentContactDetail> GetStudentContactAsync(int id)
        {
            return await _context.StudentContactDetails.Where(x=> x.ProfileId == id).FirstOrDefaultAsync();
        }

        public async Task<StudentEmeregencyContact> GetStudentEmergencyContactAsync(int id)
        {
            return await _context.StudentEmeregencyContacts.Where(x => x.ProfileId == id).FirstOrDefaultAsync();
        }

        public async Task<StudentParentDetail> GetStudentParentDetailsAsync(int id)
        {
            return await _context.StudentParentDetails.Where(x => x.ProfileId == id).FirstOrDefaultAsync();
        }

        public async Task<StudentNotification> GetStudentNotificationAsync(int id)
        {
            return await _context.StudentNotifications.Where(x => x.ProfileId == id).FirstOrDefaultAsync();
        }



    }
}
