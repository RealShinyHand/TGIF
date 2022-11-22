using System;

namespace TGIF
{
	class TaskButton : System.Windows.Forms.Button
	{
		Task task;
		MainForm mainForm;

		public TaskButton(Task task,MainForm mainForm)
		{
			this.mainForm = mainForm;
			this.task = task;
			this.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.ForeColor = System.Drawing.Color.Black;
			this.Text = task.Name;
			this.Size = new System.Drawing.Size(600, 40);

			this.Click += taskButton_Click;
		}

		private void taskButton_Click(Object sender,EventArgs e)
		{
			
			MainForm.selectedTask = task;
			mainForm.SetSelectedTask(task);
		}

		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// TaskButton
			// 
			this.AllowDrop = true;
			this.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ResumeLayout(false);

		}
		public DateTime GetDeadLine()
		{
			return task.DeadLine;
		}
	}
}
