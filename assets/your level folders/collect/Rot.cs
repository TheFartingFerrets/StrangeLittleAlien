using UnityEngine;
using System.Collections;

public class Rot : MonoBehaviour 
{
	public float rotateSpeed;
	
	void Start()
	{
		rotateSpeed = Random.Range (60f, 80f);
	}
}