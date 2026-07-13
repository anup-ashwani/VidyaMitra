using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaMitra.Domain.Dto
{
    public class ProfileDetailDto
    {
        public PersonalInfoDto? PersonalInfo { get; set; }
        public ContactDetailDto? ContactDetail { get; set; }
        public EmergencyContactDto? EmergencyContact { get; set; }
        public ParentDetailDto? ParentDetail { get; set; }
        public NotificationDto? Notification { get; set; }
    }
}
