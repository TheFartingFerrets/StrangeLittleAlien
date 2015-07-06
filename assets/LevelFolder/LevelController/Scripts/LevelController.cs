using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{
    /*IMPORTANT*/
    GameController gController;

    //Find the GameController in the awake Functions
    //Set the Game Timer here as well.
    void Awake()
    {
        Debug.Log("<color=red>Example Script, change for your own custom script, but remember the important functions below</color>");
#if UNITY_EDITOR
        try
        {
            gController = GameObject.FindObjectOfType<GameController>();
            gController.GameControlState = GameState.InLevel;
        }
        catch (System.Exception e)
        {
            Debug.LogWarning("<color=blue>" + e.Message + "Missing GameController - Loading levels will not work</color>");
        }
#endif
        /* Use this, the above code is for debugging in the Unity Editor */
        //gController = GameObject.FindObjectOfType<GameController>();
        //gController.GameControlState = GameState.InLevel;
        GameTimer.SetTimer(200f);

    }

    //When the timer has ran out this function will be called, this should end the level
    public void OnTimesUp()
    {
		this.gameObject.GetComponent<AudioSource>().GetComponent<AudioSource>().Play ();
        Debug.Log("Times Up");
        //GameObject.FindObjectOfType<CompleteWindow>().GetComponent<CompleteWindow>().OnLevelComplete (
    }

    //Starts the level
    //Spawn items here, set objects etc
    void StartLevel()
    {
        GameTimer.StartTimer();
    }

    public void CompleteLevel()
    {
		this.gameObject.GetComponent<AudioSource>().GetComponent<AudioSource>().Play ();
        GameTimer.StopTimer();
        GameObject.FindObjectOfType<CompleteWindow>().SendMessage("OnLevelComplete");
    }

}
