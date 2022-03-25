using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Test;
using Xunit;
using static Mars_rover.MarsRover;

namespace Mars_rover.Test
{
    public class MarsRoverTest
    {
        //[Fact]
        //public void YonBulTest()
        //{
        //    #region Arrange
        //    //Kaynaklar hazırlanıyor.
        //    Konum konum = new Konum
        //    {
        //        X = 1,
        //        Y = 2,
        //        Yon = "N"
        //    };

        //    string expected = "W";
        //    MarsRover marsRover = new MarsRover();
        //    #endregion

        //    #region Act
        //    //İlgili metot Arrange'de ki kaynaklarla test ediliyor.
        //    string result = marsRover.YonBul(konum, "L");
        //    #endregion

        //    #region Assert
        //    //Test neticesinde gelen data doğrulanıyor.
        //    Assert.Equal(expected, result);
        //    #endregion
        //}

        [Theory]
        [ClassData(typeof(TestDataGenerator2))]
        public void KomutlariUygulaTest(List<Arac> araclar, Arac arac1, DuzlemBoyutlari duzlemBoyutlari, string komutlar, string expected)
        {
            #region Arrange            
            araclar.ForEach(arac => KomutaKontrol.AracEkle(arac));             
            KomutaKontrol komutaKontrolArac1 = new KomutaKontrol(arac1, duzlemBoyutlari);
            #endregion

            #region Act            
            komutaKontrolArac1.KomutlariUygula(komutlar);
            #endregion

            #region Assert            
            Assert.Equal(expected, arac1.Konum.ToString());
            #endregion
        }

        //[Theory]
        //[ClassData(typeof(TestDataGenerator))]
        //public void YonBulTest2(Konum konum, string sagsol, string expected)
        //{
        //    #region Arrange
        //    //Kaynaklar hazırlanıyor.

        //    MarsRover marsRover = new MarsRover();
        //    #endregion

        //    #region Act
        //    //İlgili metot Arrange'de ki kaynaklarla test ediliyor.
        //    string result = marsRover.YonBul(konum, sagsol);
        //    #endregion

        //    #region Assert
        //    //Test neticesinde gelen data doğrulanıyor.
        //    Assert.Equal(expected, result);
        //    #endregion
        //}

        //public class TestDataGenerator : IEnumerable<object[]>
        //{
        //    private readonly List<object[]> _data = new List<object[]> {
        //        new object[] {new Konum { X = 1, Y = 2, Yon = "N" }, "L", "W" },
        //        new object[] {new Konum { X = 3, Y = 3, Yon = "E" }, "R", "S" }
        //    };

        //    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        //    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        //}

        public class TestDataGenerator2 : IEnumerable<object[]>
        {
            static Arac arac1 = new Arac
            {
                Konum = new Konum
                {
                    X = 1,
                    Y = 2,
                    Yon = "N"
                },
                Name = "Rover-1"
            };
            static Arac arac2 = new Arac
            {
                Konum = new Konum
                {
                    X = 3,
                    Y = 3,
                    Yon = "E"
                },
                Name = "Rover-2"
            };
            static Arac arac3 = new Arac
            {
                Konum = new Konum
                {
                    X = 1,
                    Y = 2,
                    Yon = "N"
                },
                Name = "Rover-3"
            };

            static List<Arac> araclar = new List<Arac>() { arac1, arac2};
        


        private readonly List<object[]> _data = new List<object[]> {
                new object[] {
                    araclar ,
                    arac1
                    ,new DuzlemBoyutlari
                    {
                        X = 5,
                        Y = 5,
                    },
                    "LMLMLMLMM ",
                    "1 3 N"
                },
                new object[] {
                    araclar ,
                    arac2
                    ,new DuzlemBoyutlari
                    {
                        X = 5,
                        Y = 5,
                    },
                    "MMRMMRMRRM",
                    "5 1 E"
                },
                new object[] {
                    araclar ,
                    arac3
                    ,new DuzlemBoyutlari
                    {
                        X = 5,
                        Y = 5,
                    },
                    "LMMMMMMMMMMMMMMM",
                    "0 2 W"
                }
        };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
