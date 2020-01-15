using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public CardDisplayer[] cardDisplayers = new CardDisplayer[5];
    Deck deck;
    [SerializeField] private CardSet cardset;
    void Start()
    {
        deck = new Deck(eDeckType.std54Card);
        var lst = deck.Draw(5);
        int i = 0;
        foreach (Card card in lst)
        {
            Debug.Log("Draw " + card.cardId);
            card.sprite = cardset.set[card.cardId];
            cardDisplayers[i++].ChangeCard(card);
        }
    }
}
