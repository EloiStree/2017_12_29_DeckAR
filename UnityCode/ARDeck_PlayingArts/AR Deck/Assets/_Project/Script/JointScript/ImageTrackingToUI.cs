using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTrackingToUI : MonoBehaviour {

    public ImageTrackedToDeck _deckDetection;
    public DeckToUI _ui;

	// Use this for initialization
	void Awake () {
        _deckDetection._onDeckStatusChanged += ToUI;
		
	}

    private void ToUI(bool isTracked, DeckCard card)
    {
        if (isTracked)
            _ui.SetUI(card);
    }
    
}
