﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Book equipped;
	public Transform anchor;
	public Transform view;
	int layer = 0;
	int layermask;
	// Use this for initialization
	void Start () {
		view = Camera.main.transform;
		layermask = 1 << layer;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){
			Ray ray = new Ray(view.position, view.forward);
			RaycastHit hit;
			if(equipped == null){
				if(Physics.Raycast(ray, out hit,10.0f,layermask)){
					Book book = hit.collider.gameObject.GetComponent<Book>();
					if (book != null){
						if (book.state == 0){
							book.state = 1;
						}
					}
				}
			}
			else{
				equipped.Throw();
			}
		}
		if (Input.GetMouseButtonDown(1) && equipped != null){
			equipped.Drop();
		}
	}
}
