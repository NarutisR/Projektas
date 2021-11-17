using System.Windows;

namespace Butybe
{
    public static class Zaidejas
    {
        public static double GyvybesTaskai { get; set; }
        public static double Jega { get; set; }
        public static double PuolimoGreitis { get; set; }
        public static double JudejimoGreitis { get; set; }

        public static void Pulti(Rect Remas)
        {
            foreach (Priesas p in Priesas.PriesuSarasasPriesas)
            {
                if (Remas.IntersectsWith(p.Remas))
                {
                    p.GyvybesTaskai -= Jega;
                }
            }
        }
    }
}
