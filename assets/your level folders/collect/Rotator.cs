using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour 
{
	private float rotateSpeed;

	void Start()
	{
		rotateSpeed = Random.Range (20f, 60f);
	}
	void Update () 
	{

		if (this.name == "Fan") {
			transform.Rotate (0f, 0f,rotateSpeed * Time.deltaTime);

		}	else if(this.name == "PickUp"){
			transform.Rotate (0F, rotateSpeed * Time.deltaTime, 0F);
		}
	}
}
