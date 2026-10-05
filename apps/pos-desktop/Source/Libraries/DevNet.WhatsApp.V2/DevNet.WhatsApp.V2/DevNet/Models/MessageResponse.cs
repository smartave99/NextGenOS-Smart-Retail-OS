using System;

namespace DevNet.Models
{
	public class MessageResponse
	{
		public string Phone { get; set; }
		public string Message { get; set; }
		public string AttachmentPath { get; set; }
		public DateTime TimeStamp { get; set; }
		public Status Status { get; set; }

		public MessageResponse()
		{
			Status = Status.Success;
			TimeStamp = DateTime.Now;
		}
	}
}
