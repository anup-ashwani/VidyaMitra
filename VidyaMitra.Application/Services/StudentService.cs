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
        public async Task<StudentDetailDto> GetStudentDetailAsync(int id = 0, string name = "")
        {

            var profileData = _mapper.Map<InitialDetailDto>(await _studentRepository.GetStudentProfileAsync(id, name));  
            var contact = _mapper.Map<ContactDetailDto>(await _studentRepository.GetStudentContactAsync(id));
            var econtact = _mapper.Map<EmeregenctContactDto>(await _studentRepository.GetStudentEmergencyContactAsync(id));
            var parent = _mapper.Map<ParentDetailDto>(await _studentRepository.GetStudentParentDetailsAsync(id));
            var notification = _mapper.Map<NotificationDto>(await _studentRepository.GetStudentNotificationAsync(id));

            return new StudentDetailDto
            {
                StudentProfile = profileData,
                ContactDetail = contact,
                EmeregenctContact = econtact,
                ParentDetail = parent,
                StudentNotification = notification,
            };
           
        }
    }
}
