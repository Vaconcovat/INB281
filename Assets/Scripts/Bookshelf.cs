using UnityEngine;
using System.Collections;

public class Bookshelf : MonoBehaviour {
	public Book.BookCategory category;
	public string categoryName;
	public string categoryNameScrambled;
	public bool scrambled;
	public GameObject ping;
	public GameObject angry;
	//public Transform player;
	//public AudioClip ping;
	// Use this for initialization
	void Start () {
		ping.SetActive (false);
		angry.SetActive (false);
		categoryName = category.ToString();
		if(scrambled){
			char[] characters = new char[categoryName.Length];
			for (int i = 0; i < categoryName.Length; i++){
				characters[i] = categoryName[i];
			}
			categoryNameScrambled = new string(Book.Randomize(characters));
			GetComponentInChildren<TextMesh>().text = categoryNameScrambled;
		}
		else{
			GetComponentInChildren<TextMesh>().text = categoryName;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void pingSound(){
		ping.SetActive (false);
	}

	void angrySound(){
		angry.SetActive (false);
	}

	void OnTriggerStay(Collider col){
		if(col.gameObject.GetComponent<Book>() != null){
			Book book = col.gameObject.GetComponent<Book>();
			if (book.state == 0){
				if(book.category == this.category){
					book.state = 3;
					ping.SetActive (true);
					Invoke("pingSound", 2.0f);


				}
				else{
					book.anger += 1.2f;
					angry.SetActive (true);
					Invoke("angrySound", 8.0f);
				}
			}
		}
	}

	void OnTriggerExit(Collider col){
		if(col.gameObject.GetComponent<Book>() != null){
			Book book = col.gameObject.GetComponent<Book>();
			if(book.state == 3){
				book.state = 0;
			}
		}
	}
}
