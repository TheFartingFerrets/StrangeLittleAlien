using UnityEngine;
using System.Collections;

public class Speeder : MonoBehaviour 
{
    float baseForce = 20f;
    float SpeedMultiplier;

    Vector2 Direction = Vector2.zero;
    void Awake()
    {
        Lock();
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Roller")
        {
            float f = (SpeedMultiplier/10) *0.4f;
                //(SpeederForce/10)*0.2f;
            Direction = transform.localScale.normalized;

            other.GetComponent<Rigidbody2D>().AddForce((transform.right * Direction.x) * f, ForceMode2D.Impulse);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Roller")
        {
            float f = (SpeedMultiplier / 10f) * 0.8f;
            //(SpeederForce/10)*0.2f;
            Direction = transform.localScale.normalized;

            other.GetComponent<Rigidbody2D>().AddForce((transform.right * Direction.x) * f, ForceMode2D.Impulse);
        }
    }

    public void Lock()
    {
        SpeedMultiplier = GetComponent<Moveable>().BasePower * baseForce;
        Debug.Log(GetComponent<Moveable>().BasePower);

    }

}
