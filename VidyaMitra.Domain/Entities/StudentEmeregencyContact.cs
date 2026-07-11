using System;
using System.Collections.Generic;

namespace VidyaMitra.Domain.Entities;

public partial class StudentEmeregencyContact
{
    public int EcontactId { get; set; }

    public int? ProfileId { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? RelationShip { get; set; }

    public string? AddressLine { get; set; }

    public string? Country { get; set; }

    public string? State { get; set; }

    public string? City { get; set; }

    public string? PinCode { get; set; }

    public virtual StudentProfile? Profile { get; set; }
}
