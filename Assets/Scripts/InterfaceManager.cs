using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InterfaceManager : MonoBehaviour {
	public Text counter;
	public Text timer;
	public Text fired;
	public GameObject retry;

	GameStats gs;
	// Use this for initialization
	void Start () {
		gs = GetComponent<GameStats>();
		fired.text = "";
		retry.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		counter.text = "Books sorted : " + gs.sortedBooks + " / " + gs.totalBooks;
		timer.text = "TIME REMAINING : " + Mathf.Ceil(gs.levelTime).ToString(); 
	}
}
