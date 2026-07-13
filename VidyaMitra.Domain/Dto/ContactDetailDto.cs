using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaMitra.Domain.Dto
{
	public class ContactDetailDto
	{
		public int ContactId { get; set; }
		public string? CountryCode { get; set; }
		public string? PhoneNumber { get; set; }
		public string? AlternatePhoneNumber { get; set; }
		public string? PrimaryEmailId { get; set; }
		public string? SecondaryEmailId { get; set; }
		public string? C_AddressLine { get; set; }
		public string? C_Country { get; set; }
		public string? C_State { get; set; }
		public string? C_City { get; set; }
		public string? C_PinCode { get; set; }
		public string? P_AddressLine1 { get; set; }
		public string? P_AddressLine2 { get; set; }
		public string? P_AddressLine3 { get; set; }
		public string? P_Country { get; set; }
		public string? P_State { get; set; }
		public string? P_City { get; set; }
		public string? P_PinCode { get; set; }
	}
}
