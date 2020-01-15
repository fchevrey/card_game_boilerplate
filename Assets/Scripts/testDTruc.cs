using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDTruc : MonoBehaviour
{
    Card card;
    Deck deck;
    // Start is called before the first frame update
    void Start()
    {
        //TestDeck();
        //Debug.Log("--- A   ----");
        //TestDeck();
    }
    private void TestDeck()
    {
        deck = new Deck(eDeckType.std54Card);
        int i = 0;
        while (deck.cardsRemains > 0)
        {
            Card card = deck.Draw();
            Debug.Log(++i + " " + card);
        }
        /*Debug.Log("card remains : " + deck.cardsRemains);
        PrintCard(deck.Draw());
        Debug.Log("card remains : " + deck.cardsRemains);
        PrintCard(deck.Draw());
        Debug.Log("card remains : " + deck.cardsRemains);
        PrintCard(deck.Draw());
        card = deck.Draw();
        PrintCard(card);
        Debug.Log("card remains : " + deck.cardsRemains);
        Debug.Log("card in discard : " + deck.cardsInDiscards);
        deck.Discard(card);
        Debug.Log("card in discard : " + deck.cardsInDiscards);
        deck.Burn();
        Debug.Log("card in discard : " + deck.cardsInDiscards);*/

    }
    private void TestCards()
    {
        Debug.Log("Create an ace of heart");
        card = new Card(eCardValue.Ace, eCardFaction.heart);
        PrintCard(card);
        Debug.Log("Create an two of Spade");
        card = new Card(eCardValue.two, eCardFaction.spade);
        PrintCard(card);
        Debug.Log("Create a five of Diamond");
        card = new Card(eCardId.fiveOfDiamond);
        PrintCard(card);
        Debug.Log("Create a joker");
        card = new Card(eCardId.joker);
        PrintCard(card);
    }
    private void PrintCard(Card card)
    {
        Debug.Log("Color " + card.color+ " fact : " + card.faction 
            + " val : " + card.cardValue + " id : " + card.cardId);
    }
}
