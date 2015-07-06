using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

		public int level;

		// Use this for initialization
		void Start ()
		{


		}

		public	void level_Switcher ()
		{
				
			
				DontDestroyOnLoad (this);
	
				switch (level) {
		
				case 1:
						Application.LoadLevel ("v1");
						break;
				case 2:
						Application.LoadLevel ("v2");
						break;
				case 3:
						Application.LoadLevel ("v3");
						break;
				case 4:
						Application.LoadLevel ("v4");
						break;
				case 5:
						Application.LoadLevel ("v5");
						break;
				case 6:
						Application.LoadLevel ("v6");
						break;
				case 7:
						Application.LoadLevel ("v7");
						break;
				case 8:
						Application.LoadLevel ("v8");
						break;
				case 9:
						Application.LoadLevel ("v9");
						break;
				case 10:
						Application.LoadLevel ("v10");
						break;
		
				}


		}

}
