using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class Program
{
    public static void Main(string[] args)
    {
        int days = 2;
        if (args.Length > 0)
        {
            days = int.Parse(args[0]) + 1;
        }

        // this conjured item does not work properly yet

        var app = new GildedRose();
        app.ExecuteDemo("");
        app.DisplayUpdateConsole(days);

        Console.WriteLine("... !");
    }
}