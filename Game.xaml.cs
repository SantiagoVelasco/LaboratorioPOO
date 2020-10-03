using LaboratorioPOO_SantiagoVelasco.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LaboratorioPOO_SantiagoVelasco
{
    /// <summary>
    /// Lógica de interacción para Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        Dealer d = new Dealer();
        Player p = new Player();
        public Game()
        {
            InitializeComponent();
        }

        private void btnShuffle_Click(object sender, RoutedEventArgs e)
        {
            btnShuffle.Visibility = Visibility.Hidden;
            btnCard.Visibility = Visibility.Visible;
            btnSave.Visibility = Visibility.Visible;
            d.Generate();
            d.Randomize();
            d.Init();
            Card c1 = d.Deal();
            Card c2 = d.Deal();
            p.Init(c1, c2);
            foreach(Card c in p.Hand)
            {
                txtResultsPlayer.Text += c.Symbol + c.Suit + c.Score + " ";
            }
        }

        private void btnCard_Click(object sender, RoutedEventArgs e)
        {
            int points = 0;
            foreach(Card k in p.Hand)
            {
                points += k.Score;
            }
            Card c = d.Deal();
            p.AddCard(c);
            txtResultsPlayer.Text += c.Symbol + c.Suit  + c.Score + "  ";
            points += c.Score;            
            if(points > 21)
            {   
                btnCard.Visibility = Visibility.Hidden;
                btnShuffle.Visibility = Visibility.Visible;
                MessageBox.Show("You lose");
                txtResultsPlayer.Text = "";
                p.Hand.Clear();
                d.Hand.Clear();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int pointsPlayer = 0;
            foreach(Card k in p.Hand)
            {
                pointsPlayer += k.Score;
            }
            int pointsDealer = 0;
            foreach(Card c in d.Hand)
            {
                pointsDealer += c.Score;
                txtResultsDealer.Text += c.Symbol + c.Suit + "  ";
            }
            if(pointsDealer > pointsPlayer && pointsDealer > 16)
            {
                MessageBox.Show("Dealer win");
            }
            else
            {
                while(pointsDealer < pointsPlayer)
                {
                    Card j = d.Deal();
                    d.AddCard(j);
                    txtResultsDealer.Text = "";
                    pointsDealer += j.Score;
                    foreach(Card c in d.Hand)
                    {
                        txtResultsDealer.Text += c.Symbol + c.Suit + c.Score + "  ";
                    }
                }
                while(pointsDealer < 17)
                {
                    Card j = d.Deal();
                    d.AddCard(j);
                    txtResultsDealer.Text = "";
                    pointsDealer += j.Score;
                    foreach(Card c in d.Hand)
                    {
                        txtResultsDealer.Text += c.Symbol + c.Suit + c.Score + "  ";
                    }
                }
                if (pointsDealer > 21)
                {
                    MessageBox.Show("You win");
                }
                else
                {
                    if(pointsDealer == pointsPlayer)
                    {
                        MessageBox.Show("Tie");
                    }
                    else
                    {
                        MessageBox.Show("You lose   " + pointsDealer + "   " + pointsPlayer);
                    }
                }
            }
        }
    }
}
