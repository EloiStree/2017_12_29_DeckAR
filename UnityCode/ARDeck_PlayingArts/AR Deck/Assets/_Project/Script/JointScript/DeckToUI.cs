using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckToUI : MonoBehaviour {

    public Image _imageToDisplay;

    public List<Card> _cardsToImages = new List<Card>();
    public List<UnknowCard> _cardsInfoToImages = new List<UnknowCard>();

    [System.Serializable]
    public class Card {
        public string _id;
        public DeckCard _card;
        public Sprite _image;
    }

    [System.Serializable]
    public class UnknowCard {

        public string _word;
        public Sprite _image;
    }


	// Use this for initialization
	public void SetUI (DeckCard deck) {

        for (int i = 0; i < _cardsToImages.Count; i++)
        {
            if (_cardsToImages[i]._card == deck) {


                _imageToDisplay.sprite = _cardsToImages[i]._image;
                return;
            }
        }
        for (int i = 0; i < _cardsInfoToImages.Count; i++)
        {
            if (deck.MetaData.Contains(_cardsInfoToImages[i]._word)) {
                _imageToDisplay.sprite = _cardsInfoToImages[i]._image;
                return;
            }

        }

    }


    void Reset()
    {

        AddFamily(DeckCard.CardFamily.Club);
        AddFamily(DeckCard.CardFamily.Diamond);
        AddFamily(DeckCard.CardFamily.Spare);
        AddFamily(DeckCard.CardFamily.Heart);
        DeckCard c = new DeckCard();
        c.Set(DeckCard.CardFamily.Joker
        , DeckCard.CardType.Undefined
        , DeckCard.CardColor.Red);
        _cardsToImages.Add(new Card() { _id = c.ToString(), _card = c });

        c = new DeckCard();
        c.Set(DeckCard.CardFamily.Joker
        , DeckCard.CardType.Undefined
        , DeckCard.CardColor.Black);
        _cardsToImages.Add(new Card() { _id = c.ToString(), _card = c });
    }

    private void AddFamily(DeckCard.CardFamily family)
    {
        for (int i = 1; i <=13; i++)
        {
            DeckCard c = new DeckCard();
            c.Family = family;
            c.Type = (DeckCard.CardType)i;
            _cardsToImages.Add(new Card() { _id = c.ToString() ,_card = c });
        }
    }
}
