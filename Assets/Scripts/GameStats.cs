using UnityEngine;
using System.Collections;

public class GameStats : MonoBehaviour {
	[Header("SETTINGS")]
	public float levelTime;
	public bool counting = false;
	public int totalBooks;
	public int sortedBooks;
	public int score;
	public int highscore = 0;

	Book[] books;
	// Use this for initialization
	void Start () {
		books = FindObjectsOfType<Book>();
		totalBooks = books.Length;
	}
	
	// Update is called once per frame
	void Update () {
		int i = 0;
		int s = 0;
		foreach(Book b in books){
			if(b.state == 3){
				i++;
				s = s + 5;
			}
		}
		sortedBooks = i;
		score = s;
		if (score > highscore) {
			highscore = score;
		}

		if(levelTime > 0 && sortedBooks < totalBooks && counting){
			levelTime -= Time.deltaTime;
		}
	}
}
