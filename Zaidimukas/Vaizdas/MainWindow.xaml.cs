using System.Windows;
using System.Windows.Input;
using System.Timers;
using System.Windows.Threading;
using ZaidimoVariklis;

namespace Vaizdas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Timer _time = new Timer(15);
        //private List<Rectangle> istrinimui = new List<Rectangle>();
        public MainWindow()
        {
            InitializeComponent();
            Objektai.SukurtiPriesus(Zemelapis, 60, 5, 3);
            Ribos.SukurtiRibas(Zemelapis);
            Ribos.SukurtiPriesuRibasZaidejuiVienaKarta(Zemelapis);
            Butybe.Zaidejas.Jega = 5;
            _time.Elapsed += (s, e) => ZaidimoLaikas();
            _time.Start();
        }

        private void ZaidimoLaikas()
        {
            _ = Dispatcher.InvokeAsync(() =>
              {
                  PriesuJudejimas.Sw.Restart();
                  ZaidejoJudejimas.ZaidejasJuda(Zaidejas, Zemelapis, Kryptis);
                  PriesuJudejimas.PriesaiJuda(Zemelapis);
                  Tekstas.Content = $"x: {Koordinates.LeftZaidejas:0.0} y: {Koordinates.TopZaidejas:0.0} \n x :{Koordinates.Thick.Left:0.0} y :{Koordinates.Thick.Top:0.0}" +
                  $"\n IKaire: {Koordinates.ZaidejoKryptisIKaire}\n IDesine: {Koordinates.ZaidejoKryptisIDesine}\n IVirsu: {Koordinates.ZaidejoKryptisIVirsu}\n IApacia: {Koordinates.ZaidejoKryptisIApacia}";
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
