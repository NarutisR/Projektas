using System.Collections.Generic;
using System.Windows;

namespace ZaidimoVariklis
{
    public struct Koordinates
    {
        public static bool GoLeft, GoRight, GoTop, GoBottom;

        public static List<Rect> RibosIDesine = new List<Rect>();
        public static List<Rect> RibosIApacia = new List<Rect>();
        public static List<Rect> RibosIKaire = new List<Rect>();
        public static List<Rect> RibosIVirsu = new List<Rect>();

        public static List<Rect> PriesoIKaire = new List<Rect>();
        public static List<Rect> PriesoIDesine = new List<Rect>();
        public static List<Rect> PriesoIVirsu = new List<Rect>();
        public static List<Rect> PriesoIApacia = new List<Rect>();

        public static double LeftZaidejas, TopZaidejas;
        public static double LeftPriesas, TopPriesas;

        public static bool IKaire = true;
        public static bool IDesine = true;
        public static bool IVirsu = true;
        public static bool IApacia = true;

        public static bool ZaidejoKryptisIDesine, ZaidejoKryptisIKaire, ZaidejoKryptisIVirsu, ZaidejoKryptisIApacia;

        public static Rect ZaidejoRibos;
        public static Rect ZaidejoIKaire;
        public static Rect ZaidejoIDesine;
        public static Rect ZaidejoIVirsu;
        public static Rect ZaidejoIApacia;

        public static Rect KryptiesRibos;

        public static Thickness Thick = new Thickness(0, 0, 0, 0);

        public static void Kryptis()
        {
            if (GoTop && !GoLeft && !GoRight)
            {
                ZaidejoKryptisIKaire = false;
                ZaidejoKryptisIDesine = false;
                ZaidejoKryptisIVirsu = true;
                ZaidejoKryptisIApacia = false;
            }
            if (GoTop && GoRight)
            {
                ZaidejoKryptisIKaire = false;
                ZaidejoKryptisIDesine = true;
                ZaidejoKryptisIVirsu = true;
                ZaidejoKryptisIApacia = false;
            }
            if (GoRight && !GoTop && !GoBottom)
            {
                ZaidejoKryptisIKaire = false;
                ZaidejoKryptisIDesine = true;
                ZaidejoKryptisIVirsu = false;
                ZaidejoKryptisIApacia = false;
            }
            if (GoRight && GoBottom)
            {
                ZaidejoKryptisIKaire = false;
                ZaidejoKryptisIDesine = true;
                ZaidejoKryptisIVirsu = false;
                ZaidejoKryptisIApacia = true;
            }
            if (GoBottom && !GoRight && !GoLeft)
            {
                ZaidejoKryptisIKaire = false;
                ZaidejoKryptisIDesine = false;
                ZaidejoKryptisIVirsu = false;
                ZaidejoKryptisIApacia = true;
            }
            if (GoBottom && GoLeft)
            {
                ZaidejoKryptisIKaire = true;
                ZaidejoKryptisIDesine = false;
                ZaidejoKryptisIVirsu = false;
                ZaidejoKryptisIApacia = true;
            }
            if (GoLeft && !GoTop && !GoBottom)
            {
                ZaidejoKryptisIKaire = true;
                ZaidejoKryptisIDesine = false;
                ZaidejoKryptisIVirsu = false;
                ZaidejoKryptisIApacia = false;
            }
            if (GoLeft && GoTop)
            {
                ZaidejoKryptisIKaire = true;
                ZaidejoKryptisIDesine = false;
                ZaidejoKryptisIVirsu = true;
                ZaidejoKryptisIApacia = false;
            }
        }
    }
}
