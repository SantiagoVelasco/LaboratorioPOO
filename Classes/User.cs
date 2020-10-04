using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioPOO_SantiagoVelasco.Classes
{
    public class User
    {
        private List<Card> hand;

        public User()
        {
            this.hand = new List<Card>();
        }

        public List<Card> Hand { get => hand; set => hand = value; }

        public void AddCard(Card c)
        {
            Hand.Add(c);
        }

        public int Check(List<Card> cartas)
        {
            int points = 0;
            foreach(Card c in cartas)
            {
                points += c.Score;
            }
            return points;
        }
    }
}
