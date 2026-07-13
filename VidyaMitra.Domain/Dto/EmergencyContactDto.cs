using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaMitra.Domain.Dto
{
	public class EmergencyContactDto
	{
		public int EcontactId { get; set; }
		public string? PhoneNumber { get; set; }
		public string? EmailId { get; set; }
		public string? RelationShip { get; set; }
		public string? AddressLine { get; set; }
		public string? Country { get; set; }
		public string? State { get; set; }
		public string? City { get; set; }
		public string? PinCode { get; set; }
	}
}
