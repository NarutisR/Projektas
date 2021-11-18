using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;

namespace Butybe
{
    public class Priesas : Butybe
    {
        public bool goLeft, goRight, goTop, goBottom;
        public bool PriesoPuolimas = false;

        public static List<Priesas> PriesuSarasasPriesas = new List<Priesas>();
        public static List<Rectangle> PriesuSarasasRectangle = new List<Rectangle>();


        public Rect Remas;
        public int JudejimoLaikas { get; set; }
        public double tempJudejimoGreitis { get; set; }

        public double tempGyvybesTaskai { get; set; }
        public double GyjimoLaikas { get; set; }
        public double tempGyjimoLaikas { get; set; }
        public Priesas(double GyvybesTaskai, double Jega, double PuolimoLaikas, double JudejimoGreitis, double GyjimoLaikas)
        {
            this.GyvybesTaskai = GyvybesTaskai;
            tempGyvybesTaskai = GyvybesTaskai;
            this.Jega = Jega;
            this.JudejimoGreitis = JudejimoGreitis;
            this.PuolimoLaikas = PuolimoLaikas;
            this.GyjimoLaikas = GyjimoLaikas;
        }
        
        public void Pulti()
        {
            if(tempPuolimoLaikas == PuolimoLaikas)
            {
                Zaidejas.GyvybesTaskai -= Jega;
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

        public void Gyti()
        {
            if(GyvybesTaskai < tempGyvybesTaskai)
            {
                if (tempGyjimoLaikas == GyjimoLaikas)
                {
                    GyvybesTaskai += 1;
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
