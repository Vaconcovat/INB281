﻿using UnityEngine;
using System.Collections;

public class GameStats : MonoBehaviour {
	[Header("SETTINGS")]
	public float levelTime;
	
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

		levelTime -= Time.deltaTime;
	}
}