using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//AGH.ph => Alien Go Home. Phone Home

[System.Serializable]
public class GameData 
{
    public List<Level> MathsWorld = new List<Level>();
    public List<Level> PhysicsWorld = new List<Level>();
    public List<Level> CollectWorld = new List<Level>();
    public List<Level> ReflexWorld = new List<Level>();

    public static GameData CurrentData;

    public GameData()
    {
        for (int i = 0; i < 9; i++)
        {
            MathsWorld.Add(new Level());
            PhysicsWorld.Add(new Level());
            CollectWorld.Add(new Level());
            ReflexWorld.Add(new Level());
        }
        CurrentData = this;
    }
    public void Update(int world, int level, bool obj1, bool obj2, bool obj3)
    {
        Debug.Log("Updating World: " + world);
        switch(world)
        {
            case 0:
                CurrentData.MathsWorld[level].SetObjective(obj1, obj2, obj3);
                break;
            case 1:
			    CurrentData.PhysicsWorld[level].SetObjective(obj1, obj2, obj3);
                break;
            case 2:
			    CurrentData.CollectWorld[level].SetObjective(obj1, obj2, obj3);
                break;
            case 3:
			    CurrentData.ReflexWorld[level].SetObjective(obj1, obj2, obj3);
                break;
        }
        Save();
    }
    public static void Save()
    {
        BinaryFormatter BF = new BinaryFormatter();
        using (var file = new FileStream(Path.Combine(Application.persistentDataPath, "Data.AGH"), FileMode.Create))
        {
            BF.Serialize(file, CurrentData);
        }
    }
    public static GameData Load()
    {
        if (!File.Exists(Path.Combine(Application.persistentDataPath, "Data.AGH")))
        {
            Save();
        }
        BinaryFormatter BF = new BinaryFormatter();
        using (var file = new FileStream(Path.Combine(Application.persistentDataPath, "Data.AGH"), FileMode.Open))
        {
            CurrentData = (GameData)BF.Deserialize(file);
			return CurrentData;
        }
    }
}
[System.Serializable]
public class Level
{
    public bool isLocked = false;
    public void SetObjective( bool obj1, bool obj2, bool obj3)
    {
        Objective_1 = obj1;
        Objective_2 = obj2;
        Objective_3 = obj3;
    }
    public bool Objective_1 = false;
    public bool Objective_2 = false;
    public bool Objective_3 = false;
}
