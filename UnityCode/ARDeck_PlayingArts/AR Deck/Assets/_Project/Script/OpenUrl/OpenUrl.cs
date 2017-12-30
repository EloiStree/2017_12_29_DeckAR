using UnityEngine;
using System.Collections;

public class OpenUrl : MonoBehaviour {

    public string _urlTargeted;
    public void OpenTarget() {
        Application.OpenURL( _urlTargeted ); 
    }
	
}
