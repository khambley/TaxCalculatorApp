using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using TaxCalculatorApp.Models;
using TaxCalculatorApp.Services;
using Taxjar;

namespace TaxCalculatorApp.ViewModels
{
	public class TaxCalculatorViewModel : ViewModelBase
	{
		private readonly ITaxService _taxService;
		private readonly IMessageService _messageService;
		public TaxRateResult TaxRateResult { get; set; }
		public Location Location { get; set; }
		public bool IsRefreshing { get; set; }

		public TaxCalculatorViewModel(TaxService taxService, MessageService messageService)
		{
			_taxService = taxService;
			_messageService = messageService;
			Location = new Location();
		}
		public ICommand GetTaxRate => new Command(async () =>
		{
			try
			{
				IsRefreshing = true;
				TaxRateResult = await _taxService.GetTaxRateForLocation(Location);
				IsRefreshing = false;
			}
			catch(TaxjarException e)
			{
				//just a simple alert box for demo purposes. :)
				await _messageService.ShowAsync(e.TaxjarError.StatusCode + " " + e.TaxjarError.Detail);
			}

		});




	}
}
