using UnityEngine;
using System.Collections;

public class OrbitingText : MonoBehaviour {
	public Transform gravity;
	public float speed;

	public float alpha;

	// Use this for initialization
	void Start () {
		speed += (Random.Range(0,5));
		if(Random.value > 0.5f){
			speed = -speed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(gravity.position, Vector3.up, speed*Time.deltaTime);
		transform.LookAt(Camera.main.transform.position);
		alpha = 1 - (FindObjectOfType<GameStats>().levelTime / 45);
		GetComponent<MeshRenderer>().material.color = new Color(1,1,1,alpha);
	}

	void OnDrawGizmos(){
		//Gizmos.DrawSphere(gravity.position, Vector3.Distance(transform.position, gravity.position));
	}
}
