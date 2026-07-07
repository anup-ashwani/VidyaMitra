using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaMitra.Domain.Dto
{
    public class StudentDetailDto
    {
        public InitialDetailDto? StudentProfile { get; set; }
        public ContactDetailDto? ContactDetail { get; set; }
        public EmeregenctContactDto? EmeregenctContact { get; set; }
        public ParentDetailDto? ParentDetail { get; set; }
        public NotificationDto? StudentNotification { get; set; }
    }
}
