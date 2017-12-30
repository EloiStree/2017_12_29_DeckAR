using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class VuforiaTargetsManager : MonoBehaviour {

    public float _registerTargetAfter = 2;

    public IEnumerator Start() {

        yield return new WaitForSeconds(_registerTargetAfter);
        RefreshListOfTargetInScene();
        yield break;
    } 


    public List<ImageTargetObserved> _targetsInScene = new List<ImageTargetObserved>();
    [Serializable]
    public class ImageTargetObserved : ITrackableEventHandler {

        public ImageTargetObserved(ImageTargetBehaviour imageTarget) {
            _imageTracked = imageTarget;
            _imageTracked.RegisterTrackableEventHandler(this);
        }
        public ImageTargetBehaviour _imageTracked;
        public TrackableBehaviour.Status ActualState { get { return _imageTracked.CurrentStatus; } }

        public OnTrackerChanged _OnChanged;
        public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
        {
            if(_OnChanged!=null)
              _OnChanged(IsTracked(newStatus), _imageTracked.TrackableName);
        }
    }

    public OnTrackerChanged _onTrackerChanged;
    public TrackerChangedStatus _onTrackerChangedEvent;
    public delegate void OnTrackerChanged(bool isTracked, string name);
    [System.Serializable]
    public class TrackerChangedStatus : UnityEvent<bool, string> {    }

	// Use this for initialization
	void RefreshListOfTargetInScene () {

        _targetsInScene.Clear();
        ImageTargetBehaviour [] targetsInScene = FindObjectsOfType<ImageTargetBehaviour>();
        
        for (int i = 0; i < targetsInScene.Length; i++)
        {
            if (targetsInScene[i]) {
                ImageTargetObserved observed = new ImageTargetObserved(targetsInScene[i]);
                observed._OnChanged += NotifyChange;

                _targetsInScene.Add(observed);

            }
        }

	}

    private void NotifyChange(bool isTracked, string name)
    {
        if (_onTrackerChanged != null)
            _onTrackerChanged(isTracked, name);
        _onTrackerChangedEvent.Invoke(isTracked, name);

    }

    public static bool IsTracked (TrackableBehaviour.Status newStatus){
        return newStatus == TrackableBehaviour.Status.DETECTED ||
newStatus == TrackableBehaviour.Status.TRACKED ||
newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED;  }

   
}
