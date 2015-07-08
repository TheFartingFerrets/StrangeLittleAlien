using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
	public Transform target;
	public float movespeed;
	public float rotationSpeed;

	private Transform myTransform;

	void Awake()
	{
		myTransform = transform;
	}

	// Use this for initialization
	void Start () 
	{
		GameObject go = GameObject.FindGameObjectWithTag ("Player");

		movespeed = Random.Range (1, 3); 

		target = go.transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.DrawLine (target.position, myTransform.position, Color.yellow);

		// Look at target
		myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationSpeed * Time.deltaTime);

		// Move towards the target
		myTransform.position += myTransform.forward * movespeed * Time.deltaTime;
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
            GameController.Current.ResetLevel();
            //GameController.Current.ExitToLevelSelect();
		}
	}
}
