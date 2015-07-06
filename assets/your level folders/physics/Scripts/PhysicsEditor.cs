using UnityEngine;
using System.Collections;

public class PhysicsEditor : MonoBehaviour 
{
    public Transform Target;

    void Awake()
    {
        HideEditor();
    }
	public void SetTarget( Transform _Target)
    {
        if( _Target == Target )
        {
            Target = null;
            transform.GetChild(2).SendMessage("SetPos");
            HideEditor();
        }
        else
        {
            Target = _Target;
            transform.GetChild(2).SendMessage("SetPos");
        }
    }

    void LateUpdate()
    {
        if( Target)
        {
            transform.position = Target.position;
        }
    }

    public void TogglePower()
    {
        Target.SendMessage("TogglePower");
    }
    public void ToggleFlipVertical()
    {
        Target.SendMessage("ToggleFlipVertical");
    }
    public void ToggleFlipHorizontal()
    {
        Target.SendMessage("ToggleFlipHorizontal");
    }
    
    public void HideEditor()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(-100, -100, 10));
        Target = null;
    }

    public void RemoveItem()
    {
        PhysicsMoveableBank PMB = GameObject.FindGameObjectWithTag("LevelControl").GetComponent<PhysicsMoveableBank>();

        MoveableType mt = Target.GetComponent<Moveable>().MoveType;

        switch( mt )
        {
            case MoveableType.Block:
                PMB.RemoveObject("Block", Target.gameObject);
                break;
            case MoveableType.Speeder:
                PMB.RemoveObject("Speeder", Target.gameObject);
                break;
            case MoveableType.Spring:
                PMB.RemoveObject("Spring", Target.gameObject);
                break;
            case MoveableType.Portal:
                PMB.RemoveObject("Portal", Target.gameObject);
                break;
        }
        HideEditor();
    }
}
