using UnityEngine;
using System.Collections;

public class EscapeToScene : MonoBehaviour {


    public LoadScene loadScene;
    void Update () {


        if (loadScene != null && (Input.GetKey(KeyCode.Escape) || Input.GetButton("Cancel")))
        {
            loadScene.LoadSelectedScene();
        }
       
	}
}
