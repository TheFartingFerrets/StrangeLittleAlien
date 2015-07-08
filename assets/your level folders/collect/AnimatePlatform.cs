using UnityEngine;
using System.Collections;

public class AnimatePlatform : MonoBehaviour
{
	
	private Vector3 startpos;
	public Transform target;
	public float speed = 1.0f;
	public float t = 0.0f; // the fractional distance it has moved from one to another
	private bool forward = true;
	
	// Use this for initialization
	void Start ()
	{
		startpos = transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		
		transform.position = Vector3.Lerp (startpos, target.position, t);
		
		if (forward) 
		{
			t = t + speed * Time.deltaTime;
			if (t >= 1.0)
				forward = false;
		} 
		else 
		{
			t = t - speed * Time.deltaTime;
			if (t <= 0.0)
				forward = true;
		}
		
	}
}