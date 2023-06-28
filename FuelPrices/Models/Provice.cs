using System.Text.Json.Serialization;

namespace FuelPrices.Models;

public class Provice
{
    [JsonPropertyName("provinceCode")] public int ProvinceCode { get; set; }
    [JsonPropertyName("provinceName")] public string ProvinceName { get; set; }
    [JsonPropertyName("districtCode")] public string DistrictCode { get; set; }
    [JsonPropertyName("districtName")] public string DistrictName { get; set; }
    [JsonPropertyName("prices")] public List<Price> Prices { get; set; }
}