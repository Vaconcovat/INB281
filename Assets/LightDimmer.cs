using UnityEngine;
using System.Collections;

public class LightDimmer : MonoBehaviour {
	Light l;
	GameStats gs;

	// Use this for initialization
	void Start () {
		l = GetComponent<Light>();
		gs = FindObjectOfType<GameStats>();
	}
	
	// Update is called once per frame
	void Update () {
		l.intensity = Mathf.Lerp(0.65f,0.10f,(1-(gs.levelTime/90.0f)));
	}
}
