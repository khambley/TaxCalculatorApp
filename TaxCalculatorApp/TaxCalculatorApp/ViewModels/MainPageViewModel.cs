using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TaxCalculatorApp.Services;
using TaxCalculatorApp.Views;
using Xamarin.Forms;

namespace TaxCalculatorApp.ViewModels
{
	public class MainPageViewModel : ViewModelBase
	{
		private readonly ITaxService _taxService;
		private readonly IMessageService _messageService;

		public MainPageViewModel(TaxService taxService, MessageService messageService)
		{
			_taxService = taxService;
			_messageService = messageService;

		}
		public ICommand GoToTaxRatesPage => new Command(async () =>
		{
			var taxCalculatorPage = Resolver.Resolve<TaxCalculatorPage>();
			await Navigation.PushAsync(taxCalculatorPage);
		});
		public ICommand GoToTaxOrderPage => new Command(async () =>
		{
			var taxOrderPage = Resolver.Resolve<TaxOrderPage>();
			await Navigation.PushAsync(taxOrderPage);
		});
	}
}
