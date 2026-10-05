using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;
using DevNet.Models;

namespace DevNet.UI
{
	public class FrmBrowser : Form
	{
		public AuthenticationState AuthenticationState { get; set; }
		public ChromiumWebBrowser browser;

		public FrmBrowser()
		{
			AuthenticationState = AuthenticationState.Unknown;
		}

		public void Reload()
		{
		}

		public async Task<List<Transaction>> LastTransactions()
		{
			return await Task.FromResult(new List<Transaction>());
		}

		public async Task<string> MyUpiId()
		{
			return await Task.FromResult(string.Empty);
		}

		public async Task<string> MyPayeeName()
		{
			return await Task.FromResult(string.Empty);
		}
	}
}
