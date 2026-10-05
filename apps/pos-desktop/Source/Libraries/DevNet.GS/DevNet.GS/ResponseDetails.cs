using System;

namespace DevNet.GS
{
	public class ResponseDetails
	{
		public string sts { get; set; }
		public string tradeNam { get; set; }
		public string lgnm { get; set; }
		public Address pradr { get; set; }
		public string dty { get; set; }
		public string ctb { get; set; }
		public string rgdt { get; set; }
		public string cxdt { get; set; }
		public string lstupdt { get; set; }

		public ResponseDetails()
		{
		}
	}
}
