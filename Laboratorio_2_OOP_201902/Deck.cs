using Laboratorio_2_OOP_201902.Card;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_2_OOP_201902
{
    public class Deck
    {
        
        private List<Card.Card> cards;

        public Deck()
        {

        }

        public List<Card.Card> Cards { get => cards; set => cards = value; }

        public void AddCard(CombatCard combatCard)
        {
            cards.Add(combatCard);
        }
        public void DestroyCard(int cardId)
        {
            cards.RemoveAt(cardId);       
        }
        public void Shuffle()
        { 
            throw new NotImplementedException();
        }
    }
}
