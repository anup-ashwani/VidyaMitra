using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaMitra.Domain.Dto
{
	public class InitialDetailDto
	{
		public int Id { get; set; }
		public string? EnrollmentNumber { get; set; }
		public string? Title { get; set; }
		public string? FirstName { get; set; }
		public string? MiddleName { get; set; }
		public string? LastName { get; set; }
		public DateOnly? DateOfBirth { get; set; }
		public string? Nationality { get; set; }
		public string? Religion { get; set; }
		public string? AadhaarNumber { get; set; }
		public string? BloodGroup { get; set; }
		public byte[]? ProfilePicture { get; set; }
		public byte[]? DigitalSignature { get; set; }
		public string? LinkedInId { get; set; }
		public string? GitHubId { get; set; }



	}
}
