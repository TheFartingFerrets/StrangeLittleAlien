using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class WindowToggle : MonoBehaviour {

    public GameObject TargetWindow;

    public void Toggle(bool toggle)
    {
        TargetWindow.GetComponent<Window>().Toggle();
    }
}
