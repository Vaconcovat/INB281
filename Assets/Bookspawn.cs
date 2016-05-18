using UnityEngine;
using System.Collections;

public class Bookspawn : MonoBehaviour {
	public GameObject book;

	// Use this for initialization
	void Start () {
		Instantiate(book,transform.position,Random.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
