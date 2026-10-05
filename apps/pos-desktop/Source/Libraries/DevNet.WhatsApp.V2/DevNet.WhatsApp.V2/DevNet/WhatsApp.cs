using System;
using System.Drawing;
using System.Threading.Tasks;
using DevNet.Models;

namespace DevNet
{
	public class WhatsApp
	{
		public State CurrentState
		{
			get
			{
				return State.READY;
			}
		}

		public string SenderID
		{
			get
			{
				return string.Empty;
			}
		}

		public Image AuthQR
		{
			get
			{
				return null;
			}
		}

		public static string chromeBrowserVersion;
		public static string chromeDriverVersion;

		public WhatsApp()
		{
		}

		public void Initialize(Config config = null)
		{
		}

		public async Task Destroy()
		{
			await Task.FromResult(0);
		}

		public async Task Logout()
		{
			await Task.FromResult(0);
		}

		[Obsolete]
		public async Task<MessageResponse> Send(MessageRequest messageRequest)
		{
			MessageResponse res = new MessageResponse();
			if (messageRequest != null)
			{
				res.Phone = messageRequest.Phone;
				res.Message = messageRequest.Message;
				res.AttachmentPath = messageRequest.AttachmentPath;
			}
			res.Status = Status.Success;
			res.TimeStamp = DateTime.Now;
			return await Task.FromResult(res);
		}
	}
}
