using System;
using System.Windows;

namespace TGIF
{
	[Serializable]
	class UrlProcess : Directory
	{
		public string Name { get; set; }
		public string Entity { get; set; }

		public void Run()
		{
			try
			{
				System.Diagnostics.Process.Start(Entity);
			}
			catch (System.ComponentModel.Win32Exception)
			{
				MessageBox.Show("잘못된 URL 입니다.\n{0}",Entity);
			}
		}
	}
}
