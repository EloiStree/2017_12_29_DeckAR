
using System;
using System.Text.RegularExpressions;

[System.Serializable]
public class DeckCard
{
    public void Set(string text)
    {

        string textUp = text;
        text = text.ToLower();
        CardFamily newFamily = CardFamily.Undefined;
        CardType newType = CardType.Undefined;
        CardColor newColor = CardColor.Undefined;

        if (text.Contains("spare")) newFamily = CardFamily.Spare;
        else if (text.Contains("heart")) newFamily = CardFamily.Heart;
        else if (text.Contains("club")) newFamily = CardFamily.Club;
        else if (text.Contains("diamond")) newFamily = CardFamily.Diamond;
        else if (text.Contains("joker"))
        {
            newFamily = CardFamily.Joker;
            if (text.Contains("red") || textUp.Contains("R")) newColor = CardColor.Red;
            if (text.Contains("black") || textUp.Contains("B")) newColor = CardColor.Black;
        }


        if (text.Contains("ace") || textUp.Contains("A")) newType = CardType.Ace;
        else if (text.Contains("two")) newType = CardType.Two;
        else if (text.Contains("three")) newType = CardType.Three;
        else if (text.Contains("four")) newType = CardType.Four;
        else if (text.Contains("five")) newType = CardType.Five;
        else if (text.Contains("six")) newType = CardType.Six;
        else if (text.Contains("seven")) newType = CardType.Seven;
        else if (text.Contains("eight")) newType = CardType.Eight;
        else if (text.Contains("nine")) newType = CardType.Nine;
        else if (text.Contains("ten")) newType = CardType.Nine;
        else if (text.Contains("jack") || textUp.Contains("J")) newType = CardType.Jack;
        else if (text.Contains("queen") || textUp.Contains("Q")) newType = CardType.Queen;
        else if (text.Contains("king") || textUp.Contains("K")) newType = CardType.King;
        else
        {
            string resultString = Regex.Match(text, @"-?\d+").Value;
            if (!string.IsNullOrEmpty(resultString))
            {
                int result = int.Parse(resultString);
                newType = (CardType)result;
            }

        }

        Set(newFamily, newType, newColor);
    }

    internal void SetMetaData(string metaData)
    {
        this.MetaData = metaData;
    }

    public void Set(CardFamily newFamily, CardType newType, CardColor newColor = CardColor.Undefined)
    {
        Family = newFamily;
        Type = newType;
        if (newColor == CardColor.Undefined)
            this.Color = GetColor();
        else this.Color = newColor;
    }
    public CardColor GetColor() { return CardFamily.Diamond == Family || CardFamily.Heart == Family ? CardColor.Red : CardColor.Black; }
    public CardFamily Family;
    public CardType Type;
    public CardColor Color;
    public int Value { get { return (int)Type; } }
    public enum CardFamily { Spare, Heart, Club, Diamond,Joker, Undefined }
    public enum CardType : int { Ace = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10, Jack = 11, Queen = 12, King = 13, Undefined = -1 }
    public enum CardColor {Undefined, Red, Black }
    public string MetaData { get; private set; }

    public override string ToString()
    {
        return Family + "_" + Type;
    }
    public override bool Equals(Object obj)
    {
        return obj is DeckCard && this == (DeckCard)obj;
    }

    public override int GetHashCode()
    {
        return Family.GetHashCode() ^ Type.GetHashCode();
    }

    public static bool operator ==(DeckCard x, DeckCard y)
    {
        if (x.Family == CardFamily.Joker && y.Family == CardFamily.Joker)
        {
            return x.Color == y.Color;
        }

        return x.Family == y.Family && x.Type == y.Type;
    }

    public static bool operator !=(DeckCard x, DeckCard y)
    {
        return !(x == y);
    }



}