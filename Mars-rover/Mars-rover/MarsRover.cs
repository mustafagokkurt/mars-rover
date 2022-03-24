using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_rover
{
    public class MarsRover
    {
        List<string> yonler = new List<string> { "W", "N", "E", "S" };

        public class Konum
        {
            public int X;
            public int Y;
            public string Yon;

            public override string ToString()
            {
                return $"{X} {Y} {Yon}";
            }
        }

        public void Baslat()
        {
            Console.WriteLine("Mars Projesi");

            for (; ; )
            {
                Console.WriteLine("Mevcut Konum ve Yönü belirtiniz?");
                string input = Console.ReadLine();

                Konum konum = new Konum
                {
                    X = int.Parse(input.Split(' ')[0]),
                    Y = int.Parse(input.Split(' ')[1]),
                    Yon = input.Split(' ')[2]
                };

                Console.WriteLine("Yönlendirme bilgisi giriniz?");
                string input2 = Console.ReadLine();
                char[] ch = input2.ToCharArray();
                foreach (var c in ch)
                {
                    if (c == 'M')
                    {
                        konum = HareketEttir(konum, 1);
                    }
                    else if (c == 'L' || c == 'R')
                    {
                        konum.Yon = YonBul(konum, c.ToString());
                    }
                }

                System.Console.WriteLine(konum.ToString());
            }

            
        }

        public string YonBul(Konum konum, string sagsol)
        {
            if (sagsol == "R")
            {
                return yonler[Math.Abs((yonler.IndexOf(konum.Yon) + 1 + 4) % 4)];
            }
            else
            {
                return yonler[Math.Abs((yonler.IndexOf(konum.Yon) - 1 + 4) % 4)];
            }
        }

        Konum HareketEttir(Konum konum, int hareketSayisi)
        {
            switch (konum.Yon)
            {
                case "W":
                    konum.X = konum.X - hareketSayisi;
                    break;
                case "S":
                    konum.Y = konum.Y - hareketSayisi;
                    break;
                case "E":
                    konum.X = konum.X + hareketSayisi;
                    break;
                case "N":
                    konum.Y = konum.Y + hareketSayisi;
                    break;
            }

            return konum;
        }
    }
}
