using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Card : IComparable
{
    public eCardId  cardId{get; protected set;}
    public eCardColor  color{ get { return GetColorOf(cardId); } }
    public eCardValue  cardValue{ get { return GetValueOf(cardId); } }
    public eCardFaction faction { get { return GetFactionOf(cardId); } }
    public CardSet cardSet;
    public Sprite sprite; //{ get; protected set; }
    public Card(eCardId id)
    {
        cardId = id;
        //sprite = cardSet.set[id];
    }
    public Card(eCardValue value, eCardFaction faction)
    {
        cardId = (eCardId)((uint)value | (uint)faction);
    }
    public bool IsSameColorAs(Card other)
    {
        if (((uint)other.cardId >> 28) != ((uint)cardId >> 28))
            return false;
        return true;
    }
    public override string ToString()
    {
        return cardId.ToString();
    }
    public int CompareTo(object other)
    {
        if (!(other is Card otherCard)) { throw new ArgumentException("Object is not a Card"); }
        return ((uint)this.cardValue).CompareTo((uint)otherCard.cardValue);
    }
    #region static function
    public static eCardValue GetValueOf(eCardId id)
    {
        return (eCardValue)(((uint)id << 4) >> 4);
    }
    public static eCardFaction GetFactionOf(eCardId id)
    {
        return (eCardFaction)((uint)id & (uint)eCardFaction.all);
    }
    public static eCardColor GetColorOf(eCardId id)
    {
        if (id == eCardId.joker)
            return eCardColor.all;
        if ((((uint)id) & ((uint)3 << 28)) != 0)
            return eCardColor.black;    //if one of the two first color bit == 1 its black
        if ((((uint)id) & ((uint)3 << 30)) != 0)
            return eCardColor.red;      //if one of the two last color bit == 1 its red
        return eCardColor.none;
    }
    public static eCardColor GetColorOf(eCardFaction faction)
    {
        if (faction == eCardFaction.all)
            return eCardColor.all;
        if ((((uint)faction) & ((uint)3 << 28)) != 0)
            return eCardColor.black;    //if one of the two first color bit == 1 its black
        if ((((uint)faction) & ((uint)3 << 30)) != 0)
            return eCardColor.red;      //if one of the two last color bi
        return eCardColor.none;
    }
    public static eCardId GetIdOf(eCardValue value, eCardFaction faction)
    {
        return (eCardId)((uint)faction | (uint)value);
    }
    #endregion
}
