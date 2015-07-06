using UnityEngine;
using System.Collections;

public class Spring : MonoBehaviour 
{
    float baseForce = 20f;
    float SpeedMultiplier;
    void Awake()
    {
        SpeedMultiplier = GetComponent<Moveable>().BasePower * baseForce;
    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if( coll.gameObject.tag == "Roller")
        {
            float f = (SpeedMultiplier <= 3) ? SpeedMultiplier * 0.4f : (SpeedMultiplier > 4) ? SpeedMultiplier * 0.2f : SpeedMultiplier * 0.2f;
                //SpringForce * 0.8f;
            coll.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * f, ForceMode2D.Impulse);
        }
    }

    public void Lock()
    {
        SpeedMultiplier = GetComponent<Moveable>().BasePower * baseForce;
        Debug.Log(GetComponent<Moveable>().BasePower);
    }
}
