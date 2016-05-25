using UnityEngine;
using System.Collections;

public class OrbitingText : MonoBehaviour {
	public Transform gravity;
	public float speed;
	GameStats gs;
	public float alpha;

	// Use this for initialization
	void Start () {
		gs = FindObjectOfType<GameStats>();
		speed += (Random.Range(0,5));
		if(Random.value > 0.5f){
			speed = -speed;
		}
		transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(-1,3),transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(gravity.position, Vector3.up, speed*Time.deltaTime);
		transform.LookAt(Camera.main.transform.position);
		alpha = 1 - (FindObjectOfType<GameStats>().levelTime / 45);
		GetComponent<MeshRenderer>().material.color = new Color(1,1,1,alpha);

		if(gs.levelTime < 20){
			if(speed > 0){
				speed += Time.deltaTime * 4;
			}
			else{
				speed -= Time.deltaTime * 4;
			}
		}
	}

}
