using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//[ExecuteInEditMode]
public class LevelButton : MonoBehaviour 
{
    [SerializeField]
    Text LevelName;

    void Awake()
    {
        LevelName.text = (transform.GetSiblingIndex() + 1).ToString();
    }

    public void LevelSelect()
    {
		this.gameObject.GetComponent<AudioSource>().GetComponent<AudioSource>().Play ();
        GameObject.FindObjectOfType<GameController>().SetLevel( transform.GetSiblingIndex() );
    }


}
