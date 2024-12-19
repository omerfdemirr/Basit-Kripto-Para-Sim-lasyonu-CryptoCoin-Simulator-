using System;

namespace CryptoCoinSimulator
{
    class Program
    {
        static double bakiye = 1000.0; // Başlangıç nakit
        static double coinMiktari = 0.0; // Başlangıç kripto para
        static double coinFiyati = 50.0; // İlk turdaki kripto para fiyatı

        static void Main(string[] args)
        {
            Console.WriteLine("Basit Kripto Para Simülasyonu'na Hoş Geldiniz!");
            Console.Write("Kaç tur oynamak istiyorsunuz? ");
            int turSayisi = int.Parse(Console.ReadLine());

            for (int tur = 1; tur <= turSayisi; tur++)
            {
                Console.Clear();
                Console.WriteLine($"Tur: {tur}/{turSayisi}");
                Console.WriteLine($"Mevcut Coin Fiyatı: {coinFiyati:C}");
                Console.WriteLine($"Nakit Bakiye: {bakiye:C}");
                Console.WriteLine($"Sahip Olduğunuz Coin Miktarı: {coinMiktari:F2}");

                Console.WriteLine("\nSeçenekler:");
                Console.WriteLine("1. Coin Satın Al");
                Console.WriteLine("2. Coin Sat");
                Console.WriteLine("3. Pas Geç");

                Console.Write("Seçiminizi yapın (1/2/3): ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        CoinSatinAl();
                        break;
                    case "2":
                        CoinSat();
                        break;
                    case "3":
                        Console.WriteLine("Pas geçtiniz.");
                        break;
                    default:
                        Console.WriteLine("Geçersiz seçim!");
                        break;
                }

                CoinFiyatiniGuncelle();
                Console.WriteLine("\nBir sonraki tura geçmek için bir tuşa basın...");
                Console.ReadKey();
            }

            Console.Clear();
            double toplamDeger = bakiye + (coinMiktari * coinFiyati);
            Console.WriteLine("Oyun Bitti!");
            Console.WriteLine($"Son Bakiye: {bakiye:C}");
            Console.WriteLine($"Coin Değeri: {(coinMiktari * coinFiyati):C}");
            Console.WriteLine($"Toplam Varlık: {toplamDeger:C}");
            Console.WriteLine(toplamDeger > 1000 ? "Tebrikler, kâr ettiniz!" : "Üzgünüz, zarar ettiniz.");
        }

        static void CoinSatinAl()
        {
            Console.Write("Kaç coin almak istiyorsunuz? ");
            double alinacakMiktar = double.Parse(Console.ReadLine());
            double toplamFiyat = alinacakMiktar * coinFiyati;

            if (toplamFiyat > bakiye)
            {
                Console.WriteLine("Yeterli bakiyeniz yok!");
            }
            else
            {
                bakiye -= toplamFiyat;
                coinMiktari += alinacakMiktar;
                Console.WriteLine($"{alinacakMiktar:F2} coin satın aldınız.");
            }
        }

        static void CoinSat()
        {
            Console.Write("Kaç coin satmak istiyorsunuz? ");
            double satilacakMiktar = double.Parse(Console.ReadLine());

            if (satilacakMiktar > coinMiktari)
            {
                Console.WriteLine("Yeterli coin miktarınız yok!");
            }
            else
            {
                double toplamGelir = satilacakMiktar * coinFiyati;
                bakiye += toplamGelir;
                coinMiktari -= satilacakMiktar;
                Console.WriteLine($"{satilacakMiktar:F2} coin sattınız.");
            }
        }

        static void CoinFiyatiniGuncelle()
        {
            Random rnd = new Random();
            double dalgalanma = rnd.Next(-10, 11); // -10 ile +10 arasında rastgele dalgalanma
            coinFiyati += dalgalanma;

            if (coinFiyati < 1)
                coinFiyati = 1; // Coin fiyatı sıfırın altına düşemez
        }
    }
}
