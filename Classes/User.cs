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
    }
}
