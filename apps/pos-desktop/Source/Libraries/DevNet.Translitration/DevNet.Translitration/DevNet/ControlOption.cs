using System;
using System.Drawing;
using System.Windows.Forms;

namespace DevNet
{
	public class ControlOption : UserControl
	{
		public string Option { get; set; }
		public Action<string> OptionAction { get; set; }

		private Label lbl;

		public ControlOption(string option, Action<string> optionAction)
		{
			Option = option;
			OptionAction = optionAction;
			lbl = new Label();
			lbl.Text = option;
			lbl.AutoSize = true;
			lbl.Dock = DockStyle.Fill;
			lbl.Click += (s, e) =>
			{
				if (OptionAction != null)
				{
					OptionAction(Option);
				}
			};
			Controls.Add(lbl);
		}
	}
}
