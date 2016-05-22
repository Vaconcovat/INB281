using UnityEngine;
using System.Collections;

public class TutorialManager : MonoBehaviour {
	bool pickedUp = false;

	public Book tutorialBook;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(tutorialBook.state == 2){
			pickedUp = true;
		}
		if(pickedUp){
			GetComponent<TextMesh>().text = "Hold LMB to thow.\nPress RMB to drop.";
		}
		if(tutorialBook.state == 0 && pickedUp){
			//Destroy(gameObject);
			GetComponent<TextMesh>().text = "Sort as many books \nas you can!";
		}
	}
}
