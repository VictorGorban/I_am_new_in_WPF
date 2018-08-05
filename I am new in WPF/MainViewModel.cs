using System.ComponentModel;
using System.Runtime.CompilerServices;

class MainViewModel : INotifyPropertyChanged
{
	private string _model;
	private string _maxSpeed;
	private string _price;

	public MainViewModel()
	{
		_maxSpeed = "23442";
		_model = "ferrari";
		_price = 234234.234234.ToString();
	}

	public string Model
	{
		get { return _model; }
		set
		{
			_model = value;
			OnPropertyChanged();
		}
	}
	public string MaxSpeed
	{
		get
		{
			return _maxSpeed;
		}
		set
		{
			_maxSpeed = value;
			OnPropertyChanged(nameof(MaxSpeed));
		}
	}
	public string Price
	{
		get { return _price; }
		set
		{
			_price = value;
			OnPropertyChanged(Price); 
			//OnPropertyChanged(Price); // Не получится, потому что вызовется Price.ToString() => value of price, not name of property.
		}
	}
	public event PropertyChangedEventHandler PropertyChanged;
	public void OnPropertyChanged([CallerMemberName]string prop = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
	}
}