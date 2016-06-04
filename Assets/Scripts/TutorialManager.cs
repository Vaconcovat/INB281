using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;

public class TutorialManager : MonoBehaviour {
	public bool pickedUp = false;
	public bool held = false;
	public bool dropped = false;
	FirstPersonController controller;
	GameStats gs;
	public Book tutorialBook;
	public GameObject hider;


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
			GetComponent<TextMesh>().text = "Book categories \nare scrambled.\n\nWASD to move.\nHold LMB to thow.\nPress E again to drop.";
			controller.m_WalkSpeed = 5;
			controller.m_RunSpeed = 10;
		}
		if(tutorialBook.state != 2 && pickedUp){
			held = true;
		}
		if(held && pickedUp){
			dropped = true;
			gs.counting = true;
			//Destroy(gameObject);
			GetComponent<TextMesh>().text = "Library closes in:\n" + Mathf.Floor((gs.levelTime/60)).ToString("00") + ":" + (gs.levelTime % 60).ToString("00") + "\n Get to work!";
			FindObjectOfType<GolbalSounds>().StartMusic();
			hider.SetActive(false);
			transform.position = new Vector3(transform.position.x + Time.deltaTime, transform.position.y, transform.position.z);
			GetComponent<TextMesh>().fontSize = 70;
		}
	}
}
