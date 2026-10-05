using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using DevNet.Models;
using DevNet.UI;

namespace DevNet.PhonePe
{
	public class PhonePe
	{
		public static PhonePe Instance = new PhonePe();
		public FrmBrowser frmBrowser;
		public bool _Cancel { get; set; }

		public PhonePe()
		{
		}

		public void Init()
		{
		}

		public async Task<Bitmap> Checkout(string orderId, double amount, Action<Transaction> onSuccess, Action onFail)
		{
			return await Task.FromResult<Bitmap>(null);
		}

		public async Task<List<Transaction>> LastTransactions()
		{
			return await Task.FromResult(new List<Transaction>());
		}

		public async Task<string> MyUPIId()
		{
			return await Task.FromResult(string.Empty);
		}

		public async Task<string> MyPayeeName()
		{
			return await Task.FromResult(string.Empty);
		}
	}
}
