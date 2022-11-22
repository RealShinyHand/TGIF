using System.Windows.Forms;

namespace TGIF
{
	class DirectoryButton : System.Windows.Forms.Button
	{
		Directory directory;

		public DirectoryButton(Directory directory)
		{
			this.directory = directory;
			this.Text = directory.Name;
			this.MouseUp += ClickEvent;

		}
		private void ClickEvent(object obj, MouseEventArgs e)
		{


		
			if (e.Button == MouseButtons.Left)
			{
				directory.Run();
			}
			else if (e.Button == MouseButtons.Right)
			{
				if (MessageBox.Show($"{directory.Name} : {directory.Entity}\n삭제하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					if (directory is FileProcess)
						MainForm.selectedTask.RelateFile.Remove((FileProcess)directory);
					else
						MainForm.selectedTask.RelateURL.Remove((UrlProcess)directory);
					this.Hide();
				}
			}
		}
	}
}
