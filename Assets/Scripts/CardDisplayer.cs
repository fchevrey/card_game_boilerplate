using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplayer : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer render;
    private Collider2D _col;
    public Card card { get; protected set; }
    Deck deck;
    // Start is called before the first frame update
    void OnEnabled()
    {
        _col = GetComponent<BoxCollider2D>();
        render = GetComponent<SpriteRenderer>();
        //TestDeck();
        //Debug.Log("--- A   ----");
        //TestDeck();
    }
    public void ChangeCard(Card card)
    {
        this.card = card;
        render = GetComponent<SpriteRenderer>();
        render.sprite = card.sprite;
    }
    private void PrintCard(Card card)
    {
        Debug.Log("Color " + card.color+ " fact : " + card.faction 
            + " val : " + card.cardValue + " id : " + card.cardId);
    }
}
