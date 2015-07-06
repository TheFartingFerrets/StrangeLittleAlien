using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSelectWindow : MonoBehaviour 
{
	public void LoadWorldData( List<Level> WorldData )
    {
        bool obj1, obj2, obj3;

        for( int i = 0; i < WorldData.Count; i++)
        {
            obj1 = WorldData[i].Objective_1;
            obj2 = WorldData[i].Objective_2;
            obj3 = WorldData[i].Objective_3;

            transform.GetChild(1).GetChild(i).GetChild(0).GetChild(0).GetComponent<Star>().ToggleStar(WorldData[i].Objective_1);
            transform.GetChild(1).GetChild(i).GetChild(0).GetChild(1).GetComponent<Star>().ToggleStar(WorldData[i].Objective_2);
            transform.GetChild(1).GetChild(i).GetChild(0).GetChild(2).GetComponent<Star>().ToggleStar(WorldData[i].Objective_3);
            //Debug.Log(i + " : " + obj1 + " " + obj2 + " " + obj3);
        }
    }

    public void ForceClear()
    {
        for (int i = 0; i < 9; i++)
        {
            transform.GetChild(1).GetChild(i).GetChild(0).GetChild(0).GetComponent<Star>().ToggleStar(false);
            transform.GetChild(1).GetChild(i).GetChild(0).GetChild(1).GetComponent<Star>().ToggleStar(false);
            transform.GetChild(1).GetChild(i).GetChild(0).GetChild(2).GetComponent<Star>().ToggleStar(false);
        }
    }
}
