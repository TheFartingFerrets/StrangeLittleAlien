using UnityEngine;
using System.Collections;

public class KnownNumber : MonoBehaviour {
	GameObject numo;
	int print_num;
	
	// Use this for initialization
	void Start () {

		numo = GameObject.Find("_gm");
		GameManager set_Num = (GameManager) numo.GetComponent(typeof(GameManager));
		print_num = set_Num.ze_num;


		GetComponent<TextMesh> ().text = print_num.ToString ();

		//Debug.Log (" the known number is :  " + print_num);
	}
	
	
}
