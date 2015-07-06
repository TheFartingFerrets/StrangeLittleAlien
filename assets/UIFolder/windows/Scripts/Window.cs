using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(CanvasGroup))]
public class Window : MonoBehaviour 
{
    void Awake()
    {
        Toggle(false);
    }
    
    public void Toggle()
    {
        this.GetComponent<CanvasGroup>().ToggleCanvasGroup();
    }
    public void Toggle(bool toggle)
    {
        this.GetComponent<CanvasGroup>().ToggleCanvasGroup( toggle );
    }
    public void Open()
    {
        this.GetComponent<CanvasGroup>().ShowCanvasGroup();
    }
}
