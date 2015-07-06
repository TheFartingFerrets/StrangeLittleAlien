using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

		public GameObject _myObj;
		public GameObject check;
		public GameObject _intA;
		public GameObject _intB;
		public GameObject _sum;
		public	int TotalNumberOfSpawners = 6;
		public int ze_sum;
		public int ze_num;
		public int missing_Number;
		public float LevelTimer;
		private GameObject spawn;



	//LevelManager lvl_mnr;
	GameObject timeless;

		void Awake ()
		{

		Screen.orientation = ScreenOrientation.Portrait;

		_intA = GameObject.FindGameObjectWithTag ("int_A");
		_intB = GameObject.FindGameObjectWithTag ("int_B");
		_sum = GameObject.FindGameObjectWithTag ("Sum");
	
				//Sum set_Sum = (Sum) _sum.GetComponent(typeof(Sum));

		
		//lvl_mnr = GameObject.Find ("LevelManager").GetComponent<LevelManager>();
		
		Time.timeScale = 1;	

		GameTimer.SetTimer(LevelTimer);

		ze_sum = my_Sum ();
		//Debug.Log ("The set sum is : " + ze_sum);
		
		ze_num = my_Num ();
		//Debug.Log ("The set NUM is : " + ze_num);
		
		if (ze_sum < ze_num) {
			
			int temp_no = ze_sum;
			
			ze_sum = ze_num;
			ze_num = temp_no;
		}
		
		missing_Number = equation_initalisation (ze_num, ze_sum);
		
		//	Debug.Log ("equation sol   " + missing_Number);
		//	Debug.Log ("The new sum is : " + ze_sum);
		//Debug.Log ("The new Num is : " + ze_num);
		
		spawn = GameObject.Find ("Spawn");
		
		//spawn.transform.position = new Vector3(worldPoint);        
		
		int correctPlace = Random.Range (0, TotalNumberOfSpawners); //
		
		for (int y = 0; y < TotalNumberOfSpawners-1; y++) {
			
			//for (int x = 0; x < 3; x++) {
			
			GameObject obj;
			
			if (y >= correctPlace)
				obj = Instantiate (_myObj, spawn.transform.GetChild(y+1).transform.position, Quaternion.identity) as GameObject;
			else
				obj = Instantiate (_myObj, spawn.transform.GetChild(y).transform.position, Quaternion.identity) as GameObject;
			
			for (int i = 0; i < 1; i++)
			{
				int randNum = randomNum();

				if (randNum == missing_Number)
					i--;
				else
					obj.GetComponent<TextMesh> ().text = randNum.ToString();
			}
			
			
			//}
		}
		GameObject returnedObj = (GameObject)Instantiate (_myObj, spawn.transform.GetChild(correctPlace).transform.position, Quaternion.identity);
		returnedObj.GetComponent<TextSpawn> ().enabled = false;
		returnedObj.GetComponent<TextMesh> ().text = missing_Number.ToString ();
		returnedObj.name = "RightAnswer";
		//returnedObj.tag = "Answer";
		
	}
	
//	// Use this for initialization
	void Start ()
		{
		GameTimer.StartTimer();
		
		}
