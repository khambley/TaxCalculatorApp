using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxCalculatorApp.Models;

namespace TaxCalculatorApp.Services
{
	public interface ITaxService
	{
		Task<TaxOrderResult> GetTaxForOrder(TaxOrder taxOrder);
		Task<TaxRateResult> GetTaxRateForLocation(Location location);
	}
}
