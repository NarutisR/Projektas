using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using Butybe;

namespace ZaidimoVariklis
{
    public static class Objektai
    {
        public static List<Rectangle> Kryptis = new List<Rectangle>();
        public static void SukurtiPriesus(Canvas zemelapis, double gyvybesTaskai, double jega, double puolimoGreitis, double judejimoGreitis, double gyjimoLaikas)
        {
            int i = 0;
            foreach (Rectangle r in zemelapis.Children.OfType<Rectangle>())
            {
                if ((string)r.Tag == "Priesas")
                {
                    Random rnd = new Random(i);
                    Priesas.PriesuSarasasPriesas.Add(new Priesas(gyvybesTaskai, jega,puolimoGreitis, judejimoGreitis, gyjimoLaikas));
                    Priesas.PriesuSarasasRectangle.Add(r);
                    Priesas.PriesuSarasasPriesas[i].Remas = new Rect(Canvas.GetLeft(r), Canvas.GetTop(r), r.Width, r.Height);
                    i++;
                }
            }
        }
    }
}
