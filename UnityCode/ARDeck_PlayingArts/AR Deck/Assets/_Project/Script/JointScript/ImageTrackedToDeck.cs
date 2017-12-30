using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ImageTrackedToDeck : MonoBehaviour {

    public VuforiaTargetsManager _targetsManager;
    public OnDeckChangeDetected _onDeckStatusChanged;
    public OnDeckChangeEvent _onDeckStatusChangedEvent;
    public delegate void OnDeckChangeDetected(bool isTracked, DeckCard card);
    [Serializable]
    public class OnDeckChangeEvent : UnityEvent<bool, DeckCard> {

    }

    [Header("Debug")]
    public bool _displayDebug=true;

    void Awake () {
        _targetsManager._onTrackerChanged += DeckStateDetection;
    }

    private void DeckStateDetection(bool isTracked, string name)
    {
        try
        {
            DeckCard deck = new DeckCard();
            deck.Set(name);
            deck.SetMetaData(name);

            if (_displayDebug)
                Debug.Log("> " + name + ":" + isTracked + " -> " + deck);

            if (_onDeckStatusChanged != null)
                _onDeckStatusChanged(isTracked, deck);
            _onDeckStatusChangedEvent.Invoke(isTracked,deck);
        }
        catch (Exception e) {
            Debug.Log("> "+e,this);
        }
    }
}
