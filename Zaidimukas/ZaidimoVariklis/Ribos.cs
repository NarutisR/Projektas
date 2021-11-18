using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows;
using Butybe;


namespace ZaidimoVariklis
{
    public static class Ribos
    {
        public static void SukurtiRibas(Canvas zemelapis)
        {
            foreach (Rectangle r in zemelapis.Children.OfType<Rectangle>())
            {
                if ((string)r.Tag == "Siena")
                {
                    Koordinates.RibosIDesine.Add(new Rect(Canvas.GetLeft(r) - (1.5 * ZaidejoJudejimas.JudejimoGreitis), Canvas.GetTop(r), 2 * ZaidejoJudejimas.JudejimoGreitis, r.Height));
                    Koordinates.RibosIApacia.Add(new Rect(Canvas.GetLeft(r), Canvas.GetTop(r) - (1.5 * ZaidejoJudejimas.JudejimoGreitis), r.Width, 2 * ZaidejoJudejimas.JudejimoGreitis));
                    Koordinates.RibosIKaire.Add(new Rect(Canvas.GetLeft(r) - (1.5 * ZaidejoJudejimas.JudejimoGreitis) + r.Width, Canvas.GetTop(r), 2.5 * ZaidejoJudejimas.JudejimoGreitis, r.Height));
                    Koordinates.RibosIVirsu.Add(new Rect(Canvas.GetLeft(r), Canvas.GetTop(r) - (1.5 * ZaidejoJudejimas.JudejimoGreitis) + r.Height, r.Width, 2.5 * ZaidejoJudejimas.JudejimoGreitis));
                }
            }
        }
        public static void SukurtiZaidejoRibasPriesams(Shape z)
        {
            Koordinates.ZaidejoIDesine = new Rect(Koordinates.LeftZaidejas - 10, Koordinates.TopZaidejas, 10, 40);
            Koordinates.ZaidejoIKaire = new Rect(Koordinates.LeftZaidejas + z.Width, Koordinates.TopZaidejas, 10, 40);
            Koordinates.ZaidejoIVirsu = new Rect(Koordinates.LeftZaidejas, Koordinates.TopZaidejas + z.Height, 40, 10);
            Koordinates.ZaidejoIApacia = new Rect(Koordinates.LeftZaidejas, Koordinates.TopZaidejas - 10, 40, 10);
        }

        public static void SukurtiPriesuRibasZaidejui(double leftPriesas, double topPriesas, double width, double height, int i)
        {
            Koordinates.PriesoIDesine[i] = new Rect(leftPriesas - 10, topPriesas, 10, 40);
            Koordinates.PriesoIKaire[i] = new Rect(leftPriesas + width, topPriesas, 10, 40);
            Koordinates.PriesoIVirsu[i] = new Rect(leftPriesas, topPriesas + height, 40, 10);
            Koordinates.PriesoIApacia[i] = new Rect(leftPriesas, topPriesas - 10, 40, 10);
        }
        public static void SukurtiPriesuRibasZaidejuiVienaKarta(Canvas zemelapis)
        {
            foreach (Rectangle r in zemelapis.Children.OfType<Rectangle>())
            {
                if ((string)r.Tag == "Priesas")
                {
                    Koordinates.PriesoIDesine.Add(new Rect(Canvas.GetLeft(r) - 10, Canvas.GetTop(r), 10, 40));
                    Koordinates.PriesoIKaire.Add(new Rect(Canvas.GetLeft(r) + r.Width, Canvas.GetTop(r), 10, 40));
                    Koordinates.PriesoIVirsu.Add(new Rect(Canvas.GetLeft(r), Canvas.GetTop(r) + r.Height, 40, 10));
                    Koordinates.PriesoIApacia.Add(new Rect(Canvas.GetLeft(r), Canvas.GetTop(r) - 10, 40, 10));
                }
            }
        }

