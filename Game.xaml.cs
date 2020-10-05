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
        int victories = 0;
        int defeat = 0;
        int tie = 0;
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
                txtResultsPlayer.Text += c.Symbol + c.Suit + "  ";
            }
            int pointsPlayer = p.Check(p.Hand);
            txtScore.Text = pointsPlayer.ToString();
            foreach (Card k in d.Hand)
            {
                txtResultsDealer.Text += k.Symbol + k.Suit + "  ";
                break;
            }
            int points = p.Check(p.Hand);
            if (points == 21)
            {
                if (p.Hand.Count() == 2)
                {
                    MessageBox.Show("Blackjack" + "\n" + "You win");
                    victories += 1;
                    btnSave.Visibility = Visibility.Hidden;
                    btnCard.Visibility = Visibility.Hidden;
                    btnNewGame.Visibility = Visibility.Visible;
                    btnFinish.Visibility = Visibility.Visible;
                }
            }
        }

        private void btnCard_Click(object sender, RoutedEventArgs e)
        {
            d.Confirm(d.Deck);
            int points = p.Check(p.Hand);
            Card c = d.Deal();
            p.AddCard(c);
            txtResultsPlayer.Text += c.Symbol + c.Suit + "  ";
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
                btnSave.Visibility = Visibility.Hidden;
                btnNewGame.Visibility = Visibility.Visible;
                btnFinish.Visibility = Visibility.Visible;
                MessageBox.Show("You lose");
                defeat += 1;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            btnSave.Visibility = Visibility.Hidden;
            btnCard.Visibility = Visibility.Hidden;
            int pointsPlayer = p.Check(p.Hand);
            int pointsDealer = d.Check(d.Hand);
            if(pointsDealer > pointsPlayer && pointsDealer > 16)
            {
                txtResultsDealer.Text = "";
                foreach (Card c in d.Hand)
                {
                    txtResultsDealer.Text += c.Symbol + c.Suit + "  ";
                }
                MessageBox.Show("Dealer win");
                defeat += 1;
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
                            txtResultsDealer.Text += i.Symbol + i.Suit + "  ";
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
                        victories += 1;
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
                        txtResultsDealer.Text += c.Symbol + c.Suit + "  ";
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
                    }
                    pointsDealer = d.Check(d.Hand);
                    if(pointsDealer > 21)
                    {
                        MessageBox.Show("You win");
                        victories += 1;
                    }
                }
                if(pointsDealer < 22)
                {
                    txtResultsDealer.Text = "";
                    foreach (Card c in d.Hand)
                    {
                        txtResultsDealer.Text += c.Symbol + c.Suit + "  ";
                    }
                    if (pointsDealer == pointsPlayer)
                    {
                        MessageBox.Show("Tie");
                        tie += 1;
                    }
                    else
                    {
                        MessageBox.Show("You lose");
                        defeat += 1;
                    }
                }
            }
            btnNewGame.Visibility = Visibility.Visible;
            btnFinish.Visibility = Visibility.Visible;
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
            btnFinish.Visibility = Visibility.Hidden;
            btnCard.Visibility = Visibility.Visible;
            btnSave.Visibility = Visibility.Visible;
            foreach (Card c in p.Hand)
            {
                txtResultsPlayer.Text += c.Symbol + c.Suit + "  ";
            }
            foreach (Card k in d.Hand)
            {
                txtResultsDealer.Text += k.Symbol + k.Suit + "  ";
                break;
            }
            if (pointsPlayer == 21)
            {
                if (p.Hand.Count() == 2)
                {
                    MessageBox.Show("Blackjack" + "\n" + "You win");
                    btnCard.Visibility = Visibility.Hidden;
                    btnSave.Visibility = Visibility.Hidden;
                    btnNewGame.Visibility = Visibility.Visible;
                    btnFinish.Visibility = Visibility.Visible;
                }
            }
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            txtDealerCards.Text = "";
            txtPlayerCards.Text = "";
            txtResultsDealer.Visibility = Visibility.Hidden;
            txtResultsPlayer.Visibility = Visibility.Hidden;
            txtScore.TextAlignment = TextAlignment.Left;
            txtScore.Text = "Victories: " + victories.ToString() + "\n" + "Defeats: " + defeat.ToString() +"\n" + "Ties: " + tie.ToString();
            btnNewGame.Visibility = Visibility.Hidden;
            btnFinish.Visibility = Visibility.Hidden;
        }
    }
}
