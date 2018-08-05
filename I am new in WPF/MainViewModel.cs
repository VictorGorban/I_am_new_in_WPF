using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I_am_new_in_WPF
{
	public class MainViewModel : INotifyPropertyChanged
	{
		#region fields
		private string _buttonHistoryLabel;
		#endregion
		#region events
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		#region props
		public string ButtonHistoryLabel { get => _buttonHistoryLabel; set => _buttonHistoryLabel = value; }
		#endregion

		public MainViewModel()
		{
			_buttonHistoryLabel = "HIST";
		}
	}
}
