using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour 
{
    [SerializeField]
    Transform PortalOut;
    [SerializeField]
    bool PortalIn = false;

    public void SetOutPortal( Transform _PortalOut )
    {
        PortalOut = _PortalOut;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (!PortalIn) return;
        if( other.tag == "Roller")
        {
            other.GetComponent<Rigidbody2D>().position = PortalOut.position + Vector3.right * 0.2f;
            other.GetComponent<Rigidbody2D>().velocity = PortalOut.right * other.GetComponent<Rigidbody2D>().velocity.magnitude;
        }
    }

    
}