        public static void SukurtiPriesoRadara(double leftPriesas, double topPriesas, int i)
        {
            Koordinates.PriesoRadarai[i] = new Rect(leftPriesas - 130, topPriesas - 130, 300, 300);
        }

        public static void SukurtiPriesoRadarus(Canvas zemelapis)
        {
            foreach(Rectangle r in zemelapis.Children.OfType<Rectangle>())
            {
                if ((string)r.Tag == "Priesas")
                {
                    Koordinates.PriesoRadarai.Add(new Rect(Canvas.GetLeft(r) - 130, Canvas.GetTop(r) - 130, 300, 300));
                }
            }
        }
        public static void SukurtiPriesoPuolimoLauka(double leftPriesas, double topPriesas, int i)
        {
            Koordinates.PriesuPuolimoLaukai[i] = new Rect(leftPriesas - 15, topPriesas - 15, 70, 70);
        }
        public static void SukurtiPriesuPuolimoLaukus(Canvas zemelapis)
        {
            foreach (var r in zemelapis.Children.OfType<Rectangle>())
            {
                if ((string)r.Tag == "Priesas")
                {
                    Koordinates.PriesuPuolimoLaukai.Add(new Rect(Canvas.GetLeft(r) - 15, Canvas.GetTop(r) - 15, r.Width + 30, r.Height + 30));
                }
            }
        }
        public static bool PatikrintiArPriesasPasiekiaPult(Rect priesoLaukas)
        {
            if (priesoLaukas.IntersectsWith(Koordinates.ZaidejoRibos))
            {
                return true;
            }
            else return false;
        }

        public static void PatikrintiRadara(double leftPriesas, double topPriesas, int i)
        {
            if (Koordinates.PriesoRadarai[i].IntersectsWith(Koordinates.ZaidejoRibos))
            {
                Priesas.PriesuSarasasPriesas[i].goLeft = Koordinates.LeftZaidejas - leftPriesas > 0 ? false : true;
                Priesas.PriesuSarasasPriesas[i].goRight = Koordinates.LeftZaidejas - leftPriesas > 0 ? true : false;
                Priesas.PriesuSarasasPriesas[i].goTop = Koordinates.TopZaidejas - topPriesas > 0 ? false : true;
                Priesas.PriesuSarasasPriesas[i].goBottom = Koordinates.TopZaidejas - topPriesas > 0 ? true : false;
                Priesas.PriesuSarasasPriesas[i].JudejimoLaikas = 10;
                Priesas.PriesuSarasasPriesas[i].PriesoPuolimas = true;
            }
        }
        public static void PatikrintiRibas(Rect remas, List<Rect> IDesine, List<Rect> IApacia, List<Rect> IKaire, List<Rect> IVirsu)
        {
            foreach (Rect rx in IDesine)
            {
                if (remas.IntersectsWith(rx))
                {
                    Koordinates.IDesine = false;
                }
            }
            foreach (Rect rx in IApacia)
            {
                if (remas.IntersectsWith(rx))
                {
                    Koordinates.IApacia = false;
                }
            }
            foreach (Rect rx in IKaire)
            {
                if (remas.IntersectsWith(rx))
                {
                    Koordinates.IKaire = false;
                }
            }
            foreach (Rect rx in IVirsu)
            {
                if (remas.IntersectsWith(rx))
                {
                    Koordinates.IVirsu = false;
                }
            }
        }
        public static void PatikrintiRibasSuZaideju(Rect remas)
        {
            if (remas.IntersectsWith(Koordinates.ZaidejoIKaire))
            {
                Koordinates.IKaire = false;
            }
            if (remas.IntersectsWith(Koordinates.ZaidejoIDesine))
            {
                Koordinates.IDesine = false;
            }
            if (remas.IntersectsWith(Koordinates.ZaidejoIVirsu))
            {
                Koordinates.IVirsu = false;
            }
            if (remas.IntersectsWith(Koordinates.ZaidejoIApacia))
            {
                Koordinates.IApacia = false;
            }
        }
    }
}
