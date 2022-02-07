using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculatorApp.Models
{
	//Combined them into one file just for demo purposes.
	public class Location
	{
		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("zip")]
		public string Zip { get; set; }

		[JsonProperty("state")]
		public string State { get; set; }

		[JsonProperty("city")]
		public string City { get; set; }

		[JsonProperty("street")]
		public string Street { get; set; }
	}
	public class FromLocation
	{
		[JsonProperty("from_country")]
		public string FromCountry { get; set; }

		[JsonProperty("from_state")]
		public string FromState { get; set; }

		[JsonProperty("from_city")]
		public string FromCity { get; set; }

		[JsonProperty("from_street")]
		public string FromStreet { get; set; }
		
		[JsonProperty("from_zip")]
		public string FromZip { get; set; }
	}
	public class ToLocation
	{
		[JsonProperty("to_country")]
		public string ToCountry { get; set; }

		[JsonProperty("to_state")]
		public string ToState { get; set; }

		[JsonProperty("to_city")]
		public string ToCity { get; set; }

		[JsonProperty("to_street")]
		public string ToStreet { get; set; }

		[JsonProperty("to_zip")]
		public string ToZip { get; set; }
	}
	public class NexusAddress
	{
		[JsonProperty("id")]
		public string Id { get; set; }
		public Location NexusLocation { get; set; }

	}
	public class LineItem
	{
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("quantity")]
		public int Quantity { get; set; }

		[JsonProperty("product_tax_code")]
		public string ProductTaxCode { get; set; }

		[JsonProperty("unit_price")]
		public decimal UnitPrice { get; set; }

		[JsonProperty("discount")]
		public decimal Discount { get; set; }
	}
	public class TaxOrder
	{
		public FromLocation FromLocation { get; set; }
		public ToLocation ToLocation { get; set; }

		[JsonProperty("amount")]
		public decimal Amount { get; set; }

		[JsonProperty("shipping")]
		public decimal Shipping { get; set; }

		[JsonProperty("nexus_addresses")]
		public List<NexusAddress> NexusAddresses { get; set; }

		[JsonProperty("line_items")]
		public List<LineItem> LineItems { get; set; }

	}
	public class TaxRateResult
	{
		public Location Location { get; set; }
		public decimal StateRate { get; set; }
		public decimal CountyRate { get; set; }
		public decimal CityRate { get; set; }
		public decimal CombinedDistrictRate { get; set; }
		public decimal CombinedRate { get; set; }
		public bool FreightTaxable { get; set; }

	}
	public class TaxOrderResult
	{
		public decimal OrderTotalAmount { get; set; }
		public decimal Shipping { get; set; }
		public decimal TaxableAmount { get; set; }
		public decimal AmountToCollect { get; set; }
		public decimal TaxRate { get; set; }
		public bool HasNexus { get; set; }
		public bool FreightTaxable { get; set; }
		public string TaxSource { get; set; }
		public string ExemptionType { get; set; }


	}
}
