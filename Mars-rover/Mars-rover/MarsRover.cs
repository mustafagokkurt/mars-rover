using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_rover
{
    public class MarsRover
    {        
        public void Baslat()
        {
            Console.WriteLine("Mars Projesi");

            for (; ; )
            {
                Console.WriteLine("Input: ");
                string input0 = Console.ReadLine();                
                string konumBilgisi1 = Console.ReadLine();
                string arac1Komut = Console.ReadLine();
                string konumBilgisi2 = Console.ReadLine();
                string arac2Komut = Console.ReadLine();

                #region arac adi ve konum bilgileri, duzlem boyutlari kaydediliyor
                DuzlemBoyutlari duzlemBoyutlari = new DuzlemBoyutlari
                {
                    X = int.Parse(input0.Split(' ')[0]),
                    Y = int.Parse(input0.Split(' ')[1]),
                };
                Arac Arac1 = new Arac
                {
                    Konum = new Konum
                    {
                        X = int.Parse(konumBilgisi1.Split(' ')[0]),
                        Y = int.Parse(konumBilgisi1.Split(' ')[1]),
                        Yon = konumBilgisi1.Split(' ')[2]
                    },
                    Name = "Rover-1"
                };
                Arac Arac2 = new Arac
                {
                    Konum = new Konum
                    {
                        X = int.Parse(konumBilgisi2.Split(' ')[0]),
                        Y = int.Parse(konumBilgisi2.Split(' ')[1]),
                        Yon = konumBilgisi2.Split(' ')[2]
                    },
                    Name = "Rover-2"
                };
                #endregion

                KomutaKontrol.AracEkle(Arac1);
                KomutaKontrol.AracEkle(Arac2);
                KomutaKontrol komutaKontrolArac1 = new KomutaKontrol(Arac1, duzlemBoyutlari);
                KomutaKontrol komutaKontrolArac2 = new KomutaKontrol(Arac2, duzlemBoyutlari);

                komutaKontrolArac1.KomutlariUygula(arac1Komut);
                komutaKontrolArac2.KomutlariUygula(arac2Komut);
                
                Console.WriteLine("Output: ");
                System.Console.WriteLine(Arac1.Konum.ToString());
                System.Console.WriteLine(Arac2.Konum.ToString());
            }
        }        
    }
}
