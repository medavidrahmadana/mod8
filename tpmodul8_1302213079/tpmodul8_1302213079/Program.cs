using System;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = new CovidConfig();
        string satuSuhu = config.GetSatuSuhu();
        int batasHariDemam = config.GetBatasHariDemam();
        string pesanDitolak = config.GetPesanDitolak();
        string pesanDiterima = config.GetPesanDiterima();

        Console.WriteLine($"Satu suhu saat ini adalah {satuSuhu}");
        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {satuSuhu}: ");
        double suhu = double.Parse(Console.ReadLine());

        if (satuSuhu == "celcius")
        {
            if (suhu < 36.5 || suhu > 37.5)
            {
                Console.WriteLine(pesanDitolak);
                return;
            }
        }
        else
        {
            if (suhu < 97.7 || suhu > 99.5)
            {
                Console.WriteLine(pesanDitolak);
                return;
            }
        }

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hariDemam = int.Parse(Console.ReadLine());

        if (hariDemam >= batasHariDemam)
        {
            Console.WriteLine(pesanDiterima);
        }
        else
        {
            Console.WriteLine(pesanDitolak);
        }

        // Mengubah satuan suhu
        Console.Write("Apakah anda ingin mengubah satuan suhu? (y/n) ");
        string jawaban = Console.ReadLine();
        if (jawaban == "y")
        {
            config.UbahSatuan();
            satuSuhu = config.GetSatuSuhu();
            Console.WriteLine($"Satu suhu sekarang adalah {satuSuhu}");
        }
    }
}
