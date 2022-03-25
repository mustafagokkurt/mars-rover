using System;
using System.Collections.Generic;
using System.Text;

namespace Mars_rover
{
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
}
