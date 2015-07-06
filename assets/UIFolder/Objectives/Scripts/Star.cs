using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Star : MonoBehaviour 
{
    [SerializeField]
    Sprite sNotCollected;
    [SerializeField]
    Sprite sCollected;

    void Awake()
    {
        NotCollected();
    }
    public void ToggleStar( bool value)
    {
        if (value)
            Collected();
        else
            NotCollected();
    }

    void Collected()
    {
        GetComponent<Image>().sprite = sCollected;
    }
    void NotCollected()
    {
        GetComponent<Image>().sprite = sNotCollected;
    }
}


