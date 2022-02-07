using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxCalculatorApp.Models;
using Taxjar;

namespace TaxCalculatorApp.Services
{
	public class TaxService : ITaxService
	{
		public async Task<TaxOrderResult> GetTaxForOrder(TaxOrder taxOrder)
		{
			var client = new TaxjarApi(Settings.TaxJarApiKey);
			client.headers.Add("Content-Type", "application/json");

			if (taxOrder != null)
			{
				var taxForOrder = await client.TaxForOrderAsync(taxOrder);

				TaxOrderResult response = new TaxOrderResult
				{
					OrderTotalAmount = taxForOrder.OrderTotalAmount,
					Shipping = taxForOrder.Shipping,
					TaxableAmount = taxForOrder.TaxableAmount,
					AmountToCollect = taxForOrder.AmountToCollect,
					TaxRate = taxForOrder.Rate,
					HasNexus = taxForOrder.HasNexus,
					FreightTaxable = taxForOrder.FreightTaxable,
					TaxSource = taxForOrder.TaxSource,
					ExemptionType = taxForOrder.ExemptionType,
				};
				return response;
			}
			else
			{
				return null;
			}
		}
		public async Task<TaxRateResult> GetTaxRateForLocation(Location location)
		{
			var client = new TaxjarApi(Settings.TaxJarApiKey);

			if (location != null)
			{
				var rates = await client.RatesForLocationAsync(location.Zip);

				//Since you said you were primarily USA and Canada based, I just included those parameters.
				TaxRateResult response = new TaxRateResult
				{
					Location = new Location
					{
						Country = rates.Country,
						Zip = rates.Zip,
						State = rates.State,
						City = rates.City
					},
					StateRate = rates.StateRate,
					CountyRate = rates.CountyRate,
					CityRate = rates.CityRate,
					CombinedDistrictRate = rates.CombinedDistrictRate,
					CombinedRate = rates.CombinedRate,
					FreightTaxable = rates.FreightTaxable
				};
				return response;
			}
			else
			{
				return null;
			}
		}
	}
}
