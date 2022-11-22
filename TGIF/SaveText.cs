using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace TGIF
{

    class SaveText
	{
		public SaveText(TaskManager taskManager)
		{

            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    bf.Serialize(myStream, taskManager.GetTaskList());
                    bf.Serialize(myStream, new SortedSet<String>(taskManager.GetTags()));
                    MessageBox.Show("정상적으로 저장되었습니다.");
                    myStream.Close();
                }

            }
            else
            {
                MessageBox.Show("저장 되지 않음");
            }
        }
	}
}
