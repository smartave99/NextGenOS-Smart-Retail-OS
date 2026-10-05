using System;

namespace DevNet.Models
{
	public class Transaction
	{
		public DateTime timestamp { get; set; }
		public string txnId { get; set; }
		public string status { get; set; }
		public string amount { get; set; }

		public Transaction()
		{
		}
	}
}
