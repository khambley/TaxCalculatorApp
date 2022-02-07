using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TaxCalculatorApp.Models;
using TaxCalculatorApp.Services;
using Taxjar;
using Xamarin.Forms;

namespace TaxCalculatorApp.ViewModels
{
	public class TaxOrderViewModel : ViewModelBase
	{
		private readonly ITaxService _taxService;
		private readonly IMessageService _messageService;
		public TaxOrderViewModel(TaxService taxService, MessageService messageService)
		{
			_taxService = taxService;
			_messageService = messageService;
			TaxOrder = new TaxOrder();
			ToLocation = new ToLocation();
			FromLocation = new FromLocation();
		}
		
		public TaxOrder TaxOrder { get; set; }
		public FromLocation FromLocation { get; set; }
		public ToLocation ToLocation { get; set; }
		public TaxOrderResult TaxOrderResult { get; set; }

		public ICommand GetTaxForOrder => new Command(async () =>
		{
			try
			{
				TaxOrder.FromLocation = new FromLocation
				{
					FromCountry = FromLocation.FromCountry,
					FromZip = FromLocation.FromZip,
					FromState = FromLocation.FromState,
					FromCity = FromLocation.FromCity,
					FromStreet = FromLocation.FromStreet
				};

				TaxOrder.ToLocation = new ToLocation
				{
					ToCountry = ToLocation.ToCountry,
					ToZip = ToLocation.ToZip,
					ToState = ToLocation.ToState,
					ToCity = ToLocation.ToCity,
					ToStreet = ToLocation.ToStreet
				};
				//var addresses = new List<Models.NexusAddress>();
				//addresses.Add(new Models.NexusAddress
				//{
				//	Id = "Main Location",
				//	NexusLocation = new Location
				//	{
				//		Country = "US",
				//		Zip = "92093",
				//		State = "CA",
				//		City = "La Jolla",
				//		Street = "9500 Gilman Drive"
				//	}
				//});
				//TaxOrder.NexusAddresses = addresses;

				//var lineItems = new List<Models.LineItem>();
				//lineItems.Add(new Models.LineItem
				//{
				//	Id = "1",
				//	Quantity = 1,
				//	ProductTaxCode = "20010",
				//	UnitPrice = 15,
				//	Discount = 0
				//});
				//TaxOrder.LineItems = lineItems;

				TaxOrderResult = await _taxService.GetTaxForOrder(TaxOrder);
			}
			catch(TaxjarException e)
			{
				//just a simple alert box for demo purposes. :)
				await _messageService.ShowAsync(e.TaxjarError.StatusCode + " " + e.TaxjarError.Detail);
			}
		});
	}
}
