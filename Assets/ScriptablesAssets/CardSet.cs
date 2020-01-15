using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class CardSet : ScriptableObject
{
    [SerializeField] private Sprite[] _spades;   
    [SerializeField] private Sprite[] _diamonds;   
    [SerializeField] private Sprite[] _hearts;   
    [SerializeField] private Sprite[] _clubs;
    [SerializeField] private Sprite _joker;
    public eDeckType deckType;
    public Sprite back;
    public Dictionary<eCardId, Sprite> set { get; private set; }
    private void OnEnable()
    {
        if (_spades == null || _diamonds == null || _hearts == null || _clubs == null)
        { 
            set = new Dictionary<eCardId, Sprite>(); 
            return; 
        }
        set = new Dictionary<eCardId, Sprite>((int)deckType);
        if (_joker != null)
        { set.Add(eCardId.joker, _joker); }
        AddArrayToDictionnary(ref _spades, eCardFaction.spade);
        AddArrayToDictionnary(ref _clubs, eCardFaction.club);
        AddArrayToDictionnary(ref _diamonds, eCardFaction.diamond);
        AddArrayToDictionnary(ref _hearts, eCardFaction.heart);
    }
    private void AddArrayToDictionnary(ref Sprite[] array, eCardFaction faction)
    {
        List<eCardId> lst = Deck.GetDeckList(deckType, faction);
        lst.Sort();
        Debug.Log(faction);
        Debug.Log("lst size = " + lst.Count);
        Debug.Log("Array Size  = " + array.Length);
        if (lst.Count == 0) { Debug.Log("ERROR : " + faction + " lst = 0"); return; }
        for (int i = array.Length -1; i >= 0; --i)
        {
            set.Add(lst[i], array[i]);
        }
    }

}
