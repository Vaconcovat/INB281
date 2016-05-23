using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class TutorialManager : MonoBehaviour {
	public bool pickedUp = false;
	public bool dropped = false;
	FirstPersonController controller;
	GameStats gs;
	public Book tutorialBook;


	// Use this for initialization
	void Start () {
		controller = FindObjectOfType<FirstPersonController>();
		controller.m_WalkSpeed = 0;
		controller.m_RunSpeed = 0;
		gs = FindObjectOfType<GameStats>();
	}
	
	// Update is called once per frame
	void Update () {
		if(tutorialBook.state == 2){
			pickedUp = true;
		}
		if(pickedUp && !dropped){
			GetComponent<TextMesh>().text = "Hold LMB to thow.\nPress RMB to drop.";
		}
		if(tutorialBook.state != 2 && pickedUp){
			dropped = true;
			gs.counting = true;
			//Destroy(gameObject);
			controller.m_WalkSpeed = 5;
			controller.m_RunSpeed = 10;
			GetComponent<TextMesh>().text = "Un-Jumble and return as many \nbooks to their genre as you can";
		}
	}
}
