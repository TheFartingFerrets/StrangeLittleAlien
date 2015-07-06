using UnityEngine;
using System.Collections;

public class ObjectiveManager : MonoBehaviour 
{
    public Objective Objective_1;
    public Objective Objective_2;
    public Objective Objective_3;
}

[System.Serializable]
public class Objective
{
    [SerializeField]
    float Required = 0;
    [SerializeField]
    bool IsComplete = false;
    [SerializeField]
    ObjectiveType ObjType;

    public bool CheckObjective( float _ToCheck)
    {
        if( IsComplete)
        {
            return true;
        }
        else
        {
            switch (ObjType)
            {
                case ObjectiveType.LessThan:
                    IsComplete = _ToCheck < Required ? true : false;
                    break;
                case ObjectiveType.MoreThan:
                    IsComplete = _ToCheck > Required ? true : false;
                    break;
            }
            return IsComplete;
        }
    }
    public bool CheckObjective( bool _ToCheck)
    {
        if( IsComplete)
        {
            return true;
        }
        else
        {
            IsComplete = _ToCheck == true ? true : false;
            return IsComplete;
        }
        
    }
}
public enum ObjectiveType
{
    LessThan,
    MoreThan,
    Other,
}