using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculatorApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaxCalculatorApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TaxOrderPage : ContentPage
	{
		public TaxOrderPage(TaxOrderViewModel viewModel)
		{
			InitializeComponent();
			viewModel.Navigation = Navigation;
			BindingContext = viewModel;
		}
	}
}