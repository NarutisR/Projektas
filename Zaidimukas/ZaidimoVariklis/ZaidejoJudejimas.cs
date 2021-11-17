using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using Butybe;



namespace ZaidimoVariklis
{
    public static class ZaidejoJudejimas
    {
        public static bool Pulti;
        public static double JudejimoGreitis = 2.5;

        public static void ZaidejasJuda(Ellipse zaidejas, Canvas zemelapis, Rectangle kryptis)
        {
            Koordinates.LeftZaidejas = Canvas.GetLeft(zaidejas);
            Koordinates.TopZaidejas = Canvas.GetTop(zaidejas);
            Koordinates.ZaidejoRibos = new Rect(Koordinates.LeftZaidejas, Koordinates.TopZaidejas, zaidejas.Width, zaidejas.Height);

            Ribos.PatikrintiRibas(Koordinates.ZaidejoRibos, Koordinates.RibosIDesine, Koordinates.RibosIApacia, Koordinates.RibosIKaire, Koordinates.RibosIVirsu);
            Ribos.PatikrintiRibas(Koordinates.ZaidejoRibos, Koordinates.PriesoIDesine, Koordinates.PriesoIApacia, Koordinates.PriesoIKaire, Koordinates.PriesoIVirsu);

            if (Koordinates.GoLeft && !Koordinates.GoRight && Koordinates.IKaire && Koordinates.LeftZaidejas > 8 + (JudejimoGreitis / 2))
            {
                Canvas.SetLeft(zaidejas, Koordinates.LeftZaidejas - JudejimoGreitis);
                Koordinates.Thick.Left = -Koordinates.LeftZaidejas + 370 + JudejimoGreitis;
                zemelapis.Margin = Koordinates.Thick;
            }
            if (Koordinates.GoRight && !Koordinates.GoLeft && Koordinates.IDesine && Koordinates.LeftZaidejas < 4955 - (JudejimoGreitis / 2))
            {
                Canvas.SetLeft(zaidejas, Koordinates.LeftZaidejas + JudejimoGreitis);
                Koordinates.Thick.Left = -Koordinates.LeftZaidejas + 370 - JudejimoGreitis;
                zemelapis.Margin = Koordinates.Thick;
            }
            if (Koordinates.GoTop && !Koordinates.GoBottom && Koordinates.IVirsu && Koordinates.TopZaidejas > 8 + (JudejimoGreitis / 2))
            {
                Canvas.SetTop(zaidejas, Koordinates.TopZaidejas - JudejimoGreitis);
                Koordinates.Thick.Top = -Koordinates.TopZaidejas + 270 + JudejimoGreitis;
                zemelapis.Margin = Koordinates.Thick;
            }
            if (Koordinates.GoBottom && !Koordinates.GoTop && Koordinates.IApacia && Koordinates.TopZaidejas < 4955 - (JudejimoGreitis / 2))
            {
                Canvas.SetTop(zaidejas, Koordinates.TopZaidejas + JudejimoGreitis);
                Koordinates.Thick.Top = -Koordinates.TopZaidejas + 270 - JudejimoGreitis;
                zemelapis.Margin = Koordinates.Thick;
            }
            if (Pulti)
            {
                Zaidejas.Pulti(Koordinates.KryptiesRibos);
            }
            Koordinates.Kryptis();
            KeistiKrypti(kryptis);
            Ribos.SukurtiZaidejoRibasPriesams(zaidejas);
            Koordinates.IDesine = true;
            Koordinates.IApacia = true;
            Koordinates.IKaire = true;
            Koordinates.IVirsu = true;
        }

        public static void KeistiKrypti(Rectangle krpts)
        {
            Panel.SetZIndex(krpts, 3);
            if (Koordinates.ZaidejoKryptisIVirsu && !Koordinates.ZaidejoKryptisIKaire && !Koordinates.ZaidejoKryptisIDesine)
            {
                Canvas.SetLeft(krpts, Koordinates.LeftZaidejas + 15);
                Canvas.SetTop(krpts, Koordinates.TopZaidejas - 15);
            }
            if (Koordinates.ZaidejoKryptisIVirsu && Koordinates.ZaidejoKryptisIDesine)
            {
                Canvas.SetLeft(krpts, Koordinates.LeftZaidejas + 40);
                Canvas.SetTop(krpts, Koordinates.TopZaidejas - 10);
            }
            if (Koordinates.ZaidejoKryptisIDesine && !Koordinates.ZaidejoKryptisIVirsu && !Koordinates.ZaidejoKryptisIApacia)
            {
                Canvas.SetLeft(krpts, Koordinates.LeftZaidejas + 45);
                Canvas.SetTop(krpts, Koordinates.TopZaidejas + 15);
            }
            if (Koordinates.ZaidejoKryptisIDesine && Koordinates.ZaidejoKryptisIApacia)
            {
                Canvas.SetLeft(krpts, Koordinates.LeftZaidejas + 40);
                Canvas.SetTop(krpts, Koordinates.TopZaidejas + 40);
            }
            if (Koordinates.ZaidejoKryptisIApacia && !Koordinates.ZaidejoKryptisIDesine && !Koordinates.ZaidejoKryptisIKaire)
            {
                Canvas.SetLeft(krpts, Koordinates.LeftZaidejas + 15);
                Canvas.SetTop(krpts, Koordinates.TopZaidejas + 45);
            }
            if (Koordinates.ZaidejoKryptisIApacia && Koordinates.ZaidejoKryptisIKaire)
            {
                Canvas.SetLeft(krpts, Koordinates.LeftZaidejas - 10);
                Canvas.SetTop(krpts, Koordinates.TopZaidejas + 40);
            }
            if (Koordinates.ZaidejoKryptisIKaire && !Koordinates.ZaidejoKryptisIApacia && !Koordinates.ZaidejoKryptisIVirsu)
            {
                Canvas.SetLeft(krpts, Koordinates.LeftZaidejas - 15);
                Canvas.SetTop(krpts, Koordinates.TopZaidejas + 15);
            }
            if (Koordinates.ZaidejoKryptisIKaire && Koordinates.ZaidejoKryptisIVirsu)
            {
                Canvas.SetLeft(krpts, Koordinates.LeftZaidejas - 10);
                Canvas.SetTop(krpts, Koordinates.TopZaidejas - 10);
            }
            Koordinates.KryptiesRibos = new Rect(Canvas.GetLeft(krpts), Canvas.GetTop(krpts), krpts.Width, krpts.Height);
        }
    }
}
