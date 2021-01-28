using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Inspect
{
	[StandardModule]
	internal sealed class Module1
	{
		[STAThread]
		public static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			bool flag = Information.UBound(Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName), 1) == 0;
			if (flag)
			{
				Application.Run(new Form1());
			}
		}
	}
}
