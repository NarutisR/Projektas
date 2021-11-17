using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;

namespace Butybe
{
    public class Priesas : Butybe
    {
        public bool goLeft, goRight, goTop, goBottom;
        public static List<Priesas> PriesuSarasasPriesas = new List<Priesas>();
        public static List<Rectangle> PriesuSarasasRectangle = new List<Rectangle>();

        public Rect Remas;
        //Random rnd = new Random();
        public int JudejimoLaikas { get; set; }
        public Priesas(double GyvybesTaskai, double Jega, double JudejimoGreitis) : base(GyvybesTaskai, Jega, JudejimoGreitis)
        {
            this.GyvybesTaskai = GyvybesTaskai;
            this.Jega = Jega;
            this.JudejimoGreitis = JudejimoGreitis;
        }
    }
}
