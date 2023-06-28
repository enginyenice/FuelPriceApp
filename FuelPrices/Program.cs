using System.Globalization;
using ConsoleTables;
using FuelPrices;

var opetFuelPrice = new OpetFuelPrice();
bool isSwitched = false;
try
{
    for (int i = 0; i < args.Length; i++)
    {
        switch (args[i])
        {
            case "-p":
                var provinceCodeModels = opetFuelPrice.GetFuelPriceByProvinceCode(Int32.Parse(args[i + 1]));
                opetFuelPrice.ConsoleWrite(provinceCodeModels);
                isSwitched = true;
                break;
            case "-c":
                var proviceNameModels = opetFuelPrice.GetFuelPriceByProvinceName(args[i + 1]);
                opetFuelPrice.ConsoleWrite(proviceNameModels);
                isSwitched = true;
                break;
            case "-h":
                ShowHelp();
                isSwitched = true;
                break;
        }

        if (isSwitched)
            break;
    }
    
    if (!isSwitched)
    {
        var proviceNameModels = opetFuelPrice.GetAllFuelPrice();
        opetFuelPrice.ConsoleWrite(proviceNameModels);
    }
}
catch (Exception e)
{
    Console.WriteLine("Seçim işleminde bir hata oluştu.");
    ShowHelp();
    
}

void ShowHelp()
{
    var table = new ConsoleTable("Parametre", "Açıklama", "Örnek");
    table.AddRow("", "Tüm iller için sorgulama yapar.", "");
    table.AddRow("-p", "Plaka kodu ile sorgulama yapmanızı sağlar", "-p 26");
    table.AddRow("-c", "Şehir adı ile sorgulama yapmanızı sağlar", "-c ESKİŞEHİR");
    table.AddRow("-h", "Uygulama parametleri hakkında bilgi verir", "");
    table.Write();
}