using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FileAccessWatcher
{
	class AccessLogItem
	{
		public string? Name { get; set; }
		public DateTime TimeStamp { get; set; }
		public WatcherChangeTypes watcherChangeTypes { get; set; }
	}

	class FileAccessWatcherViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<AccessLogItem> accessLogItems = new ObservableCollection<AccessLogItem>();

		public event PropertyChangedEventHandler? PropertyChanged;

		public ObservableCollection<AccessLogItem> AccessLogItems
		{
			get => accessLogItems; set {
				SetProperty(ref accessLogItems, value);
			}
		}

		public void SetProperty<T>(ref T target, T value, [CallerMemberName] string caller = "")
		{
			target = value;

			if (PropertyChanged == null)
				return;
			PropertyChangedEventArgs arg = new PropertyChangedEventArgs(caller);
			PropertyChanged.Invoke(this, arg);
		}

		public FileAccessWatcherViewModel(){
			this.accessLogItems.Add(new AccessLogItem() {
			Name = "てｓｔ"});
		}

	}
}
