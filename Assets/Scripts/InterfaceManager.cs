using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InterfaceManager : MonoBehaviour {
	public Text counter;
	public Text timer;
	public Text fired;
	public Text Score;
	public Text highscore;
	public GameObject retry;
	public Image throwBar;
	public Image fader;
	public Text MessageText;

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

		//set the score text as well
		Score.fontSize = 130;
		Score.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
		counter.text = "Books sorted : " + gs.sortedBooks + " / " + gs.totalBooks;
		timer.text = "TIME REMAINING : " + Mathf.Floor((gs.levelTime/60)).ToString("00") + ":" + (gs.levelTime % 60).ToString("00"); 
		Score.text = "Score : " + gs.scoreDisplay;
		//highscore.text = "HighScore : " + gs.Highscore;
		throwBar.fillAmount = (player.throwStrength / player.maxThrow);
		throwBar.color = new Color(1, 1-(player.throwStrength / player.maxThrow), 1-(player.throwStrength / player.maxThrow), 1.0f);

		if(tm.pickedUp && tm.dropped){
			timer.enabled = true;
		}
		if(timer.enabled && timer.fontSize <= 30){
			counter.enabled = true;
		}
		if(counter.enabled && counter.fontSize <= 30){
			Score.enabled = true;
		}

		if(timer.enabled && timer.fontSize > 30){
			timer.fontSize -= 1;
		}
		if(counter.enabled && counter.fontSize > 30){
			counter.fontSize -= 1;
		}
		if(Score.enabled && Score.fontSize > 30){
			Score.fontSize -= 1;
		}
		MessageText.color = new Color(MessageText.color.r, MessageText.color.g, MessageText.color.b, Mathf.Max(MessageText.color.a - Time.deltaTime * 0.5f, 0));
	}

	public void DisplayMessage(string message, Color c){
		MessageText.color = c;
		MessageText.text = message;
	}
}
