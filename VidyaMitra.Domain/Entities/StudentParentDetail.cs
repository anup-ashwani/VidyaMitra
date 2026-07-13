using System;
using System.Collections.Generic;

namespace VidyaMitra.Domain.Entities;

public partial class StudentParentDetail
{
    public int ParentId { get; set; }

    public int? ProfileId { get; set; }

    public string FatherName { get; set; } = null!;

    public string MotherName { get; set; } = null!;

    public string? GuardianName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string AddressLine { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string? City { get; set; }

    public string? State { get; set; }

    public string? PinCode { get; set; }

    public virtual StudentProfile? Profile { get; set; }
}
