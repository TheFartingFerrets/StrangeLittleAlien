using UnityEngine;
using System.Collections;

public class WorldSelectBack : MonoBehaviour 
{
    public void BackToWorldSelect()
    {
        //this.GetComponent<AudioSource> ().Play ();
        //GameController.Current.ExitToWorldSelect();
        GameController.Current.SoftWorldSelect();
    }

}
