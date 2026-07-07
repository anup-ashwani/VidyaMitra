using System;
using System.Collections.Generic;

namespace VidyaMitra.Domain.Entities;

public partial class StudentNotification
{
    public int Id { get; set; }

    public int? ProfileId { get; set; }

    public bool? EmailAlert { get; set; }

    public bool? Smsalert { get; set; }

    public bool? AssignmentsReminder { get; set; }

    public bool? DuesReminder { get; set; }

    public bool? PushNotification { get; set; }

    public bool? WhatsAppAlert { get; set; }
}
