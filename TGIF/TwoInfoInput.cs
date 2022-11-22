using System;

namespace TGIF
{
	class TwoInfoInput : System.Windows.Forms.Form
	{

		Directory temp ;
		InputInterface form;

		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button Button_Complete;
		private System.Windows.Forms.Label label1;

		public TwoInfoInput(InputInterface form, Directory temp)
		{
			this.form = form;
			this.temp = temp;
			InitializeComponent();
		}

		public Directory GetInfo()
		{
			temp.Name = textBox1.Text;
			temp.Entity = textBox2.Text;
			return temp;
		}

		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.Button_Complete = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(159, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "사용자 지정 이름";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.label2.Location = new System.Drawing.Point(72, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(95, 25);
			this.label2.TabIndex = 1;
			this.label2.Text = "실제 내용";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(173, 11);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(585, 21);
			this.textBox1.TabIndex = 2;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(174, 53);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(584, 21);
			this.textBox2.TabIndex = 3;
			// 
			// Button_Complete
			// 
			this.Button_Complete.Location = new System.Drawing.Point(648, 96);
			this.Button_Complete.Name = "Button_Complete";
			this.Button_Complete.Size = new System.Drawing.Size(110, 25);
			this.Button_Complete.TabIndex = 4;
			this.Button_Complete.Text = "완료";
			this.Button_Complete.UseVisualStyleBackColor = true;
			this.Button_Complete.Click += new System.EventHandler(this.button1_Click);
			// 
			// TwoInfoInput
			// 
			this.ClientSize = new System.Drawing.Size(784, 133);
			this.Controls.Add(this.Button_Complete);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "TwoInfoInput";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (temp is UrlProcess)
			{
				temp = (UrlProcess)temp;
				form.AddURL(GetInfo());
			}
			else if(temp is FileProcess)
			{
				temp = (FileProcess)temp;
				form.AddFile(GetInfo());
			}
			this.Close();
		}
	}
}
