using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Mars_rover
{
    public class KomutaKontrol
    {
        List<string> yonler = new List<string> { "W", "N", "E", "S" };

        static List<Arac> araclar;
        Arac komutaEdileceArac;
        DuzlemBoyutlari duzlemBoyutlari;

        /// <summary>
        /// Yuzeyde bulunan araclar kaydediliyor
        /// </summary>
        /// <param name="arac"></param>
        public static void AracEkle(Arac arac)
        {
            if (araclar == null)
            {
                araclar = new List<Arac>();
            }

            araclar.Add(arac);
        }

        public KomutaKontrol(Arac arac, DuzlemBoyutlari duzlemBoyutlari)
        {
            komutaEdileceArac = arac;
            this.duzlemBoyutlari = duzlemBoyutlari;
        }        

        public void KomutlariUygula(string komutlar)
        {
            foreach (var komut in komutlar.ToCharArray())
            {
                if (komut == 'M')
                {
                    var aracDurdu = HareketEttir(1);
                    if (aracDurdu)
                        break;
                }
                else if (komut == 'L' || komut == 'R')
                {
                    YonunuDegistir(komut.ToString());
                }
            }
        }

        /// <summary>
        /// WNES, index numaralari 0123
        /// sol ise formul = MutlakDeger(((index - 1) + 4) mod4) bu yeni yonun indexini verir
        /// sag ise formul = MutlakDeger(((index + 1) + 4) mod4) bu yeni yonun indexini verir
        /// </summary>
        /// <param name="sagsol"></param>
        private void YonunuDegistir(string sagsol)
        {
            if (sagsol == "R")
            {
                komutaEdileceArac.Konum.Yon = yonler[Math.Abs((yonler.IndexOf(komutaEdileceArac.Konum.Yon) + 1 + 4) % 4)];
            }
            else
            {
                komutaEdileceArac.Konum.Yon = yonler[Math.Abs((yonler.IndexOf(komutaEdileceArac.Konum.Yon) - 1 + 4) % 4)];
            }
        }

        private bool HareketEttir(int hareketSayisi)
        {
            bool aracDurdu = false;
            switch (komutaEdileceArac.Konum.Yon)
            {
                case "W":
                    var yeniKonumX = komutaEdileceArac.Konum.X - hareketSayisi;

                    if (0 > yeniKonumX)
                    {
                        System.Console.WriteLine($"Duzlem disi hareket var! X Ekseni {komutaEdileceArac.Name}");
                        aracDurdu = true;
                    }
                    else if (CarpismaKontrolu(yeniKonumX, komutaEdileceArac.Konum.Y))
                    {
                        aracDurdu = true;
                    }
                    else
                    {
                        komutaEdileceArac.Konum.X = yeniKonumX;
                    }
                    break;
                case "S":
                    var yeniKonumY = komutaEdileceArac.Konum.Y - hareketSayisi;

                    if (0 > yeniKonumY)
                    {
                        System.Console.WriteLine($"Duzlem disi hareket var! Y Ekseni {komutaEdileceArac.Name}");
                        aracDurdu = true;
                    }
                    else if (CarpismaKontrolu(komutaEdileceArac.Konum.X, yeniKonumY))
                    {
                        aracDurdu = true;
                    }
                    else
                    {
                        komutaEdileceArac.Konum.Y = yeniKonumY;
                    }
                    break;
                case "E":
                    var yeniKonumX2 = komutaEdileceArac.Konum.X + hareketSayisi;

                    if (duzlemBoyutlari.X < yeniKonumX2)
                    {
                        System.Console.WriteLine($"Duzlem disi hareket var! X Ekseni {komutaEdileceArac.Name}");
                        aracDurdu = true;
                    }
                    else if (CarpismaKontrolu(yeniKonumX2, komutaEdileceArac.Konum.Y))
                    {
                        aracDurdu = true;
                    }
                    else
                    {
                        komutaEdileceArac.Konum.X = yeniKonumX2;
                    }
                    break;
                case "N":
                    var yeniKonumY2 = komutaEdileceArac.Konum.Y + hareketSayisi;

                    if (duzlemBoyutlari.Y < yeniKonumY2)
                    {
                        System.Console.WriteLine($"Duzlem disi hareket var! Y Ekseni {komutaEdileceArac.Name}");
                        aracDurdu = true;
                    }
                    else if (CarpismaKontrolu(komutaEdileceArac.Konum.X, yeniKonumY2))
                    {
                        aracDurdu = true;
                    }
                    else
                    {
                        komutaEdileceArac.Konum.Y = yeniKonumY2;
                    }
                    break;
            }

            return aracDurdu;
        }

        /// <summary>
        /// Verilen koordinatlarda arac olup olmadigi kontrol eder var ise true doner
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        bool CarpismaKontrolu(int x, int y)
        {
            var duzlemBulunanDigerAraclar = araclar.Where(arac => arac.Name != komutaEdileceArac.Name).ToList();

            foreach (Arac arac in duzlemBulunanDigerAraclar)
            {
                if (arac.Konum.X == x && arac.Konum.Y == y)
                {
                    System.Console.WriteLine($"{x},{y} koordinatlarinda {arac.Name} araci vardir!");

                    return true;
                }
            }

            return false;
        }
    }
}