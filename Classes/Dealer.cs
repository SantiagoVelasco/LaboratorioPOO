using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaboratorioPOO_SantiagoVelasco.Classes
{
    public class Dealer : User
    {
        private List<Card> deck;

        public List<Card> Deck { get => deck; set => deck = value; }

        public void Generate()
        {
            string[] cards = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            char[] type = { '♥', '♦', '♣', '♠' };

            deck = new List<Card>();

            for (int i = 0; i < type.Length; i++)
            {
                for (int j = 0; j < cards.Length; j++)
                {
                    Card c = new Card(type[i], cards[j]);
                    deck.Add(c);
                }
            }
        }

        public void Randomize()
        {
            Random n = new Random();
            int pos;
            Card w;
            for(int i = 0; i < 52; i++)
            {
                pos = n.Next(51);

                w = deck[i];
                deck[i] = deck[pos];
                deck[pos] = w;
            }
        }

        public Card Deal()
        {
            Card  c = this.deck.First();
            deck.Remove(c);
            return c;
        }

        public void Init()
        {
            AddCard(Deal());
            AddCard(Deal());
        }
    }
}
