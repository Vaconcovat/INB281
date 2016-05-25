using UnityEngine;
using System.Collections;

public class Bookshelf : MonoBehaviour {
	public Book.BookCategory category;
	public string categoryName;
	public string categoryNameScrambled;
	public bool scrambled;
	GameStats gs;
	InterfaceManager im;
	//public Transform player;
	//public AudioClip ping;
	// Use this for initialization
	void Start () {
		im = FindObjectOfType<InterfaceManager>();
		gs = FindObjectOfType<GameStats>();
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
					book.anger += 1.2f;
				}
			}
		}
	}

	void OnTriggerExit(Collider col){
		if(col.gameObject.GetComponent<Book>() != null){
			Book book = col.gameObject.GetComponent<Book>();
			if(book.state == 3){
				book.state = 0;
				if(book.airDistance > 15){
						im.DisplayMessage("Book fell! (-300)", new Color(0,0,1,1));
						gs.score -= 300;
					}
					else if(book.airDistance > 10){
						im.DisplayMessage("Book fell! (-200)", new Color(0,0,1,1));
						gs.score -= 200;
					}
					else if(book.airDistance > 5){
						im.DisplayMessage("Book fell! (-150)", new Color(0,0,1,1));
						gs.score -= 150;
					}
					else if(book.airDistance > 2){
						im.DisplayMessage("Book fell! (-100)", new Color(0,0,1,1));
						gs.score -= 100;
					}
					else{
						im.DisplayMessage("Book fell! (-50)", new Color(0,0,1,1));
						gs.score -= 50;
					}
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.GetComponent<Book>() != null){
			Book book = col.gameObject.GetComponent<Book>();
			if (book.state == 0){
				if(book.category == this.category){
					book.PlayDing();
					if(book.airDistance > 15){
						im.DisplayMessage("AMAZING!!! " + book.airDistance.ToString("F1") + "m throw! (+300)", new Color(0,1,0,1));
						gs.score += 300;
						im.Score.fontSize += 60;
					}
					else if(book.airDistance > 10){
						im.DisplayMessage("Unreal! " + book.airDistance.ToString("F1") + "m throw! (+200)", new Color(0,1,0,1));
						gs.score += 200;
						im.Score.fontSize += 50;
					}
					else if(book.airDistance > 5){
						im.DisplayMessage("Cool! " + book.airDistance.ToString("F1") + "m throw! (+150)", new Color(0,1,0,1));
						gs.score += 150;
						im.Score.fontSize += 40;
					}
					else if(book.airDistance > 2){
						im.DisplayMessage("Nice! " + book.airDistance.ToString("F1") + "m throw! (+100)", new Color(0,1,0,1));
						gs.score += 100;
						im.Score.fontSize += 30;
					}
					else{
						im.DisplayMessage("Lame. (+50)", new Color(0,1,0,1));
						gs.score += 50;
						im.Score.fontSize += 20;
					}

				}
				else{
					book.PlayBoo();
					im.DisplayMessage("WRONG (-20)", new Color(1,0,0,1));
					gs.score -= 20;
				}
			}
		}
	}
}
