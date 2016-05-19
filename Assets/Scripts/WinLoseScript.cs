using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinLoseScript : MonoBehaviour {
	public bool Successful = false;
	GameStats gs;
	// Use this for initialization
	void Start () {
		gs = GetComponent<GameStats> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gs.levelTime <= 0 && gs.sortedBooks >= 4) {
			Successful = true;
			SceneManager.LoadScene (2);
		} else if (gs.levelTime <= 0 && gs.sortedBooks < 4) {
			SceneManager.LoadScene (2);
		}
			else{
			Successful = false;
		
		}

	
	}
}
