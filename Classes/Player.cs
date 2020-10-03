using System;
using System.Collections.Generic;
using System.Text;

namespace LaboratorioPOO_SantiagoVelasco.Classes
{
    public class Player : User
    {
        public void Init(Card c1, Card c2)
        {
            AddCard(c1);
            AddCard(c2);
        }
    }
}
