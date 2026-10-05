using System;

namespace DevNet.Models
{
	public class MessageRequest
	{
		public string Phone { get; set; }
		public string Message { get; set; }
		public string AttachmentPath { get; set; }

		public MessageRequest()
		{
		}
	}
}
