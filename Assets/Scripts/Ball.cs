using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float vallInititalVelocity;

	private Rigidbody rb;
	private bool ballInPlay;
	public GameObject particleEffect;


	// Use this for initialization
	void Start () {
		vallInititalVelocity = 600f;
	}

	void Awake (){
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1") && ballInPlay == false){
			transform.parent = null;
			ballInPlay = true;
			rb.isKinematic = false;
			rb.AddForce( new Vector3 (vallInititalVelocity, vallInititalVelocity, 0));
		}
	}

	void OnCollisionEnter (Collision other){
		Instantiate(particleEffect, transform.position, Quaternion.identity);
	}
}
