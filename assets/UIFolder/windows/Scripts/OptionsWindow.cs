using UnityEngine;
using System.Collections;

public class OptionsWindow : MonoBehaviour 
{
    public void RestartLevel()
    {
        Debug.Log("Application.LoadLevel(this)");
        this.GetComponent<Window>().Toggle(false);
        GameController.Current.ResetLevel();
    }
    public void Exit()
    {
        Debug.Log("Quit Level -> Back to main");
        this.GetComponent<Window>().Toggle(false);
        GameController.Current.ExitToLevelSelect();
    }
    public void Quit()
    {
        Debug.Log("Quit App");
        this.GetComponent<Window>().Toggle(false);
        //GameController.Current.ExitToWorldSelect();
        GameController.Current.QuitApp();
    }
}
