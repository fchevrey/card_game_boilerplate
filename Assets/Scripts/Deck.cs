using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eDeckType
{
    std32Card = 32,
    std52Card = 52,
    std54Card = 54,
    //Tarot = 78
}
public class Deck 
{
    protected List<Card> _deck;
    protected List<Card> _discard;
    private static bool _randomInitialized = false;
    private static List<eCardId> _lstDeck32 = null;
    private static List<eCardId> _lstDeck52 = null;
    private static List<eCardId> _lstDeck54 = null;
    private static List<eCardFaction> _factions = null;
    public static List<eCardFaction> factions 
    { get 
        { 
            if (_factions == null) 
            { InitializeLists(); } 
            return _factions; 
        } 
    }
    public eDeckType deckType { get; protected set; }
    public int cardsRemains { get { return _deck.Count; } }
    public int cardsInDiscards { get { return _discard.Count; } }

    public Deck(eDeckType deckType)
    {
        this.deckType = deckType;
        _discard = new List<Card>((int)deckType);
        if (_randomInitialized == false) 
        { 
            Random.InitState(System.DateTime.Now.Millisecond);
            _randomInitialized = true;
        }
        _deck = CreateDeck(deckType);
        Shuffle();
    }
    #region static_function
    private static void InitializeLists()
    {
        Debug.Log("INITIALIZE");
        /*  Create 52 and 54 cards lists    */
        List<eCardId> allIds = new List<eCardId>((eCardId[])System.Enum.GetValues(typeof(eCardId)));
        allIds.Remove(eCardId.joker);
        allIds.Remove(eCardId.none);
        _lstDeck52 = new List<eCardId>(allIds);
        allIds.Add(eCardId.joker);
        allIds.Add(eCardId.joker);
        _lstDeck54 = new List<eCardId>(allIds);
        /*  create 32 list  */
        _factions = new List<eCardFaction>((eCardFaction[])System.Enum.GetValues(typeof(eCardFaction)));
        _factions.Remove(eCardFaction.all);
        _factions.Remove(eCardFaction.none);

        List<eCardValue> values = new List<eCardValue>((eCardValue[])System.Enum.GetValues(typeof(eCardValue)));
        values.RemoveAll(x => x < eCardValue.seven);
        values.Remove(eCardValue.joker);
        _lstDeck32 = new List<eCardId>(32);
        foreach (eCardFaction faction in _factions)
        {
            foreach (eCardValue value in values)
            {
                _lstDeck32.Add(Card.GetIdOf(value, faction));
            }
        }
    }
    public static List<eCardId> GetDeckList(eDeckType type)
    {
        if (_lstDeck32== null || _lstDeck54 == null || _lstDeck52 == null)
        { InitializeLists(); }
        switch (type)
        {
            case eDeckType.std32Card:
                return new List<eCardId>(_lstDeck32);
            case eDeckType.std52Card:
                return new List<eCardId>(_lstDeck52);
            case eDeckType.std54Card:
                return new List<eCardId>(_lstDeck54);
            default:
                return null;
        }
    }
    public static List<eCardId> GetDeckList(eDeckType type, eCardFaction faction)
    {
        List<eCardId> lst = GetDeckList(type);
        lst.RemoveAll(x => Card.GetFactionOf(x) != faction);
        return lst;
    }
    private static List<Card> CreateDeck(eDeckType deckType)
    {

        List<Card> deck = new List<Card>((int)deckType);
        //int j = 0;
        foreach (eCardId id in Deck.GetDeckList(deckType))
        {
            deck.Add(new Card(id));
          //  Debug.Log(++j + " "+ id);
        }
        return deck;
    }
    #endregion
    public Card Draw()
    {
        int size = _deck.Count;
        if (size == 0)
        {
            Shuffle();
            size = _deck.Count;
        }
        Card dst = _deck[0];
        _deck.RemoveAt(0);
        return dst;
    }
    public List<Card> Draw(int qtt)
    {
        List<Card> dst = new List<Card>(qtt);
        for (int i = qtt; i > 0; --i)
        {
            dst.Add(Draw());
        }
        return (dst);
    }
    public void Shuffle()
    {
        _deck.AddRange(_discard);
        _discard.Clear();
        int count = _deck.Count;
        int last = count - 1;
        for (int i = 0; i < last; ++i)
        {
            int index = Random.Range(i, count);
            Card tmp = _deck[i];
            _deck[i] = _deck[index];
            _deck[index] = tmp;
        }
    }
    public void Burn()
    {
        Discard(Draw());
    }
    public void Discard(Card card)
    {
        if (!_discard.Contains(card) && !_deck.Contains(card))
        {
            _discard.Add(card);
        }
    }
}
