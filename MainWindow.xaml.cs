using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace esprogrammazioneasincrona
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Thread t1 = new Thread(InizioGiro);
            t1.Start();
        }
        
        string[] lettere = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

        public async void InizioGiro()
        {
            await Task.Run(() =>
            {
                int i = 0;
                while (true)
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        lblLettere.Content = lettere[i % 26].ToString(); //fa si che il contatore non superi mai 25
                    }));
                    i++;
                    Thread.Sleep(100);
                }

            });
            
        }
        private void btnLettera_Click(object sender, RoutedEventArgs e)
        {
            lblParole.Content=lblLettere.Content.ToString()+lblParole.Content.ToString(); //aggiorna il contenuto della labelparole aggiungendo ogni lettera
            if (lblParole.Content.ToString().Length == 6)
            {
                listaParole.Items.Add(lblParole.Content); //aggiunge la parola alla listbox
                lblParole.Content = "";

            }
        }
    }
}