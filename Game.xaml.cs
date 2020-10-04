using LaboratorioPOO_SantiagoVelasco.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
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
            foreach (Card c in p.Hand)
            {
                txtResultsPlayer.Text += c.Symbol + c.Suit + c.Score + " ";
            }
            int pointsPlayer = p.Check(p.Hand);
            txtScore.Text = pointsPlayer.ToString();
            foreach (Card k in d.Hand)
            {
                txtResultsDealer.Text += k.Symbol + k.Suit + k.Score + " ";
                break;
            }
            int points = p.Check(p.Hand);
            if (points == 21)
            {
                if (p.Hand.Count() == 2)
                {
                    MessageBox.Show("Blackjack" + "\n" + "You win");
                }
            }
        }

        private void btnCard_Click(object sender, RoutedEventArgs e)
        {
            d.Confirm(d.Deck);
            int points = p.Check(p.Hand);
            Card c = d.Deal();
            p.AddCard(c);
            txtResultsPlayer.Text += c.Symbol + c.Suit + c.Score + "  ";
            points += c.Score;
            if (points > 21)
            {
                foreach (Card j in p.Hand)
                {
                    if (j.Symbol == "A")
                    {
                        j.Score = 1;
                    }
                }
            }
            points = p.Check(p.Hand);
            txtScore.Text = points.ToString();
            if (points > 21)
            {
                btnCard.Visibility = Visibility.Hidden;
                btnNewGame.Visibility = Visibility.Visible;
                MessageBox.Show("You lose");
                txtResultsPlayer.Text = "";
                p.Hand.Clear();
                d.Hand.Clear();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int pointsPlayer = p.Check(p.Hand);
            int pointsDealer = d.Check(d.Hand);
            if(pointsDealer > pointsPlayer && pointsDealer > 16)
            {
                txtResultsDealer.Text = "";
                foreach (Card c in d.Hand)
                {
                    txtResultsDealer.Text += c.Symbol + c.Suit + c.Score + "  ";
                }
                MessageBox.Show("Dealer win");
            }
            else
            {
                while (pointsDealer < pointsPlayer)
                {
                    d.Confirm(d.Deck);
                    Card j = d.Deal();
                    d.AddCard(j);
                    txtResultsDealer.Text = "";
                    pointsDealer += j.Score;

                    if (pointsDealer > 21)
                    {
                        foreach (Card i in d.Hand)
                        {   
                            txtResultsDealer.Text += i.Symbol + i.Suit + i.Score + "  ";
                            if (i.Symbol == "A")
                            {
                                i.Score = 1;
                            }
                        }
                    }
                    pointsDealer = d.Check(d.Hand);
                    if(pointsDealer > 21)
                    {
                        MessageBox.Show("You win");
                    }
                }
                while (pointsDealer < 17)
                {
                    d.Confirm(d.Deck);
                    Card z = d.Deal();
                    d.AddCard(z);
                    txtResultsDealer.Text = "";
                    pointsDealer += z.Score;
                    foreach (Card c in d.Hand)
                    {
                        txtResultsDealer.Text += c.Symbol + c.Suit + c.Score + "  ";
                        if (pointsDealer > 21)
                        {
                            foreach (Card i in d.Hand)
                            {
                                if (i.Symbol == "A")
                                {
                                    i.Score = 1;
                                }
                            }
                        }
                        pointsDealer = d.Check(d.Hand);
                        if(pointsDealer > 21)
                        {
                            MessageBox.Show("You win");
                        }
                    }
                }
                if(pointsDealer < 22)
                {
                    txtResultsDealer.Text = "";
                    foreach (Card c in d.Hand)
                    {
                        txtResultsDealer.Text += c.Symbol + c.Suit + c.Score + "  ";
                    }
                    if (pointsDealer == pointsPlayer)
                    {
                        MessageBox.Show("Tie");
                    }
                    else
                    {
                        MessageBox.Show("You lose   " + pointsDealer + "   " + pointsPlayer);
                    }
                }
            }
            btnNewGame.Visibility = Visibility.Visible;
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            p.Hand.Clear();
            d.Hand.Clear();
            txtResultsDealer.Text = "";
            txtResultsPlayer.Text = "";
            txtScore.Text = "";
            d.Confirm(d.Deck);
            d.Init();
            p.Init(d.Deal(), d.Deal());
            int pointsPlayer = p.Check(p.Hand);
            txtScore.Text = pointsPlayer.ToString();
            btnNewGame.Visibility = Visibility.Hidden;
            btnCard.Visibility = Visibility.Visible;
            foreach (Card c in p.Hand)
            {
                txtResultsPlayer.Text += c.Symbol + c.Suit + c.Score + "  ";
            }
            foreach (Card k in d.Hand)
            {
                txtResultsDealer.Text += k.Symbol + k.Suit + k.Score + " ";
                break;
            }
            if (pointsPlayer == 21)
            {
                if (p.Hand.Count() == 2)
                {
                    MessageBox.Show("Blackjack" + "\n" + "You win");
                    txtResultsPlayer.Text = "";
                    txtResultsDealer.Text = "";
                    btnCard.Visibility = Visibility.Hidden;
                    btnSave.Visibility = Visibility.Hidden;
                    btnNewGame.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
