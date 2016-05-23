using UnityEngine;
using System.Collections;

public class AngryText : MonoBehaviour {
	[TextArea(1,3)]
	public string[] texts;
	Player p;
	TextMesh tm;
	public float alivetime;
	float timer;

	// Use this for initialization
	void Start () {
		tm = GetComponent<TextMesh>();
		tm.text = texts[Random.Range(0,texts.Length)];
		timer = alivetime;
		p = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(p.transform);
		GetComponent<MeshRenderer>().material.color = new Color(1,0,0,(timer/alivetime));
		timer -= Time.deltaTime;
		if (timer < 0.1f){
			Destroy(gameObject);
		}
	}
}
