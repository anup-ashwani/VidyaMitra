using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VidyaMitra.Application.Interfaces;
using VidyaMitra.Domain.Dto;
using VidyaMitra.Domain.Entities;
using VidyaMitra.Repository.Data;

namespace VidyaMitra.Repository.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly VidyaMitraDbContext _context;
        private readonly ResponseDto _response;
        private readonly IMapper _mapper;

        public StudentRepository(VidyaMitraDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _response = new ResponseDto { IsSuccess = true };
        }

        #region For fetching the data
        public async Task<StudentProfile> GetStudentProfileAsync(string email = "")
        {
            return await _context.StudentProfiles.Where(x => string.Equals(x.LoginEmail, email)).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<StudentContactDetail> GetStudentContactAsync(int id)
        {
            return await _context.StudentContactDetails.Where(x=> x.ProfileId == id).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<StudentEmeregencyContact> GetStudentEmergencyContactAsync(int id)
        {
            return await _context.StudentEmeregencyContacts.Where(x => x.ProfileId == id).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<StudentParentDetail> GetStudentParentDetailsAsync(int id)
        {
            return await _context.StudentParentDetails.Where(x => x.ProfileId == id).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<StudentNotification> GetStudentNotificationAsync(int id)
        {
            return await _context.StudentNotifications.Where(x => x.ProfileId == id).FirstOrDefaultAsync();
        }

        #endregion

        #region For saving the data

        public async Task<ResponseDto> SaveStudentProfileAsync(ProfileDetailDto profile)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var studentProfile = _mapper.Map<StudentProfile>(profile.PersonalInfo);
                _context.StudentProfiles.Add(studentProfile);
                await _context.SaveChangesAsync();

                var contact = _mapper.Map<StudentContactDetail>(profile.ContactDetail);
                contact.ProfileId = studentProfile.ProfileId;
                _context.StudentContactDetails.Add(contact);

                var econtact = _mapper.Map<StudentEmeregencyContact>(profile.EmergencyContact);
                econtact.ProfileId = studentProfile.ProfileId;
                _context.StudentEmeregencyContacts.Add(econtact);

                var parent = _mapper.Map<StudentParentDetail>(profile.ParentDetail);
                parent.ProfileId = studentProfile.ProfileId;
                _context.StudentParentDetails.Add(parent);

                var notification = _mapper.Map<StudentNotification>(profile.Notification);
                notification.ProfileId = studentProfile.ProfileId;
                _context.StudentNotifications.Add(notification);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                _response.Message = "Student registered successfully.";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        #endregion

        #region private methods

        #endregion

    }
}
