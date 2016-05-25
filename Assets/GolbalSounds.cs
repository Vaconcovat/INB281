using UnityEngine;
using System.Collections;

public class GolbalSounds : MonoBehaviour {
	public AudioSource startup;
	public AudioSource music;
	public AudioSource fail;
	bool played = false;

	public void StartMusic(){
		if(!music.isPlaying && !played){
			music.Play();
			played = true;
		}
	}
}
