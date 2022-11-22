using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace TGIF
{
	class OpenText
	{
		public OpenText(TaskManager taskManager)
		{
			Stream mystream;

			OpenFileDialog openFileDialog = new OpenFileDialog();

			openFileDialog.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
			openFileDialog.FilterIndex = 2;
			openFileDialog.RestoreDirectory = true;


			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				if ((mystream = openFileDialog.OpenFile()) != null)
				{
					BinaryFormatter bf = new BinaryFormatter();

					taskManager.SetTaskList((List<Task>)bf.Deserialize(mystream));
					taskManager.SetTags((SortedSet<String>)bf.Deserialize(mystream));
					mystream.Close();
				}
			}

		}

	}
}
