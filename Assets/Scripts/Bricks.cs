using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {
	public GameObject brickParticle;

	void OnCollisionEnter (Collision other){
		brickParticle.active = true;
		Instantiate(brickParticle, this.transform.position, Quaternion.identity);
		GM.instance.DestroyBrick();
		Destroy(brickParticle);
		Destroy(gameObject);		
	}
}
