using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InterfaceManager : MonoBehaviour {
	public Text counter;
	public Text timer;
	public Text fired;
	public GameObject retry;
	public Image throwBar;

	GameStats gs;
	Player player;
	// Use this for initialization
	void Start () {
		gs = GetComponent<GameStats>();
		fired.text = "";
		retry.SetActive (false);
		player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		counter.text = "Books sorted : " + gs.sortedBooks + " / " + gs.totalBooks;
		timer.text = "TIME REMAINING : " + Mathf.Ceil(gs.levelTime).ToString(); 
		throwBar.fillAmount = (player.throwStrength / player.maxThrow);
		throwBar.color = new Color(1, 1-(player.throwStrength / player.maxThrow), 1-(player.throwStrength / player.maxThrow), 1.0f);
	}
}
