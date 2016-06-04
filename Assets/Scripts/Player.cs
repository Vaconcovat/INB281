using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Book equipped;
	public Transform anchor;
	public Transform view;
	public LayerMask layerm;
	public float throwStrength;
	public float maxThrow;
	InterfaceManager im;
	// Use this for initialization
	void Start () {
		view = Camera.main.transform;
		im = FindObjectOfType<InterfaceManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){
			if(equipped != null){
				throwStrength = Mathf.Min(throwStrength + (Time.deltaTime * 15), maxThrow);
			}
		}
		if (Input.GetMouseButtonUp(0)){
			if (equipped != null){
				if(throwStrength > 5.0f){
					equipped.Throw(throwStrength);
				}
			}
			throwStrength = 0;
		}
		if (Input.GetKeyDown(KeyCode.E)){
			if(equipped == null){
				Ray ray = new Ray(view.position, view.forward);
				RaycastHit hit;
				if(Physics.Raycast(ray, out hit,10.0f,layerm.value)){
					Book book = hit.collider.gameObject.GetComponent<Book>();
					if (book != null){
						if (book.state == 0){
							book.state = 1;
						}
					}
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.E) && equipped != null){
			equipped.Drop();
		}

		if(equipped != null){
			im.hintText.text = "HOLD LMB: Throw\nE: Drop";
		}
		else{
			Ray ray2 = new Ray(view.position, view.forward);
				RaycastHit hit2;
				if(Physics.Raycast(ray2, out hit2,10.0f,layerm.value)){
					Book book = hit2.collider.gameObject.GetComponent<Book>();
					if (book != null){
						im.hintText.text = "E: Pick Up";
					}
					else{
						im.hintText.text = "";
					}
				}
				else{
					im.hintText.text = "";
				}
		}
	}
}
