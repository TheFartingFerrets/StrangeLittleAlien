using UnityEngine;
using System.Collections;

public class CompleteWindow : MonoBehaviour 
{
    [SerializeField]
    Star Obj1;
    [SerializeField]
    Star Obj2;
    [SerializeField]
    Star Obj3;

    public void OnLevelComplete(float o1, float o2, bool o3)
    {
        bool obj1, obj2, obj3;

        this.GetComponent<Window>().Toggle(true);
        ObjectiveManager OBJMan = GameObject.FindObjectOfType<ObjectiveManager>();
        obj1 = OBJMan.Objective_1.CheckObjective(o1);
        obj2 = OBJMan.Objective_2.CheckObjective(o2);
        obj3 = OBJMan.Objective_3.CheckObjective(o3);

		Obj1.ToggleStar(obj1);
		Obj2.ToggleStar(obj2);
		Obj3.ToggleStar(obj3);

		GameData.CurrentData.Update (GameController.Current.GetWorld, GameController.Current.LevelID, obj1, obj2, obj3);
        
        GameData.Save();
    }

	public void OnLevelComplete(float o1, float o2, float o3)
	{
		bool obj1, obj2, obj3;
		
		this.GetComponent<Window>().Toggle(true);
		ObjectiveManager OBJMan = GameObject.FindObjectOfType<ObjectiveManager>();
		obj1 = OBJMan.Objective_1.CheckObjective(o1);
		obj2 = OBJMan.Objective_2.CheckObjective(o2);
		obj3 = OBJMan.Objective_3.CheckObjective(o3);
		
		Obj1.ToggleStar(obj1);
		Obj2.ToggleStar(obj2);
		Obj3.ToggleStar(obj3);
		
		GameData.CurrentData.Update (GameController.Current.GetWorld, GameController.Current.LevelID, obj1, obj2, obj3);
		
		GameData.Save();
	}

    public void RestartLevel()
    {
        Debug.Log("Application.LoadLevel(this)");
        //this.GetComponent<Window>().Toggle(false);
        GameController.Current.ResetLevel();
    }
    public void Exit()
    {
        Debug.Log("Quit Level -> Back to main");
        //this.GetComponent<Window>().Toggle(false);
        GameController.Current.ExitToLevelSelect();
    }
    public void NextLevel()
    {
        Debug.Log("Next Level");
        GameController.Current.LoadNextLevel();
    }
}
