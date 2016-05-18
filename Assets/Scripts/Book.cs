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
	float jumpInterval;
	public float jumpForce;
	public float anger;
	float jumpTimer;
	/// <summary>
	/// State of the book. 0 for free, 1 for equipping and 2 for equipped, 3 for correctly placed
	/// </summary>
	public int state;
	public Material outlinedMaterial;
	public Material angryMaterial;
	public Material defaultMaterial;
	public MeshRenderer pages;


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
		category = (BookCategory)Random.Range(0,8);
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
				GetComponentInChildren<TextMesh>().text = categoryNameScrambled;
				if (Vector3.Distance(this.transform.position, player.transform.position) > 5.0f){
					pages.material = outlinedMaterial;
				}
				else{
					pages.material = defaultMaterial;
				}
				break;
			case 1:
				body.isKinematic = true;
				transform.position = Vector3.MoveTowards(transform.position, player.anchor.position, 1.0f);
				player.equipped = this;
				if (Vector3.Distance(transform.position, player.anchor.position) < 1.0f){
					state = 2;
				}
				GetComponentInChildren<TextMesh>().text = categoryNameScrambled;
				pages.material = defaultMaterial;
				break;
			case 2:
				body.isKinematic = true;
				//transform.position = player.anchor.position;
				transform.position = Vector3.MoveTowards(transform.position, player.anchor.position, 1.0f);
				transform.rotation = player.anchor.rotation;
				GetComponentInChildren<TextMesh>().text = categoryNameScrambled;
				pages.material = defaultMaterial;
				break;
			case 3:
				GetComponentInChildren<TextMesh>().text = "";
				pages.material = defaultMaterial;
				break;
		}
		if (anger > 0){
			jumpInterval = 50.0f / anger;
			jumpTimer -= Time.deltaTime;
			anger -= 0.7f;
			if (jumpTimer <= 0 && state != 3){
				jumpTimer = jumpInterval;
				Jump();
			}
			pages.material = angryMaterial;
		}
		else if (anger <= 0){
			anger = 0;
		}
		if (jumpInterval < jumpTimer){
			jumpTimer = jumpInterval;
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
		body.AddForce(player.view.forward.normalized * 17.0f, ForceMode.Impulse);
		body.AddTorque(Random.rotation.eulerAngles);
	}

	void Jump(){
		body.AddForce(new Vector3(Random.Range(-1.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(-1.0f,1.0f)).normalized * jumpForce,ForceMode.Impulse);
	}

}
