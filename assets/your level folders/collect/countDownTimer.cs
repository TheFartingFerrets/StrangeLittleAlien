using UnityEngine;
using System.Collections;

public class countDownTimer : MonoBehaviour 
{
	public GUIStyle timerStyle;
	public float timeRemaining = 120;

	// Update is called once per frame
	void Update () 
	{
		timeRemaining -= Time.deltaTime;
	}

	void OnGUI()
	{
		if (timeRemaining > 0) 
		{
			GUI.Label (new Rect (100, 100, 200, 100), "Time Remaining : " + (int)timeRemaining, timerStyle);		
		} 
		if (timeRemaining <= 0)
		{
			GUI.Label (new Rect (100, 100, 200, 100), "Time's Up!", timerStyle);
		}
	}
}
