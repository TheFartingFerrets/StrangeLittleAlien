using UnityEngine;
using System.Collections;

public class SimpleScaler : MonoBehaviour 
{
    public float sinScale = 0;
    public float sinNum;

    Vector3 offset;


    void Start()
    {
        offset = transform.localScale;


    }

    void Update()
    {
        sinScale += Time.deltaTime;
        sinNum = Mathf.Sin(sinScale) * 0.2f;
        sinNum = Mathf.Clamp(sinNum, -0.2f, 0.5f);
        transform.localScale = new Vector3( offset.x + sinNum, offset.y + sinNum, offset.z);
    }


}
