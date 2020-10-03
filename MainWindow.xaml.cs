using LaboratorioPOO_SantiagoVelasco.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaboratorioPOO_SantiagoVelasco
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dealer d;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAction_Click(object sender, RoutedEventArgs e)
        {
            d = new Dealer();
            d.Generate();
            d.Randomize();
            foreach (Card c in d.Deck)
            {
                txtResult.Text += c.Symbol + c.Suit + "  ";
            }
        }

        private void btnDealer_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = "";
            d.Init();
            foreach(Card c in d.Hand)
            {
                txtResult.Text += c.Symbol + c.Suit + "\n";
            }
        }
    }
}
