using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VidyaMitra.Application.Interfaces;
using VidyaMitra.Domain.Dto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VidyaMitra.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task<ProfileDetailDto> GetStudentDetailAsync(string email = "")
        {
            var profileData = _mapper.Map<PersonalInfoDto>(await _studentRepository.GetStudentProfileAsync(email));
            int studentId =  profileData != null ? profileData.ProfileId : 0;
            var contact = _mapper.Map<ContactDetailDto>(await _studentRepository.GetStudentContactAsync(studentId));
            var econtact = _mapper.Map<EmergencyContactDto>(await _studentRepository.GetStudentEmergencyContactAsync(studentId));
            var parent = _mapper.Map<ParentDetailDto>(await _studentRepository.GetStudentParentDetailsAsync(studentId));
            var notification = _mapper.Map<NotificationDto>(await _studentRepository.GetStudentNotificationAsync(studentId));

            return new ProfileDetailDto
            {
                PersonalInfo = profileData,
                ContactDetail = contact,
                EmergencyContact = econtact,
                ParentDetail = parent,
                Notification = notification,
            };
           
        }

        public async Task<ResponseDto> SaveStudentDetail(ProfileDetailDto profile)
        {
            return await _studentRepository.SaveStudentProfileAsync(profile);
        }
    }
}