//	
//		// Update is called once per frame
//		void Update ()
//		{
//		//Debug.Log (Time.timeScale);
//				timer += Time.deltaTime;
//	
//				float elapsedTime = timer % 60;
//
//				int min = 0;
//
//				if (elapsedTime >= 60) {
//					
//						min = 1;
//				}
//
//				if (elapsedTime >= 120) {
//						min = 2;
//				}
//
//				string niceTime = string.Format ("{0:0}:{1:00}", min, timer);
//
//				//GUI.Label (new Rect (Screen.width * 0.9f, Screen.height * 0.5f, 5f, 5f),niceTime);
//				if (GameObject.Find ("AnswerChecker").GetComponent<AnswerCheck> ().rightAnswer) {
//
//			//lvl_mnr.level++;
//			//lvl_mnr.level_Switcher ();
//						// Time.timeScale = 0;
//					
//				}
//
//			
//	
//		}
//
//		void OnGUI ()
//		{
//		
//				float elapsedTime = timer % 60;
//		
//				int min = 0;
//		
//				if (elapsedTime >= 60) {
//						min = 1;
//				}
//		
//				if (elapsedTime >= 120) {
//						min = 2;
//				}
//		
//				string niceTime = string.Format ("{0:0}:{1:00}", min, timer);
//		
//				GUI.Label (new Rect (0.9f, 0.1f, 5f, 5f), "hola");
//
//				if (GameObject.Find ("AnswerChecker").GetComponent<AnswerCheck> ().rightAnswer) {
//
//						if (GUI.Button (new Rect (Screen.width / 4, 10, Screen.width / 2, Screen.height / 4), "Next Level")) {
//
//								check.SetActive (true);
//								Time.timeScale = 1;	
//							
//
//						}
//				}
//		
//		}

		public int my_Sum ()
		{
				int sum_value = 0;
		if (Application.loadedLevelName == "Maths_0") {
			sum_value = Random.Range (1, 10);
		}
		if (Application.loadedLevelName == "Maths_1") {
			sum_value = Random.Range (1, 10);
		}
		if (Application.loadedLevelName == "Maths_2") {
			sum_value = Random.Range (1, 100);
		}
		
		if (Application.loadedLevelName == "Maths_3") {
			sum_value = Random.Range (1, 100);
		}
		
		if (Application.loadedLevelName == "Maths_4") {
			sum_value = Random.Range (1, 999);
		}
		
		if (Application.loadedLevelName == "Maths_5") {
			sum_value = Random.Range (1, 999);
		}
		
		if (Application.loadedLevelName == "Maths_6") {
			sum_value = Random.Range (1, 9999);
		}
		
		if (Application.loadedLevelName == "Maths_7") {
			sum_value = Random.Range (1, 9999);
		}

		if (Application.loadedLevelName == "Maths_8") {
			sum_value = Random.Range (1, 10000);
		}
		
		return sum_value;
		}

		public int my_Num ()
		{
				int num_value = 0;
		if (Application.loadedLevelName == "Maths_0") {
			num_value = Random.Range (1, 10);
		}
		if (Application.loadedLevelName == "Maths_1") {
			num_value = Random.Range (1, 10);
		}
		if (Application.loadedLevelName == "Maths_2") {
			num_value = Random.Range (1, 100);
		}
		
		if (Application.loadedLevelName == "Maths_3") {
			num_value = Random.Range (1, 100);
		}
		
		if (Application.loadedLevelName == "Maths_4") {
			num_value = Random.Range (1, 999);
		}
		
		if (Application.loadedLevelName == "Maths_5") {
			num_value = Random.Range (1, 999);
		}
		
		if (Application.loadedLevelName == "Maths_6") {
			num_value = Random.Range (1, 9999);
		}
		
		if (Application.loadedLevelName == "Maths_7") {
			num_value = Random.Range (1, 9999);
		}
		
		if (Application.loadedLevelName == "Maths_8") {
			num_value = Random.Range (1, 10000);
		}
				//num_value = Random.Range (1, 10);
				return num_value;
		}

		public int equation_initalisation (int a, int sum)
		{
				int x;
				x = sum - a;

				return x;
		}

		public int randomNum(){

		int randomNumber = 0;

		if (Application.loadedLevelName == "Maths_0") {
			randomNumber = Random.Range (1, 10);
		}
		if (Application.loadedLevelName == "Maths_1") {
			randomNumber = Random.Range (1, 10);
		}
		if (Application.loadedLevelName == "Maths_2") {
			randomNumber = Random.Range (1, 100);
		}
		
		if (Application.loadedLevelName == "Maths_3") {
			randomNumber = Random.Range (1, 100);
		}
		
		if (Application.loadedLevelName == "Maths_4") {
			randomNumber = Random.Range (1, 999);
		}
		
		if (Application.loadedLevelName == "Maths_5") {
			randomNumber = Random.Range (1, 999);
		}

		if (Application.loadedLevelName == "Maths_6") {
			randomNumber = Random.Range (1, 9999);
		}
		
		if (Application.loadedLevelName == "Maths_7") {
			randomNumber = Random.Range (1, 9999);
		}
		
		if (Application.loadedLevelName == "Maths_8") {
			randomNumber = Random.Range (1, 10000);
		}

		return randomNumber;
	}

}
