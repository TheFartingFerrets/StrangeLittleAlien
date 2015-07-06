using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {
	
	public AudioClip[] Sound;
	
	//0 - ë‘ë”ì§€ ë“±ìž¥í•  ë•Œì˜ ì†Œë¦¬
	//1 - ë‚˜ìœ ë‘ë”ì§€ ìž¡ížë•Œì˜ ì†Œë¦¬
	//2 - ì¢‹ì€ ë‘ë”ì§€ ìž¡ížë•Œì˜ ì†Œë¦¬
	
	public void SoundPlay(int Sound_Number){
		
		GetComponent<AudioSource>().clip = Sound[Sound_Number];		
		GetComponent<AudioSource>().Play();
	}
}
