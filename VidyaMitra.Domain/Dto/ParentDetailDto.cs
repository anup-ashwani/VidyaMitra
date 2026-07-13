using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaMitra.Domain.Dto
{
    public class ParentDetailDto
    {
        public int ParentID { get; set; }
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public string? GuardianName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? AddressLine { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PinCode { get; set; }
    }
}
