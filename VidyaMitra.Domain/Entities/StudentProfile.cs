using System;
using System.Collections.Generic;

namespace VidyaMitra.Domain.Entities;

public partial class StudentProfile
{
    public int ProfileId { get; set; }

    public string? EnrollmentNumber { get; set; }

    public string Title { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Nationality { get; set; } = null!;

    public string? Religion { get; set; }

    public string? AadharNumber { get; set; }

    public string? BloodGroup { get; set; }

    public byte[]? ProfilePicture { get; set; }

    public byte[]? DigitalSignature { get; set; }

    public string? LinkedInId { get; set; }

    public string? GitHubId { get; set; }

    public string LoginEmail { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public virtual ICollection<StudentContactDetail> StudentContactDetails { get; set; } = new List<StudentContactDetail>();

    public virtual ICollection<StudentEmeregencyContact> StudentEmeregencyContacts { get; set; } = new List<StudentEmeregencyContact>();

    public virtual ICollection<StudentNotification> StudentNotifications { get; set; } = new List<StudentNotification>();

    public virtual ICollection<StudentParentDetail> StudentParentDetails { get; set; } = new List<StudentParentDetail>();
}
