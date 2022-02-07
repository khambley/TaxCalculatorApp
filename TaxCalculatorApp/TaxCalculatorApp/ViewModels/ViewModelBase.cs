using System.ComponentModel;
using Xamarin.Forms;

namespace TaxCalculatorApp.ViewModels
{
	public abstract class ViewModelBase : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public INavigation Navigation { get; set; }
	}
}
