using UnityEngine;
using System.Collections;

public class AnswerCheck : MonoBehaviour {

	public Texture aTexture;
	public bool rightAnswer;
	public GameObject go;
	GameObject levelControl;
	int unknown_num;
	bool hel;


	// Use this for initialization
	void Start () {
	
		rightAnswer = false;
		levelControl = GameObject.FindGameObjectWithTag ("LevelControl");
//		unknown_num = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManager>().ze_num;


	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (rightAnswer);
		if (rightAnswer == true) {
			//go.SetActive(true);


				}
	
	}

	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.name == "RightAnswer") {

			rightAnswer = true;

			//bool complete_1 = levelControl.GetComponent <ObjectiveManager> ().Objective_1.IsComplete = true;
		//	bool complete_2 = levelControl.GetComponent <ObjectiveManager> ().Objective_2.IsComplete = true;
		//	bool complete_3 = levelControl.GetComponent <ObjectiveManager> ().Objective_3.IsComplete = true;
//		//levelControl.GetComponent <ObjectiveManager>()._Objective_1.CheckObjective();
			GameObject.Find("CompleteWindow").GetComponent<Window>().Open();
//				complete_1,
//				complete_2,
//				complete_3
//				);

//			print ("GOT IT !!");
			GameTimer.StopTimer();
			levelControl.GetComponent<MathsLevelController>().CompleteLevel ();

		
			
				} 
		
		coll.gameObject.GetComponents<TextMesh> ();
		
		
	}
}
