using System.Windows;

namespace Butybe
{
    public static class Zaidejas
    {
        public static double GyvybesTaskai { get; set; }
        public static double tempGyvybesTaskai { get; set; }
        public static double Jega { get; set; }
        public static double PuolimoLaikas { get; set; }
        public static double tempPuolimoLaikas { get; set; }
        public static double GyjimoLaikas { get; set; }
        public static double tempGyjimoLaikas { get; set; }
        public static double JudejimoGreitis { get; set; }

        public static void Pulti(Rect Remas)
        {
            foreach (Priesas p in Priesas.PriesuSarasasPriesas)
            {
                if (Remas.IntersectsWith(p.Remas))
                {
                    if (tempPuolimoLaikas == PuolimoLaikas)
                    {
                        p.GyvybesTaskai -= Jega;
                        tempPuolimoLaikas--;
                    }
                    else if (tempPuolimoLaikas == 0)
                    {
                        tempPuolimoLaikas = PuolimoLaikas;
                    }
                    else
                    {
                        tempPuolimoLaikas--;
                    }                        
                }
            }
        }

        public static void Gyti()
        {
            if (GyvybesTaskai < tempGyvybesTaskai)
            {
                if (tempGyjimoLaikas == GyjimoLaikas)
                {
                    GyvybesTaskai += 2;
                    tempGyjimoLaikas--;
                }
                else if (tempGyjimoLaikas == 0)
                {
                    tempGyjimoLaikas = GyjimoLaikas;
                }
                else
                {
                    tempGyjimoLaikas--;
                }
            }

        }
    }
}
