using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class GameManager : MonoBehaviour {
	public CharacterController character;
	public FirstPersonController fpc;

	GameStats gs;
	InterfaceManager im;
	Bookshelf[] shelves;

	// Use this for initialization
	void Start () {
		gs = GetComponent<GameStats>();
		im = GetComponent<InterfaceManager>();
		shelves = FindObjectsOfType<Bookshelf>();
		for (int i = 0; i < shelves.Length; i++){
			Book.BookCategory tempCategory = shelves[i].category;
			int randomShelf = Random.Range(0,shelves.Length);
			shelves[i].category = shelves[randomShelf].category;
			shelves[randomShelf].category = tempCategory;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (gs.levelTime <= 0){
			character.enabled = false;
			fpc.enabled = false;
			Cursor.lockState = CursorLockMode.None;
			im.fired.text = "YOU'RE FIRED";
		}
		else if(gs.sortedBooks == gs.totalBooks){
			character.enabled = false;
			fpc.enabled = false;
			Cursor.lockState = CursorLockMode.None;
			im.fired.text = "YOU'RE NOT FIRED! (yet)\nTIME REMAINING: " + gs.levelTime.ToString();
		}
		else{
			character.enabled = true;
			fpc.enabled = true;
			im.fired.text = "";
		}
	}
}
