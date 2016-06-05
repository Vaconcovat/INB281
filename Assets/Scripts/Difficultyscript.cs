using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Difficultyscript : MonoBehaviour {
	public bool easy;
	public bool normal;
	public bool hard;
	public int Difficulty = 6;
	GameManager gm;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseUp(){
		if (easy == true) {
			//Difficulty = 4;

			SceneManager.LoadScene ("test");
		} 
		if (normal == true) {

			//Difficulty = 6;
			SceneManager.LoadScene ("test");
		}
		if (hard == true) {

			//Difficulty = 8;
			SceneManager.LoadScene ("test");
		}
	}
}
