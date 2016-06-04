using UnityEngine;
using System.Collections;

public class GameStats : MonoBehaviour {
	[Header("SETTINGS")]
	public float levelTime;
	public bool counting = false;
	public int totalBooks;
	public int sortedBooks;
	public int score = 0;
	public int scoreMod;
	public int scoreDisplay = 900;

	Book[] books;
	// Use this for initialization
	void Start () {
		books = FindObjectsOfType<Book>();
		totalBooks = books.Length;
		StartCoroutine("UpdateScoreDisplay");
		scoreDisplay = Mathf.CeilToInt(levelTime)*10;
		if (!PlayerPrefs.HasKey ("Highscore")) {
			PlayerPrefs.SetInt("Highscore", 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		int i = 0;
		foreach(Book b in books){
			if(b.state == 3){
				i++;
			}
		}
		sortedBooks = i;
		scoreMod = score + Mathf.CeilToInt(levelTime)*10;
		Debug.Log(scoreMod);

		if(levelTime > 0 && sortedBooks < totalBooks && counting){
			levelTime -= Time.deltaTime;
		}
	}

	IEnumerator UpdateScoreDisplay(){
		while(true){
			if(scoreDisplay > scoreMod){
				scoreDisplay--;
			}
			else if(scoreDisplay < scoreMod){
				scoreDisplay++;
			}
			yield return new WaitForSeconds(0.01f);

		}

	}
}
