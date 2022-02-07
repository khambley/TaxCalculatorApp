using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculatorApp.Services
{
	public class MessageService : IMessageService
	{
		public async Task ShowAsync(string message)
		{
			await App.Current.MainPage.DisplayAlert("Alert", message, "OK");
		}
	}
}
