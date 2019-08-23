using Laboratorio_2_OOP_201902.Card;
using System;
using System.Collections.Generic;
using System.Text;

namespace Laboratorio_2_OOP_201902
{
    public class Board
    {
        //Constantes
        private const int DEFAULT_NUMBER_OF_PLAYERS = 2;

        //Atributos
        private Dictionary<string, List<Card.Card>>[] playerCards;

        private List<SpecialCard> weatherCards;

        //Propiedades
        public Dictionary<string, List<Card.Card>>[] PlayerCards
        {
            get
            {
                return this.playerCards;
            }
        }


        public List<SpecialCard> WeatherCards
        {
            get
            {
                return this.weatherCards;
            }
        }


        //Constructor
        public Board()
        {
            this.playerCards = new Dictionary<string, List<Card.Card>>[DEFAULT_NUMBER_OF_PLAYERS];
            this.weatherCards = new List<SpecialCard>();
        }



        //Metodos

        public void AddCard(Card.Card card, int playerId = -1, string buffType = null)
        {
            if (card.GetType().Name == nameof(CombatCard))
            {
                if (playerId == 0 || playerId == 1)
                {
                    if (playerCards[playerId].ContainsKey(card.Type))
                    {
                        playerCards[playerId][card.Type].Add(card);
                    }
                    else
                    {
                        playerCards[playerId].Add(card.Type, new List<Card.Card>() { card });
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException("No player id given");
                }
            }
            else if (card.GetType().Name == nameof(SpecialCard))
            {
                if (playerId == 0 || playerId == 1)
                {
                    if (playerCards[playerId].ContainsKey(card.Type))
                    {
                        playerCards[playerId][card.Type].Add(card);
                    }
                    else
                    {
                        playerCards[playerId].Add(card.Type, new List<Card.Card>() { card });
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException("No player id given");
                }

            }
        }


        public void DestroyCards()
        {
            List<Card.Card>[] captainCards = new List<Card.Card>[DEFAULT_NUMBER_OF_PLAYERS] { new List<Card.Card>(playerCards[0]["captain"]), new List<Card.Card>(playerCards[1]["captain"]) };
            this.playerCards = new Dictionary<string, List<Card.Card>>[DEFAULT_NUMBER_OF_PLAYERS];

            foreach (List<Card.Card> captain in captainCards)
            {
                this.playerCards[DEFAULT_NUMBER_OF_PLAYERS].Add("captain", captain);
            }
        }
        public void DestroyWeatherCards()
        {
            this.weatherCards = new List<SpecialCard>();
        }
        public int[] GetAttackPoints()
        {

            //Debe sumar todos los puntos de ataque de las cartas melee y retornar los valores por jugador.
            int[] totalAttack = new int[] { 0, 0 };
            for (int i=0; i < 2; i++)
            {
                if (playerCards[i].ContainsKey("melee"))
                {
                    foreach (CombatCard meleeCard in playerCards[i]["melee"])
                    {
                        totalAttack[i] += meleeCard.AttackPoints;
                    }

                }
                else if (playerCards[i].ContainsKey("range"))
                {
                    foreach (CombatCard meleeCard in playerCards[i]["range"])
                    {
                        totalAttack[i] += meleeCard.AttackPoints;
                    }
                }
                else if (playerCards[i].ContainsKey("longrange"))
                {
                    foreach (CombatCard meleeCard in playerCards[i]["longrange"])
                    {
                        totalAttack[i] += meleeCard.AttackPoints;
                    }
                }

            }
            return totalAttack;
            
        }
    }
}
