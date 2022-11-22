using System.Drawing;
using System.Windows.Forms;

namespace TGIF
{
	partial class MainForm : Form
	{
		public static TaskManager taskManager;
		public static Task selectedTask;
		InputInterface inputForm;

		public MainForm()
		{
			taskManager = new TaskManager();
			InitializeComponent();

		}

		public void SetSelectedTask(Task task) // 커스텀한 taskButton 컨트롤스에서 실행함.. 
											   //해당 컨트롤은 이 객체를 참조하고 있다.
											   // 선택된 버튼에 맞게  우측 인터페이스에 해당 과제 정보를 출력함
		{
			selectedTask = task;
			label1.Text = task.Name;
			switch ((ImportantRate)task.ImportantRate)
			{
				case ImportantRate.high:
					radioButton1.Checked = true;
					break;
				case ImportantRate.middle:
					radioButton2.Checked = true;
					break;

				case ImportantRate.low:
					radioButton3.Checked = true;
					break;
				default:
					MessageBox.Show("심각한 오류");
					break;
			}
			label3.Text = task.Tag;
			dateTimePicker1.Value = task.StartDate;
			dateTimePicker2.Value = task.DeadLine;
			richTextBox1.Text = task.Txt;

			System.Collections.Generic.List<FileProcess> fp = task.RelateFile;
			System.Collections.Generic.List<UrlProcess> up = task.RelateURL;


			splitContainer4.Panel2.Controls.Clear();

			int i;
			for (i = 0; i < fp.Count; i++)
			{
				splitContainer4.Panel2.Controls.Add(new DirectoryButton(fp[i]));
			}

			splitContainer5.Panel2.Controls.Clear();
			for (i = 0; i < up.Count; i++)
			{
				splitContainer5.Panel2.Controls.Add(new DirectoryButton(up[i]));
			}
		}

		public void ClearPanelTaskList()
		{
			panel_taskList.Controls.Clear();
		}

		public void AddPanelTaskList(TaskButton button)
		{
			panel_taskList.Controls.Add(button);

			Label label = new Label();
			label.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			label.ForeColor = Color.Black;
			label.Anchor = AnchorStyles.Left;

			System.DateTime now = System.DateTime.Now;

			int leaveDate = (button.GetDeadLine() - now).Days;
			int leaveHours = (button.GetDeadLine() - now).Hours;

			label.Text = $"{leaveDate}d - {leaveHours}h";
			panel_taskList.Controls.Add(label);
		}

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{

		}

		private void button3_Click(object sender, System.EventArgs e)
		{

		}

		private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button9_Click(object sender, System.EventArgs e)
		{

		}


		private void AddButton_Click(object sender, System.EventArgs e) //과제 추가 버튼 눌렀을 경우
		{
			inputForm = new InputInterface(taskManager, this); //입력창을 먼저 제공
			inputForm.Show();
		}

		private void button5_Click(object sender, System.EventArgs e)  //존재하는 과제 선택 후 삭제 클릭시
		{
			if (selectedTask == null)
			{
				MessageBox.Show("이미 삭제된 개체 입니다.");
				return;
			}

			taskManager.DeleteTask(selectedTask);

			System.Collections.Generic.List<Task> tasks = taskManager.GetTaskList();


			this.ClearPanelTaskList();
			foreach (Task task in tasks)
			{
				this.AddPanelTaskList(new TaskButton(task, this));
			}
			selectedTask = null;

		}

		private void label9_Click(object sender, System.EventArgs e)
		{

		}

		private void button3_Click_1(object sender, System.EventArgs e)
		{

		}

		public void TagComboBoxSetting()
		{
			comboBox1.Items.Clear();
			comboBox2.Items.Clear();

			this.comboBox1.Items.AddRange(taskManager.GetTags());
			this.comboBox2.Items.AddRange(taskManager.GetTags());
		}

		private void OpenToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			try
			{
				taskManager.Open();
				ClearPanelTaskList();
				foreach (Task task in taskManager.GetTaskList())
				{
					this.AddPanelTaskList(new TaskButton(task, this));
				}
				TagComboBoxSetting();

			}
			catch (System.Exception error)
			{
				MessageBox.Show(error.Message);
				MessageBox.Show("열기 실패.");
			}

		}

		private void SaveToolStripMenuItem_Click(object sender, System.EventArgs e)
		{

			taskManager.Save();

			
		}

		private void Button_Modify_Click(object sender, System.EventArgs e)
		{
			if (selectedTask != null)
			{
				inputForm = new InputInterface(taskManager, this);

				inputForm.ModifySetting(selectedTask);
				inputForm.Show();
				taskManager.DeleteTask(selectedTask);
			}


		}

		private ImportantRate getImportantRate()
		{
			if (radioButton1.Checked)
			{
				return ImportantRate.high;
			}
			else if (radioButton2.Checked)
			{
				return ImportantRate.middle;
			}
			else
			{
				return ImportantRate.low;
			}
		}

		private void button6_Filter(object sender, System.EventArgs e)
		{
			ImportantRate rate = ImportantRate.non;
			string name = textBox1.Text;
			string tag = comboBox2.Text;

			if (checkBox1.Checked)
			{
				rate |= ImportantRate.high;
			}
			if (checkBox2.Checked)
			{
				rate |= ImportantRate.middle;
			}
			if (checkBox3.Checked)
			{
				rate |= ImportantRate.low;
			}



			this.ClearPanelTaskList();
			foreach (Task task in taskManager.GetFilteredTaskList(name, rate, tag))
			{
				this.AddPanelTaskList(new TaskButton(task, this));
			}
			selectedTask = null;
		}

		private void 끝내기ToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
