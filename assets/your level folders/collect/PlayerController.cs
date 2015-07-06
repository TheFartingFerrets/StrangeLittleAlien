using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public int count;
	public GUIText countText;
	public GUIText winText;
	public GameObject Scene;
	public string restartThisLevel;



	void Update () 
	{
		// Keyboard controls
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);

		// Accelerometer controls
		movement = new Vector3 (Input.acceleration.x, 0.0f, Input.acceleration.y);
		GetComponent<Rigidbody>().AddForce (movement  * speed * Time.deltaTime );

	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "PickUp") 
		{	
			this.gameObject.GetComponent<AudioSource>().Play ();
			Counter.IncreaseAmount(1);
			other.gameObject.SetActive(false);



//			if (other.gameObject.tag == "Enemy") 
//			{
//				GameController.Current.ExitToLevelSelect();
//			}
		}

	}
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count == 0) 
		{
		
			Application.LoadLevel (29);
			winText.text = "You Collected 26!";
		}
	}
}
