using System.Windows;
using System.Windows.Input;
using System.Timers;
using System.Windows.Threading;
using System.Windows.Controls;
using ZaidimoVariklis;

namespace Vaizdas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool Restart = false;
        private readonly Timer _time = new Timer(15);
        
        public MainWindow()
        {
            InitializeComponent();
            NustatytiZaideja();
            Objektai.SukurtiPriesus(Zemelapis, 60, 4, 30, 0.75, 80);
            Ribos.SukurtiPriesoRadarus(Zemelapis);
            Ribos.SukurtiPriesuPuolimoLaukus(Zemelapis);
            Ribos.SukurtiRibas(Zemelapis);
            Ribos.SukurtiPriesuRibasZaidejuiVienaKarta(Zemelapis);

            _time.Elapsed += (s, e) => ZaidimoLaikas();
            _time.Start();
            
        }

        private void NustatytiZaideja()
        {
            Canvas.SetLeft(Zaidejas, 370);
            Canvas.SetTop(Zaidejas, 270);
            Koordinates.Thick.Left = 0;
            Koordinates.Thick.Top = 0;
            Zemelapis.Margin = Koordinates.Thick;
            Butybe.Zaidejas.GyvybesTaskai = 150;
            Butybe.Zaidejas.tempGyvybesTaskai = 150;
            Butybe.Zaidejas.GyjimoLaikas = 90;
            Butybe.Zaidejas.JudejimoGreitis = 2.5;
            Butybe.Zaidejas.Jega = 15;
            Butybe.Zaidejas.PuolimoLaikas = 20;
        }
        private void ZaidimoPradzia()
        {
            NustatytiZaideja();
            _time.Start();
        }

        private void ZaidimoLaikas()
        {
            _ = Dispatcher.InvokeAsync(() =>
              {
                  if(ZaidejoJudejimas.Restart == true)
                  {
                      _time.Stop();
                      MessageBox.Show("Zaidimo Pabaiga.");
                      ZaidimoPradzia();
                      ZaidejoJudejimas.Restart = false;
                  }
                  PriesuJudejimas.Sw.Restart();
                  ZaidejoJudejimas.ZaidejasJuda(Zaidejas, Zemelapis, Kryptis);
                  PriesuJudejimas.PriesaiJuda(Zemelapis);
                  Tekstas.Content = $"x: {Koordinates.LeftZaidejas:0.0} y: {Koordinates.TopZaidejas:0.0} \n x :{Koordinates.Thick.Left:0.0} y :{Koordinates.Thick.Top:0.0}" +
                  $"\n IKaire: {Koordinates.ZaidejoKryptisIKaire}\n IDesine: {Koordinates.ZaidejoKryptisIDesine}\n IVirsu: {Koordinates.ZaidejoKryptisIVirsu}\n IApacia: {Koordinates.ZaidejoKryptisIApacia}" +
                  $"\n Gyv. T.: {Butybe.Zaidejas.GyvybesTaskai}";
              });
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.A:
                    Koordinates.GoLeft = true;
                    break;
                case Key.D:
                    Koordinates.GoRight = true;
                    break;
                case Key.W:
                    Koordinates.GoTop = true;
                    break;
                case Key.S:
                    Koordinates.GoBottom = true;
                    break;
                case Key.Space:
                    ZaidejoJudejimas.Pulti = true;
                    break;
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.A:
                    Koordinates.GoLeft = false;
                    break;
                case Key.D:
                    Koordinates.GoRight = false;
                    break;
                case Key.W:
                    Koordinates.GoTop = false;
                    break;
                case Key.S:
                    Koordinates.GoBottom = false;
                    break;
                case Key.Space:
                    ZaidejoJudejimas.Pulti = false;
                    break;
            }
        }
    }
}
