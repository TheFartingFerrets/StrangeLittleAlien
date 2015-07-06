using UnityEngine;
using UnityEditor;
using System.Collections;
[CustomEditor(typeof(Window))]
public class WindowTools : Editor 
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Window TargetWindow = (Window)target;
        if (GUILayout.Button("Toggle Window"))
        {
            TargetWindow.Toggle();
        }
    }
}
