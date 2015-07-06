using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public GameObject player;	// player game object
	//private Vector3 offset;		// offset the camera position

	void Start()
	{
		//offset = transform.position;
	}

	void LateUpdate()
	{
		transform.position = player.transform.position + new Vector3(0, 15, 0);
	}
}
