using System;
using System.Collections.Generic;

namespace VidyaMitra.Domain.Entities;

public partial class StudentContactDetail
{
    public int ContactId { get; set; }

    public int? ProfileId { get; set; }

    public string? CountryCode { get; set; }

    public string? PhoneNumber { get; set; }

    public string? AlternatePhoneNumber { get; set; }

    public string? PrimaryEmailId { get; set; }

    public string? SecondaryEmailId { get; set; }

    public string? CAddressLine { get; set; }

    public string? CCountry { get; set; }

    public string? CState { get; set; }

    public string? CCity { get; set; }

    public string? CPinCode { get; set; }

    public string? PAddressLine1 { get; set; }

    public string? PAddressLine2 { get; set; }

    public string? PAddressLine3 { get; set; }

    public string? PCountry { get; set; }

    public string? PState { get; set; }

    public string? PCity { get; set; }

    public string? PPinCode { get; set; }
}
