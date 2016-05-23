using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InterfaceManager : MonoBehaviour {
	public Text counter;
	public Text timer;
	public Text fired;
	public GameObject retry;
	public Image throwBar;

	TutorialManager tm;

	GameStats gs;
	Player player;
	// Use this for initialization
	void Start () {
		tm = FindObjectOfType<TutorialManager>();
		gs = GetComponent<GameStats>();
		fired.text = "";
		retry.SetActive (false);
		player = FindObjectOfType<Player>();
		//set the counter text
		counter.fontSize = 130;
		counter.enabled = false;

		//do the same for the timer
		timer.fontSize = 130;
		timer.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		counter.text = "Books sorted : " + gs.sortedBooks + " / " + gs.totalBooks;
		timer.text = "TIME REMAINING : " + Mathf.Ceil(gs.levelTime).ToString(); 
		throwBar.fillAmount = (player.throwStrength / player.maxThrow);
		throwBar.color = new Color(1, 1-(player.throwStrength / player.maxThrow), 1-(player.throwStrength / player.maxThrow), 1.0f);

		if(tm.pickedUp && tm.dropped){
			timer.enabled = true;
		}
		if(timer.enabled && timer.fontSize > 30){
			timer.fontSize -= 2;
		}
		if(counter.enabled && counter.fontSize > 30){
			counter.fontSize -= 2;
		}
		if(timer.enabled && timer.fontSize <= 30){
			counter.enabled = true;
		}
	}
}
