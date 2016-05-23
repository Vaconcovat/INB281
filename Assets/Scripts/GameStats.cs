using UnityEngine;
using System.Collections;

public class GameStats : MonoBehaviour {
	[Header("SETTINGS")]
	public float levelTime;
	public bool counting = false;
	public int totalBooks;
	public int sortedBooks;

	Book[] books;
	// Use this for initialization
	void Start () {
		books = FindObjectsOfType<Book>();
		totalBooks = books.Length;
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
		if(levelTime > 0 && sortedBooks < totalBooks && counting){
			levelTime -= Time.deltaTime;
		}
	}
}
