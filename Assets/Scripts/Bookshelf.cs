using UnityEngine;
using System.Collections;

public class Bookshelf : MonoBehaviour {
	public Book.BookCategory category;
	public string categoryName;
	public string categoryNameScrambled;
	public bool scrambled;
	// Use this for initialization
	void Start () {
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

	void OnTriggerStay(Collider col){
		if(col.gameObject.GetComponent<Book>() != null){
			Book book = col.gameObject.GetComponent<Book>();
			if (book.state == 0){
				if(book.category == this.category){
					book.state = 3;
				}
				else{
					book.anger += 1.0f;
				}
			}
		}
	}
}
