using UnityEngine;
using System.Collections;

public class AngryText : MonoBehaviour {
	[TextArea(1,3)]
	public string[] texts;
	TextMesh tm;
	public float alivetime;
	float timer;

	// Use this for initialization
	void Start () {
		tm = GetComponent<TextMesh>();
		tm.text = texts[Random.Range(0,texts.Length)];
		timer = alivetime;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(Camera.main.transform.position);
		GetComponent<MeshRenderer>().material.color = new Color(1,0,0,(timer/alivetime));
		timer -= Time.deltaTime;
		if (timer < 0.1f){
			Destroy(gameObject);
		}
	}
}
