using UnityEngine;
using System.Collections;

///[RequireComponent(typeof(CapsuleCollider))]

public class DragDrop : MonoBehaviour 
{
	private Vector3 screenPoint;
	private Vector3 offset;

	bool dragging;
	bool inside;

	void Start(){

		dragging = false;
	
		}
	void Update(){


		}
	void OnMouseDown()
	{
		this.gameObject.GetComponent<AudioSource>().GetComponent<AudioSource>().Play ();
		Handheld.Vibrate ();
		dragging = true;
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
	
	void OnMouseDrag()
	{
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		
		//Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) &#43; offset;
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		transform.position = curPosition;
		
	}
	
}