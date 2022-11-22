using System;

namespace TGIF
{
	[Serializable]
	class FileProcess : Directory
	{
		public string Name { get; set; }
		public string Entity { get; set; }

		public void Run()
		{
			try
			{
				System.Diagnostics.Process.Start(Entity);
			}
			catch(System.ComponentModel.Win32Exception e)
			{
				System.Windows.MessageBox.Show(e.Message + '\n'+Entity);
			}
		}
	}
}
