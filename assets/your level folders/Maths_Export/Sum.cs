using UnityEngine;
using System.Collections;

public class Sum : MonoBehaviour {

	GameObject sum;

	int print_Sum;

	// Use this for initialization
	void Start () {
		sum = GameObject.Find("_gm");
		GameManager set_Sum = (GameManager) sum.GetComponent(typeof(GameManager));
		print_Sum = set_Sum.ze_sum;

		//Debug.Log ("SUM SCRIPTS VAUE :   " + print_Sum);
		GetComponent<TextMesh> ().text = print_Sum.ToString ();

	}

/*	public int my_Sum(){
		int sum_value;
		sum_value = Random.Range (1, 10);
		return sum_value;
		}*/
}
