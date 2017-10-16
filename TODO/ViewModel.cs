using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TODO
{
    public class ViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion              

        public ViewModel()
        {
            taskList = new ObservableCollection<Task>();
            addCommand = new Command(ExecuteAdd);
            doneCommand = new Command(ExecuteDone);
            deadline = DateTime.Today;
        }

        private ObservableCollection<Task> taskList;
        public ObservableCollection<Task> TaskList
        {
            get { return taskList; }
            set
            {
                taskList = value;
                OnPropertyChanged("TaskList");
            }
        }
        private Command addCommand;
        public Command AddCommand
        {
            get { return addCommand; }
        }
        private Command doneCommand;
        public Command DoneCommand
        {
            get { return doneCommand; }
        }


        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        private DateTime deadline;
        public DateTime Deadline
        {
            get { return deadline; }
            set
            {
                deadline = value;
                OnPropertyChanged("Deadline");
            }
        }

        /// <summary>
        /// 追加処理。
        /// </summary>
        private void ExecuteAdd()
        {
            var task = new Task();
            task.Title = title;
            task.Deadline = deadline;
            task.Done = false;
            taskList.Add(task);
        }
        /// <summary>
        /// 完了済みのタスクの削除
        /// </summary>
        private void ExecuteDone()
        {
            for (int i = taskList.Count - 1; i >= 0; i--)
            {
                if (taskList[i].Done)
                {
                    taskList.RemoveAt(i);
                }
            }
        }
    }
}
