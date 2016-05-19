using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour {

	public bool start;
	public bool quit;
	public bool mainmenu;
	// Use this for initialization
	void Start () {
		//GetComponent<Renderer> ().material.color = Color.white;
	}

	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseUp(){
		if (start) {
			SceneManager.LoadScene ("test");
		}
		if (quit) {
			Application.Quit ();
		}
		if (mainmenu) {
			SceneManager.LoadScene ("Main menu");
		}
	}
}
