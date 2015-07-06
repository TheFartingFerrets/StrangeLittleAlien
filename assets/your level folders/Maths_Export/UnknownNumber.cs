using UnityEngine;
using System.Collections;

public class UnknownNumber : MonoBehaviour {
	GameObject numo;
	int print_num;
	
	// Use this for initialization
	void Start () {
		
		numo = GameObject.Find("_gm");
		GameManager set_Num = (GameManager) numo.GetComponent(typeof(GameManager));
		print_num = set_Num.missing_Number;
			
//		Debug.Log (" the known number is :  " + print_num);
	}

}
