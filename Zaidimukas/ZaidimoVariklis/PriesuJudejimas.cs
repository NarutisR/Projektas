using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using Butybe;
using System.Diagnostics;

namespace ZaidimoVariklis
{
    public static class PriesuJudejimas
    {
        public static readonly Stopwatch Sw = new Stopwatch();
        /// <summary>
        /// Ir istrina susijusius objektus jei GyvybesTaskai < 0. 
        /// </summary>
        /// <param name="zemelapis">zemelapis</param>
        public static void PriesaiJuda(Canvas zemelapis)
        {
            for (int i = 0; i < Priesas.PriesuSarasasRectangle.Count;)
            {
                if (Priesas.PriesuSarasasPriesas[i].GyvybesTaskai > 0)
                {
                    PriesasJuda(Priesas.PriesuSarasasRectangle[i], i);
                    i++;
                }
                else
                {
                    zemelapis.Children.Remove(Priesas.PriesuSarasasRectangle[i]);
                    Priesas.PriesuSarasasPriesas.RemoveAt(i);
                    Priesas.PriesuSarasasRectangle.RemoveAt(i);
                    Koordinates.PriesoIKaire.RemoveAt(i);
                    Koordinates.PriesoIDesine.RemoveAt(i);
                    Koordinates.PriesoIVirsu.RemoveAt(i);
                    Koordinates.PriesoIApacia.RemoveAt(i);
                    Koordinates.PriesoRadarai.RemoveAt(i);
                    Koordinates.PriesuPuolimoLaukai.RemoveAt(i);
                }
            }
        }
        /// <summary>
        /// Priesas juda va ir va kaip.
        /// </summary>
        /// <param name="priesas">Prieso keturkampas</param>
        /// <param name="i">Kelintas sarase</param>
        private static void PriesasJuda(Rectangle priesas, int i)
        {

            //tempPuolimoLaikas = Priesas.PriesuSarasasPriesas[i].PuolimoLaikas;
            Koordinates.LeftPriesas = Canvas.GetLeft(priesas);
            Koordinates.TopPriesas = Canvas.GetTop(priesas);
            Priesas.PriesuSarasasPriesas[i].Remas = new Rect(Koordinates.LeftPriesas, Koordinates.TopPriesas, priesas.Width, priesas.Height);
            Ribos.PatikrintiRibas(Priesas.PriesuSarasasPriesas[i].Remas, Koordinates.RibosIDesine, Koordinates.RibosIApacia, Koordinates.RibosIKaire, Koordinates.RibosIVirsu);
            Ribos.PatikrintiRibasSuZaideju(Priesas.PriesuSarasasPriesas[i].Remas);
            Ribos.PatikrintiRadara(Koordinates.LeftPriesas, Koordinates.TopPriesas, i);
            if (Priesas.PriesuSarasasPriesas[i].PriesoPuolimas)
            {
                Priesas.PriesuSarasasPriesas[i].tempJudejimoGreitis = Priesas.PriesuSarasasPriesas[i].JudejimoGreitis * 2.1;
                if (Ribos.PatikrintiArPriesasPasiekiaPult(Koordinates.PriesuPuolimoLaukai[i]))
                {
                    Priesas.PriesuSarasasPriesas[i].Pulti();
                }
            }
            else
            {
                Priesas.PriesuSarasasPriesas[i].Gyti();
                Priesas.PriesuSarasasPriesas[i].tempJudejimoGreitis = Priesas.PriesuSarasasPriesas[i].JudejimoGreitis;
                Priesas.PriesuSarasasPriesas[i].tempPuolimoLaikas = Priesas.PriesuSarasasPriesas[i].PuolimoLaikas;
            }
            
            if (Priesas.PriesuSarasasPriesas[i].JudejimoLaikas > 0)
            {
                if (Priesas.PriesuSarasasPriesas[i].goLeft && Koordinates.IKaire && Koordinates.LeftPriesas > 8 + (Priesas.PriesuSarasasPriesas[i].tempJudejimoGreitis / 2))
                {
                    Canvas.SetLeft(priesas, Koordinates.LeftPriesas - Priesas.PriesuSarasasPriesas[i].tempJudejimoGreitis);
                    Priesas.PriesuSarasasPriesas[i].JudejimoLaikas -= 1;
                }
                if (Priesas.PriesuSarasasPriesas[i].goRight && Koordinates.IDesine && Koordinates.LeftPriesas < 4955 + (Priesas.PriesuSarasasPriesas[i].tempJudejimoGreitis / 2))
                {
                    Canvas.SetLeft(priesas, Koordinates.LeftPriesas + Priesas.PriesuSarasasPriesas[i].tempJudejimoGreitis);
                    Priesas.PriesuSarasasPriesas[i].JudejimoLaikas -= 1;
                }
                if (Priesas.PriesuSarasasPriesas[i].goTop && Koordinates.IVirsu && Koordinates.TopPriesas > 8 + (Priesas.PriesuSarasasPriesas[i].tempJudejimoGreitis / 2))
                {
                    Canvas.SetTop(priesas, Koordinates.TopPriesas - Priesas.PriesuSarasasPriesas[i].tempJudejimoGreitis);
                    Priesas.PriesuSarasasPriesas[i].JudejimoLaikas -= 1;
                }
                if (Priesas.PriesuSarasasPriesas[i].goBottom && Koordinates.IApacia && Koordinates.TopPriesas < 4955 + (Priesas.PriesuSarasasPriesas[i].tempJudejimoGreitis / 2))
                {
                    Canvas.SetTop(priesas, Koordinates.TopPriesas + Priesas.PriesuSarasasPriesas[i].tempJudejimoGreitis);
                    Priesas.PriesuSarasasPriesas[i].JudejimoLaikas -= 1;
                }
                if (!Priesas.PriesuSarasasPriesas[i].goLeft && !Priesas.PriesuSarasasPriesas[i].goRight && !Priesas.PriesuSarasasPriesas[i].goTop && !Priesas.PriesuSarasasPriesas[i].goBottom)
                {
                    Priesas.PriesuSarasasPriesas[i].JudejimoLaikas -= 1;
                }
                Priesas.PriesuSarasasPriesas[i].JudejimoLaikas -= 1;
            }
            else
            {
                SugeneruotKryptiLaika(Priesas.PriesuSarasasPriesas[i], i);
            }
            Ribos.SukurtiPriesoPuolimoLauka(Koordinates.LeftPriesas, Koordinates.TopPriesas, i);
            Ribos.SukurtiPriesoRadara(Koordinates.LeftPriesas, Koordinates.TopPriesas, i);
            Ribos.SukurtiPriesuRibasZaidejui(Koordinates.LeftPriesas, Koordinates.TopPriesas, priesas.Width, priesas.Height, i);
            Priesas.PriesuSarasasPriesas[i].PriesoPuolimas = false;
            Koordinates.IDesine = true;
            Koordinates.IApacia = true;
            Koordinates.IKaire = true;
            Koordinates.IVirsu = true;
        }
        private static void SugeneruotKryptiLaika(Priesas p, int i)
        {
            Random rnd = new Random((int)Sw.ElapsedTicks + i);
            p.JudejimoLaikas = rnd.Next(15, 80);
            int @case = rnd.Next(0, 15);
            switch (@case)
            {
                case 0:
                    p.goLeft = false;
                    p.goRight = false;
                    p.goTop = true;
                    p.goBottom = false;
                    break;
                case 1:
                    p.goLeft = false;
                    p.goRight = true;
                    p.goTop = true;
                    p.goBottom = false;
                    p.JudejimoLaikas *= 2;
                    break;
                case 2:
                    p.goLeft = false;
                    p.goRight = true;
                    p.goTop = false;
                    p.goBottom = false;
                    break;
                case 3:
                    p.goLeft = false;
                    p.goRight = true;
                    p.goTop = true;
                    p.goBottom = true;
                    p.JudejimoLaikas *= 2;
                    break;
                case 4:
                    p.goLeft = false;
                    p.goRight = false;
                    p.goTop = false;
                    p.goBottom = true;
                    break;
                case 5:
                    p.goLeft = true;
                    p.goRight = false;
                    p.goTop = false;
                    p.goBottom = true;
                    p.JudejimoLaikas *= 2;
                    break;
                case 6:
                    p.goLeft = true;
                    p.goRight = false;
                    p.goTop = false;
                    p.goBottom = false;
                    break;
                case 7:
                    p.goLeft = true;
                    p.goRight = false;
                    p.goTop = true;
                    p.goBottom = false;
                    p.JudejimoLaikas *= 2;
                    break;
                default:
                    p.goLeft = false;
                    p.goRight = false;
                    p.goTop = false;
                    p.goBottom = false;
                    p.JudejimoLaikas *= 5;
                    break;
            }
        }
    }
}
