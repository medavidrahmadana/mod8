using System;
using System.IO;
using System.Text.Json;

class CovidConfig
{
    private readonly string configFile = "covid.config.json";
    private readonly dynamic config;

    public CovidConfig()
    {
        string jsonString = File.ReadAllText(configFile);
        config = JsonSerializer.Deserialize<dynamic>(jsonString);
    }

    public string GetSatuSuhu()
    {
        return (string)config.GetProperty("satu_suhu").ToString();
    }

    public int GetBatasHariDemam()
    {
        return (int)config.GetProperty("batas_hari_demam").GetUInt32();
    }

    public string GetPesanDitolak()
    {
        return (string)config.GetProperty("pesan_ditolak").ToString();
    }

    public string GetPesanDiterima()
    {
        return (string)config.GetProperty("pesan_diterima").ToString();
    }

    public void UbahSatuan()
    {
        string oldSatuSuhu = config.GetProperty("satu_suhu").ToString();
        string newSatuSuhu = oldSatuSuhu == "celcius" ? "fahrenheit" : "fahrenheit";
        JsonDocument document = JsonDocument.Parse(File.ReadAllText(configFile));
        JsonElement root = document.RootElement;
        JsonElement property = root.GetProperty("satu_suhu");
        property = JsonDocument.Parse($"\"{newSatuSuhu}\"").RootElement;
        Console.WriteLine($"Satuan suhu berhasil diubah dari {oldSatuSuhu} ke {newSatuSuhu}");
        string json = JsonSerializer.Serialize(document);
        File.WriteAllText(configFile, json);
    }

}
