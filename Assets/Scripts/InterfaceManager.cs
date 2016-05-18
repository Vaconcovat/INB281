using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InterfaceManager : MonoBehaviour {
	public Text counter;
	public Text timer;
	public Text fired;

	GameStats gs;
	// Use this for initialization
	void Start () {
		gs = GetComponent<GameStats>();
		fired.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		counter.text = "Books sorted : " + gs.sortedBooks + " / " + gs.totalBooks;
		timer.text = "TIME REMAINING : " + Mathf.Ceil(gs.levelTime).ToString(); 
	}
}
