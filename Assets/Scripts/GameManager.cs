using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public CharacterController character;
	public FirstPersonController fpc;
	public int totalBooks;

	bool jumping = false;
	GameStats gs;
	InterfaceManager im;
	Bookshelf[] shelves;
	Bookspawn[] spawners;
	GolbalSounds gsounds;
	Rigidbody[] bodies;
	bool failed = false;

	// Use this for initialization
	void Awake () {
		gsounds = FindObjectOfType<GolbalSounds>();
		spawners = FindObjectsOfType<Bookspawn>();
		gs = GetComponent<GameStats>();
		im = GetComponent<InterfaceManager>();
		shelves = FindObjectsOfType<Bookshelf>();
		for (int i = 0; i < shelves.Length; i++){
			Book.BookCategory tempCategory = shelves[i].category;
			int randomShelf = Random.Range(0,shelves.Length);
			shelves[i].category = shelves[randomShelf].category;
			shelves[randomShelf].category = tempCategory;
		}


		//randomise spawners
		for (int i = 0; i < spawners.Length; i++){
			Bookspawn tempSpawn = spawners[i];
			int randomSpawn = Random.Range(0,spawners.Length);
			spawners[i] = spawners[randomSpawn];
			spawners[randomSpawn] = tempSpawn;
		}

		totalBooks = PlayerPrefs.GetInt ("Difficulty");

		for (int i = 0; i < totalBooks - 1; i++){
			spawners[i].Spawn();
		}
		Debug.Log("Highscore: " + PlayerPrefs.GetInt("Highscore"));
	}

	void Start(){
		bodies = FindObjectsOfType<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		if (gs.levelTime <= 0){
			if(!failed){
				failed = true;
				Debug.Log("Subtracting: " + Mathf.FloorToInt(gs.score * 0.3f));
				gs.score -= Mathf.FloorToInt(gs.score * 0.3f);
				character.enabled = false;
				character.GetComponent<Player>().enabled = false;
				fpc.enabled = false;
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				im.fired.color = Color.red;
				im.fired.text = "YOU'RE FIRED\nYOUR SCORE (-30%): " + gs.score.ToString();
				im.retry.SetActive (true);
				im.fader.enabled = true;
				im.timer.enabled = false;
				im.counter.enabled = false;
				SetHighscore(gs.score);
			}
			im.fader.color = new Color(im.fader.color.r, im.fader.color.g, im.fader.color.b, Mathf.Min(im.fader.color.a + Time.deltaTime * 0.5f, 1));

		}

		else if(gs.sortedBooks == gs.totalBooks){
			character.enabled = false;
			fpc.enabled = false;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			im.fired.color = Color.green;
			im.fired.text = "YOU'RE NOT FIRED! (yet)\nYOUR SCORE: " + gs.scoreMod.ToString();
			im.retry.SetActive (true);
			im.fader.enabled = true;
			im.fader.color = new Color(im.fader.color.r, im.fader.color.g, im.fader.color.b, Mathf.Min(im.fader.color.a + Time.deltaTime * 0.5f, 1));
			gsounds.music.volume -= Time.deltaTime * 0.3f;
			SetHighscore(gs.scoreMod);
		}
		else{
			character.enabled = true;
			fpc.enabled = true;
			im.fired.text = "";
			im.retry.SetActive (false);
			im.fader.enabled = false;
			im.fader.color = new Color(0,0,0,0);
			im.Highscore.text = "";
		}

		if(gs.levelTime < 20 && !jumping){
			jumping = true;
			StartCoroutine("Jump");
		}
	}

	public void Exit(){
		SceneManager.LoadScene ("Main Menu");
 
	}

	public void Retry (){
		SceneManager.LoadScene ("test");
	}

	void SetHighscore(int score){
		if (PlayerPrefs.GetInt ("Highscore") < score) {
			PlayerPrefs.SetInt ("Highscore", score);
		}
		im.Highscore.text = "Highscore : " + PlayerPrefs.GetInt ("Highscore");
	}

	IEnumerator Jump(){
		while(true){
			foreach(Rigidbody body in bodies){
				if(body.GetComponent<Book>() == null && Random.value > 0.5f){
						body.AddForce(new Vector3(Random.Range(-1.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(-1.0f,1.0f)).normalized * (10 - (gs.levelTime/2)),ForceMode.Impulse);
				}
			}
			yield return new WaitForSeconds(Random.value/2.0f);
		}

	}
}
