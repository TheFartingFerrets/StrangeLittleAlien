using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhysicsMoveableBank : MonoBehaviour 
{
    public int totalMoveables = 0;

    //public MoveableObject[] Moveables = new MoveableObject[10];

    public MoveableObject Block = new MoveableObject();
    public MoveableObject Spring = new MoveableObject();
    public MoveableObject Speeder = new MoveableObject();

    public void Awake()
    {
        Block.SetAmount();
        Spring.SetAmount();
        Speeder.SetAmount();
    }

    public void RequestObject(string BankItem)
    {
        GameObject Spawnable = (BankItem == "Block") ? Block.Request() : (BankItem == "Spring") ? Spring.Request() : Speeder.Request();

        if (Spawnable != null)
        {
            totalMoveables++;
            Instantiate(Spawnable,Vector2.one, Quaternion.identity);
        }
    }

    public void RemoveObject(string itemName, GameObject itemObject)
    {
        switch( itemName )
        {
            case "Block":
                Block.Remove();
                break;
            case "Spring":
                Spring.Remove();
                break;
            case "Speeder":
                Speeder.Remove();
                break;
        }    

        Destroy(itemObject);
    }

}

[System.Serializable]
public class MoveableObject
{
    public GameObject Movable;
    [Range(0,10)]
    [SerializeField]
    public int TotalAmount;
    [SerializeField]
    private int AmountLeft;
    public void SetAmount()
    {
        this.AmountLeft = this.TotalAmount;
    }
    public GameObject Request()
    {
        if( AmountLeft > 0)
        {
            this.AmountLeft--;
            return this.Movable;
        }
        else
        {
            return null;
        }
    }
    public bool Remove()
    {
        if(this.AmountLeft < this.TotalAmount)
        {
            this.AmountLeft++;
            return true;
        }
        else
        {
            return false;
        }
    }
}