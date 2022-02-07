using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculatorApp.Services
{
	public interface IMessageService
	{
		Task ShowAsync(string message);
	}
}
