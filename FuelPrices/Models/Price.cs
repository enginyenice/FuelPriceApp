using System.Text.Json.Serialization;

namespace FuelPrices.Models;

public class Price
{
    [JsonPropertyName("id")] public string Id { get; set; }
    [JsonPropertyName("productName")] public string ProductName { get; set; }
    [JsonPropertyName("productShortName")] public string ProductShortName { get; set; }
    [JsonPropertyName("amount")] public decimal Amount { get; set; }
    [JsonPropertyName("productCode")] public string ProductCode { get; set; }
}