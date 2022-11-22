using System;
using System.Collections.Generic;
using System.Linq;


namespace TGIF
{

	class TaskManager
	{
		List<Task> tasks;
		SortedSet<String> tags;

		public TaskManager()
		{
			tasks = new List<Task>();
			tags = new SortedSet<String>();
		}

		public void EnrollTask(Task task)
		{
			tasks.Add(task);
			SortTask_Inorder_deadline();
			tags.Add(task.Tag);

		}

		public void DeleteTask(Task task)
		{
			string tag = task.Tag;
			tasks.Remove(task);
			if (!BeUsedTag(tag))
			{
				tags.Remove(tag);
			}
		}

		public List<Task> GetTaskList()
		{

			return tasks;
		}

		public void SetTaskList(List<Task> tasks)
		{
			this.tasks = tasks;
		}

		public string[] GetTags()
		{
			return tags.ToArray<String>();
		}

		public void SetTags(SortedSet<String> tags)
		{
			this.tags = tags;
		}

		public bool AddTag(string tag)
		{
			return tags.Add(tag);
		}

		public void Save()
		{
			new SaveText(this);
		}

		public void Open()
		{
			new OpenText(this);
		}

		public List<Task> GetFilteredTaskList(string name, ImportantRate rate, string tag)
		{
			List<Task> filtedList;

			filtedList = tasks.FindAll((task) =>
			{
				if (task.Name.Contains(name))
					return true;

				return false;
			});

			filtedList = filtedList.FindAll((task) =>
			{
				if (task.Tag.Equals(tag))
					return true;

				return false;
			});

			filtedList = filtedList.FindAll((task) =>
			{
				ImportantRate taskLate = (ImportantRate)task.ImportantRate;

				if(taskLate.HasFlag(rate)){
					return true;
				}
				return false;

			});


			return filtedList;
		}

		private bool BeUsedTag(string tag) //삭제된 태스크의 태그를 이용하여 더 이상 그 태그를 가지고 있는 태스크가 없다면 해당 태그 삭제
		{

			return tasks.Exists((target) =>
			{
				return target.Tag.Equals(tag);
			});


		}

		private void SortTask_Inorder_deadline()
		{
			tasks.Sort((X, Y) => { return X.DeadLine.CompareTo(Y.DeadLine); });
		}
	}
}
