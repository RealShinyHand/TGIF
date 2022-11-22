using System;
using System.Collections.Generic;

namespace TGIF
{
	[Serializable]
	class Task
	{
		public String Name { get; set; }
		public int ImportantRate { get; set; }
		public String Tag { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime DeadLine { get; set; }
		public String Txt { get; set; }


		public List<FileProcess> RelateFile
		{
			get;
			set;
		}
		public List<UrlProcess> RelateURL
		{
			get;
			set;
		}


		public Task(string name, int importantRate, string tag, DateTime startDate, DateTime deadLine, string txt)
		{
			this.Name = name;
			this.ImportantRate = importantRate;
			this.Tag = tag;
			this.StartDate = startDate;
			this.DeadLine = deadLine;
			this.Txt = txt;
			RelateFile = new List<FileProcess>();
			RelateURL = new List<UrlProcess>();
		}

		public Task(string name, int importantRate, string tag, DateTime startDate, DateTime deadLine, string txt,List<FileProcess> fileList,List<UrlProcess> urlList) : this(name, importantRate, tag, startDate, deadLine, txt)
		{
			RelateFile = fileList;
			RelateURL = urlList;
		}

		public void AddRelateFile(FileProcess file)
		{
			RelateFile.Add(file);
		}

		public void AddRelateUrl(UrlProcess url)
		{
			RelateURL.Add(url);
		}

		public bool CheckTaskFormat() => !(Name.Equals("")  || DeadLine == null);
	}
}
