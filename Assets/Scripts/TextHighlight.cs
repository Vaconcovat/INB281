using UnityEngine;
using System.Collections;

public class TextHighlight : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.color = Color.white; 
	
	}
	void OnMouseEnter(){
		GetComponent<Renderer> ().material.color = Color.red;
	}
	void OnMouseExit(){
		GetComponent<Renderer> ().material.color = Color.white;
	}
	// Update is called once per frame

}
