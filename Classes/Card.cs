using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioPOO_SantiagoVelasco.Classes
{
    public class Card
    {
        private char suit;
        private string symbol;
        private int score;
        private string color;

        public Card(char suit, string symbol)
        {
            this.suit = suit;
            this.symbol = symbol;

            int value = 0;

            if (symbol == "Q" || symbol == "K" || symbol == "J")
            {
                value += 10;
            }
            else
            {
                if (symbol == "A")
                {
                    value += 1;
                }
                else
                {
                    value = value + int.Parse(symbol);
                }
            }
            this.score = value;

            if (suit == '♥' || suit == '♦')
            {
                this.color = "red";
            }
            else
            {
                this.color = "black";
            }
        }

        public char Suit { get => suit; set => suit = value; }
        public string Symbol { get => symbol; set => symbol = value; }
        public int Score { get => score; set => score = value; }
        public string Color { get => color; set => color = value; }
    }
}
