using System;
using System.Collections.Generic;
using System.Text;

namespace VidyaMitra.Domain.Dto
{
	public class NotificationDto
	{
		public int NotificationId { get; set; }
		public bool EmailAlert { get; set; }
		public bool SMSAlert { get; set; }
		public bool AssignmentsReminder { get; set; }
		public bool DuesReminder { get; set; }
		public bool PushNotification { get; set; }
		public bool WhatsAppAlert { get; set; }
	}
}
