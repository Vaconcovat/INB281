using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Book : MonoBehaviour {
	public enum BookCategory{ROMANCE, DRAMA, HISTORY, HORROR, POETRY, FANTASY, SCIENCE, RELIGION};

	Rigidbody body;
	string categoryName;
	string categoryNameScrambled;

	public BookCategory category;
	public Player player;
	/// <summary>
	/// State of the book. 0 for free, 1 for equipping and 2 for equipped, 3 for correctly placed
	/// </summary>
	public int state;

	public static T[] Randomize<T>(T[] source){
		List<T> randomized = new List<T>();
		List<T> original = new List<T>(source);
		for (int i = original.Count; i > 0; i--){
			int index = Random.Range(0,i);
			randomized.Add(original[index]);
			original[index] = original[i - 1];
		}
		return randomized.ToArray();
	}

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody>();
		player = FindObjectOfType<Player>();
		categoryName = category.ToString();
		char[] characters = new char[categoryName.Length];
		for (int i = 0; i < categoryName.Length; i++){
			characters[i] = categoryName[i];
		}
		categoryNameScrambled = new string(Randomize(characters));
		GetComponentInChildren<TextMesh>().text = categoryNameScrambled;
	}
	
	// Update is called once per frame
	void Update () {
		switch(state){
			case 0:
				body.isKinematic = false;
				break;
			case 1:
				body.isKinematic = true;
				transform.position = Vector3.MoveTowards(transform.position, player.anchor.position, 1.0f);
				player.equipped = this;
				if (Vector3.Distance(transform.position, player.anchor.position) < 1.0f){
					state = 2;
				}
				break;
			case 2:
				body.isKinematic = true;
				transform.position = player.anchor.position;
				transform.rotation = player.anchor.rotation;
				break;
			case 3:
				GetComponentInChildren<MeshRenderer>().material.color = Color.yellow;
				break;
		}
	}

	public void Drop(){
		state = 0;
		player.equipped = null;
		body.isKinematic = false;
	}

	public void Throw(){
		state = 0;
		player.equipped = null;
		body.isKinematic = false;
		body.AddForce(player.view.forward.normalized * 20.0f, ForceMode.Impulse);
	}


}
