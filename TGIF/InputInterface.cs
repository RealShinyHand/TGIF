using System;
using System.Collections.Generic;

namespace TGIF
{
	[Flags]
	enum ImportantRate
	{
		non = 0,low = 1,middle = 2,high = 4
	}

	class InputInterface : System.Windows.Forms.Form
	{
		Task task;
		TaskManager taskManager;
		List<UrlProcess> urls = new List<UrlProcess>() ;
		List<FileProcess> files = new List<FileProcess>();
		MainForm mainForm;
		TwoInfoInput form;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.ComboBox ComboBox_Tag;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.Button Button_FileAdd;
		private System.Windows.Forms.Button Button_Complete;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Button Button_UrlAdd;

		public InputInterface(TaskManager taskManager,MainForm form)
		{
			this.taskManager = taskManager;
			mainForm = form;
			InitializeComponent();

			this.ComboBox_Tag.Items.AddRange(taskManager.GetTags());
		}

		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.ComboBox_Tag = new System.Windows.Forms.ComboBox();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.Button_FileAdd = new System.Windows.Forms.Button();
			this.Button_UrlAdd = new System.Windows.Forms.Button();
			this.Button_Complete = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label1.Location = new System.Drawing.Point(1, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 21);
			this.label1.TabIndex = 0;
			this.label1.Text = "이름 ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label2.Location = new System.Drawing.Point(3, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 21);
			this.label2.TabIndex = 1;
			this.label2.Text = "중요도";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label3.Location = new System.Drawing.Point(3, 76);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 21);
			this.label3.TabIndex = 2;
			this.label3.Text = "Tag";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label4.Location = new System.Drawing.Point(3, 118);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 21);
			this.label4.TabIndex = 3;
			this.label4.Text = "시작일";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label5.Location = new System.Drawing.Point(3, 164);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(58, 21);
			this.label5.TabIndex = 4;
			this.label5.Text = "마감일";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label6.Location = new System.Drawing.Point(3, 293);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(80, 21);
			this.label6.TabIndex = 5;
			this.label6.Text = "연관 파일";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label7.Location = new System.Drawing.Point(3, 349);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(78, 21);
			this.label7.TabIndex = 6;
			this.label7.Text = "연관 URL";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(56, 4);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(322, 21);
			this.textBox1.TabIndex = 7;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(93, 43);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(35, 16);
			this.radioButton1.TabIndex = 8;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "상";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(192, 43);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(35, 16);
			this.radioButton2.TabIndex = 9;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "중";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(291, 39);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(35, 16);
			this.radioButton3.TabIndex = 10;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "하";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// ComboBox_Tag
			// 
			this.ComboBox_Tag.FormattingEnabled = true;
			this.ComboBox_Tag.Location = new System.Drawing.Point(93, 76);
			this.ComboBox_Tag.Name = "ComboBox_Tag";
			this.ComboBox_Tag.Size = new System.Drawing.Size(121, 20);
			this.ComboBox_Tag.TabIndex = 11;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(93, 117);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.ShowUpDown = true;
			this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
			this.dateTimePicker1.TabIndex = 12;
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.Location = new System.Drawing.Point(93, 163);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.ShowUpDown = true;
			this.dateTimePicker2.Size = new System.Drawing.Size(200, 21);
			this.dateTimePicker2.TabIndex = 13;
			// 
			// Button_FileAdd
			// 
			this.Button_FileAdd.Location = new System.Drawing.Point(93, 291);
			this.Button_FileAdd.Name = "Button_FileAdd";
			this.Button_FileAdd.Size = new System.Drawing.Size(75, 23);
			this.Button_FileAdd.TabIndex = 14;
			this.Button_FileAdd.Text = "파일 추가";
			this.Button_FileAdd.UseVisualStyleBackColor = true;
			this.Button_FileAdd.Click += new System.EventHandler(this.button1_Click);
			// 
			// Button_UrlAdd
			// 
			this.Button_UrlAdd.Location = new System.Drawing.Point(93, 346);
			this.Button_UrlAdd.Name = "Button_UrlAdd";
			this.Button_UrlAdd.Size = new System.Drawing.Size(75, 23);
			this.Button_UrlAdd.TabIndex = 15;
			this.Button_UrlAdd.Text = "URL 추가";
			this.Button_UrlAdd.UseVisualStyleBackColor = true;
			this.Button_UrlAdd.Click += new System.EventHandler(this.button2_Click);
			// 
			// Button_Complete
			// 
			this.Button_Complete.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.Button_Complete.Location = new System.Drawing.Point(0, 417);
			this.Button_Complete.Name = "Button_Complete";
			this.Button_Complete.Size = new System.Drawing.Size(402, 23);
			this.Button_Complete.TabIndex = 16;
			this.Button_Complete.Text = "완료";
			this.Button_Complete.UseVisualStyleBackColor = true;
			this.Button_Complete.Click += new System.EventHandler(this.button3_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label8.Location = new System.Drawing.Point(7, 197);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(42, 21);
			this.label8.TabIndex = 17;
			this.label8.Text = "주석";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(13, 222);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(377, 63);
			this.richTextBox1.TabIndex = 18;
			this.richTextBox1.Text = "";
			// 
			// InputInterface
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(402, 440);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.Button_Complete);
			this.Controls.Add(this.Button_UrlAdd);
			this.Controls.Add(this.Button_FileAdd);
			this.Controls.Add(this.dateTimePicker2);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.ComboBox_Tag);
			this.Controls.Add(this.radioButton3);
			this.Controls.Add(this.radioButton2);
			this.Controls.Add(this.radioButton1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "InputInterface";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		public void ModifySetting(Task task)
		{
			textBox1.Text = task.Name;
			ComboBox_Tag.Text = task.Tag;
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
			}

			dateTimePicker1.Value = task.StartDate;
			dateTimePicker2.Value = task.DeadLine;
			richTextBox1.Text = task.Txt;
			urls = task.RelateURL;
			files = task.RelateFile;
		}

		public void AddFile(Directory temp)
		{
			files.Add((FileProcess)temp);
		}

		public void AddURL(Directory temp)
		{
			urls.Add((UrlProcess)temp);
		}

		public  void SetTask()
		{

			task = new Task(textBox1.Text, (int)getImportantRate(),ComboBox_Tag.Text ,dateTimePicker1.Value, dateTimePicker2.Value, richTextBox1.Text,files,urls);

		}
		public Task GetTask()
		{
			return task;
		}

		private ImportantRate getImportantRate() 
		{
			if (radioButton1.Checked)
			{
				return ImportantRate.high;
			}else if (radioButton2.Checked)
			{
				return ImportantRate.middle;
			}
			else
			{
				return ImportantRate.low;
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			SetTask(); //사용자 입력값을 이용한 Task 인스턴스 생성
			if (task.CheckTaskFormat()) //이름하고 마감일 빼먹었는지 검사
			{
				List<Task> tasks = taskManager.GetTaskList(); 

				taskManager.EnrollTask(task);		//생성된 Task 등록

				mainForm.ClearPanelTaskList();		//task 리스트 나타내는 폼을 클리어 후 새로운 리스트 형태로 추가
			
				foreach (Task task in tasks)
				{
					
					mainForm.AddPanelTaskList(new TaskButton(task, mainForm));
				}

				if(!taskManager.AddTag(this.ComboBox_Tag.Text)) // 기존에 없는 태그라면 자동 추가
				mainForm.TagComboBoxSetting();

				this.Close();
			}
			else
			{
				System.Windows.MessageBox.Show("입력 값 오류, 이름과 마감일을 정해주세요");
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			form = new TwoInfoInput(this, new FileProcess());  //파일 추가를 눌렸을 경우
			form.Show();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			form = new TwoInfoInput(this, new UrlProcess());  //URL 추가 눌렀을 경우
			form.Show();
		}


	}
}

