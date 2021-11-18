namespace Butybe
{
    public class Butybe
    {
        public double GyvybesTaskai { get; set; }
        public double Jega { get; set; }
        public double PuolimoLaikas { get; set; }
        public double tempPuolimoLaikas { get; set; }
        public double JudejimoGreitis { get; set; }

        //public Butybe(double GyvybesTaskai, double Jega, double JudejimoGreitis)
        //{
        //}
        public void Puola(Butybe b)
        {
            b.GyvybesTaskai -= Jega;
        }
    }
}
