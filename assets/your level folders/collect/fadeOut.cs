using UnityEngine;
using System.Collections;

public class fadeOut : MonoBehaviour 
{
	float duration = 10;
	public GUIStyle styleFont;
	
	void Update () 
	{
		if (Time.time > duration) 
		{
			Destroy (gameObject);
		}
		Color myColour = GetComponent<GUIText>().color;
		float ratio = Time.time / duration;
		myColour.a = Mathf.Lerp (1, 0, ratio);
		GetComponent<GUIText>().color = myColour;
	}
}
