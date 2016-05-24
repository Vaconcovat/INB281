using UnityEngine;
using System.Collections;

public class GolbalSounds : MonoBehaviour {
	public AudioSource startup;
	public AudioSource music;
	public AudioSource fail;

	public void StartMusic(){
		if(!music.isPlaying){
			music.Play();
		}
	}
}
