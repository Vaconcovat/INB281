using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Difficultyscript : MonoBehaviour {
	public bool easy;
	public bool normal;
	public bool hard;


	GameManager gm;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		if (easy == true){
		PlayerPrefs.SetInt ("Difficulty", 4);
		}
		if (normal == true) {
			PlayerPrefs.SetInt ("Difficulty", 6);
		}
		if (hard == true) {
			PlayerPrefs.SetInt ("Difficulty", 8);
		}
	}
	void OnMouseUp(){
		SceneManager.LoadScene ("test");
	}
}
