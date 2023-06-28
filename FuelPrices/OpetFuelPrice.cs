using System.Globalization;
using System.Net;
using System.Text.Json;
using ConsoleTables;
using FuelPrices.Models;

namespace FuelPrices;

public class OpetFuelPrice
{
    private string _url = "https://api.opet.com.tr/api/fuelprices/allprices";
    
    public List<Provice> GetFuelPriceByProvinceCode(int proviceCode)
    {
        var models = GetAllFuelPrice();
        var item = models.FirstOrDefault(p => p.ProvinceCode == proviceCode);
        if (item != null)
        {
            models.Clear();
            models.Add(item);
        }
        return models;
    }

    public List<Provice> GetFuelPriceByProvinceName(string proviceName)
    {
        var models = GetAllFuelPrice();
        var item = models.FirstOrDefault(p => p.ProvinceName == proviceName.ToUpper(CultureInfo.GetCultureInfo("tr-TR")));
        if (item != null)
        {
            models.Clear();
            models.Add(item);
        }
        return models;
    }

    public List<Provice> GetAllFuelPrice()
    {
        using var client = new WebClient();
        var response = client.DownloadString(_url);
        return JsonSerializer.Deserialize<List<Provice>>(response);
    }

    public void ConsoleWrite(List<Provice> proviceModels)
    {
        var table = new ConsoleTable("Şehir Plaka", "Şehir Adı", "Kurşunsuz Benzin 95", "Motorin UltraForce","Motorin EcoForce");
        foreach (var provice in proviceModels.OrderBy(p => p.ProvinceCode))
        {
            var KURS = provice.Prices.FirstOrDefault(p => p.ProductShortName == "KURS");
            var MT_ULT = provice.Prices.FirstOrDefault(p => p.ProductShortName == "MT_ULT");
            var MT_ECO = provice.Prices.FirstOrDefault(p => p.ProductShortName == "MT_ECO");

            table.AddRow(provice.ProvinceCode, provice.ProvinceName, $"{KURS.Amount} TL", $"{MT_ULT.Amount} TL",
                $"{MT_ECO.Amount} TL");
        }

        table.Write(Format.Alternative);
    }
}