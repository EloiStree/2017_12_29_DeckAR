using UnityEngine;
using System.Collections;

public class OpenURLByDevices : MonoBehaviour {

    public string _urlTargetedAndroid;
    public string _urlTargetedIOS;
    public string _urlTargetedWindow;
    public void OpenTarget()
    {
#if UNITY_STANDALONE
        Application.OpenURL(_urlTargetedWindow);
#endif
#if UNITY_ANDROID
        Application.OpenURL(_urlTargetedIOS);
#endif
#if UNITY_IOS
        Application.OpenURL(_urlTargetedAndroid);
#endif
    }

}
