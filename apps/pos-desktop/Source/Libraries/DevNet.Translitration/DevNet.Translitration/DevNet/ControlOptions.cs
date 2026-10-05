using System;
using System.Drawing;
using System.Windows.Forms;

namespace DevNet
{
	public class ControlOptions : UserControl
	{
		public string[] Options { get; set; }
		public Action<string> OptionAction { get; set; }

		private FlowLayoutPanel panel;

		public ControlOptions(string[] options, Action<string> optionAction)
		{
			Options = options;
			OptionAction = optionAction;
			panel = new FlowLayoutPanel { Dock = DockStyle.Fill, AutoScroll = true };
			if (options != null)
			{
				foreach (var opt in options)
				{
					panel.Controls.Add(new ControlOption(opt, optionAction));
				}
			}
			Controls.Add(panel);
		}
	}
}
