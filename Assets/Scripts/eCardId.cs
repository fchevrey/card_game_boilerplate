public enum eCardId : uint
{
    none = 0,
    joker = eCardFaction.all | eCardValue.joker,
    /*Spade cards*/
    twoOfSpade = eCardFaction.spade | eCardValue.two,
    threeOfSpade = eCardFaction.spade | eCardValue.three,
    fourOfSpade = eCardFaction.spade | eCardValue.four,
    fiveOfSpade = eCardFaction.spade | eCardValue.five,
    sixOfSpade = eCardFaction.spade | eCardValue.six,
    sevenOfSpade = eCardFaction.spade | eCardValue.seven,
    eightOfSpade = eCardFaction.spade | eCardValue.eight,
    nineOfSpade = eCardFaction.spade | eCardValue.nine,
    tenOfSpade = eCardFaction.spade | eCardValue.ten,
    jackOfSpade = eCardFaction.spade | eCardValue.jack,
    queenOfSpade = eCardFaction.spade | eCardValue.queen,
    kingOfSpade = eCardFaction.spade | eCardValue.king,
    AceOfSpade = eCardFaction.spade | eCardValue.Ace,

    /*Club cards*/
    twoOfClub = eCardFaction.club | eCardValue.two,
    threeOfClub = eCardFaction.club | eCardValue.three,
    fourOfClub = eCardFaction.club | eCardValue.four,
    fiveOfClub = eCardFaction.club | eCardValue.five,
    sixOfClub = eCardFaction.club | eCardValue.six,
    sevenOfClub = eCardFaction.club | eCardValue.seven,
    eightOfClub = eCardFaction.club | eCardValue.eight,
    nineOfClub = eCardFaction.club | eCardValue.nine,
    tenOfClub = eCardFaction.club | eCardValue.ten,
    jackOfClub = eCardFaction.club | eCardValue.jack,
    queenOfClub = eCardFaction.club | eCardValue.queen,
    kingOfClub = eCardFaction.club | eCardValue.king,
    AceOfClub = eCardFaction.club | eCardValue.Ace,
    
    /*Diamond cards*/
    twoOfDiamond = eCardFaction.diamond | eCardValue.two,
    threeOfDiamond = eCardFaction.diamond | eCardValue.three,
    fourOfDiamond = eCardFaction.diamond | eCardValue.four,
    fiveOfDiamond = eCardFaction.diamond | eCardValue.five,
    sixOfDiamond = eCardFaction.diamond | eCardValue.six,
    sevenOfDiamond = eCardFaction.diamond | eCardValue.seven,
    eightOfDiamond = eCardFaction.diamond | eCardValue.eight,
    nineOfDiamond = eCardFaction.diamond | eCardValue.nine,
    tenOfDiamond = eCardFaction.diamond | eCardValue.ten,
    jackOfDiamond = eCardFaction.diamond | eCardValue.jack,
    queenOfDiamond = eCardFaction.diamond | eCardValue.queen,
    kingOfDiamond = eCardFaction.diamond | eCardValue.king,
    AceOfDiamond = eCardFaction.diamond | eCardValue.Ace,

    /*Heart cards*/
    twoOfHeart = eCardFaction.heart | eCardValue.two,
    threeOfHeart = eCardFaction.heart | eCardValue.three,
    fourOfHeart = eCardFaction.heart | eCardValue.four,
    fiveOfHeart = eCardFaction.heart | eCardValue.five,
    sixOfHeart = eCardFaction.heart | eCardValue.six,
    sevenOfHeart = eCardFaction.heart | eCardValue.seven,
    eightOfHeart = eCardFaction.heart | eCardValue.eight,
    nineOfHeart = eCardFaction.heart | eCardValue.nine,
    tenOfHeart = eCardFaction.heart | eCardValue.ten,
    jackOfHeart = eCardFaction.heart | eCardValue.jack,
    queenOfHeart = eCardFaction.heart | eCardValue.queen,
    kingOfHeart = eCardFaction.heart | eCardValue.king,
    AceOfHeart = eCardFaction.heart | eCardValue.Ace,
}

public enum eCardValue : uint
{
    joker = (uint)0xFFFFFFF,//0FFF FFFF
    two = (uint)1,
    three = (uint)1 << 1,
    four = (uint)1 << 2,
    five = (uint)1 << 3,
    six = (uint)1 << 4,
    seven = (uint)1 << 5,
    eight = (uint)1 << 6,
    nine = (uint)1 << 7,
    ten = (uint)1 << 8,
    jack = (uint)1 << 9,//Valet
    queen = (uint)1 << 10,
    king = (uint)1 << 11,
    Ace = (uint)1 << 12 //As
}
public enum eCardFaction : uint
{
    none = 0,
    spade = (uint)1 << 28,//pique
    club = (uint)1 << 29,//trèfle
    diamond = (uint)1 << 30, //carreau
    heart = (uint)1 << 31, //coeur
    all = ((uint)1 << 28) + ((uint)1 << 29) + ((uint)1 << 30) + ((uint)1 << 31)
}
public enum eCardColor : uint
{
    none = 0,
    black,
    red,
    all
}
