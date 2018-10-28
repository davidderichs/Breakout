﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	public int lives = 3;
	public int bricks = 24;
	public float resetDelay = 1f;
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	public static GM instance = null;

	private GameObject clonePaddle;

	// Use this for initialization
	void Start () {
		// If we don't have a GM, instance it to this
		if(instance == null)
			instance = this;	
		else if(instance != this)
			Destroy (gameObject);	
		
		Setup();
	}

	public void Setup(){
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
		Instantiate(bricksPrefab, new Vector3(0f,-4.5f,0f), Quaternion.identity);
	}

	void CheckGameOver(){
		if (bricks < 1){
			youWon.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}

		if(lives < 1){
			gameOver.SetActive(true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}
	}

	void Reset(){
		Time.timeScale = 1f;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void LoseLife(){
		lives--;
		livesText.text = "Lives: " + lives;
		Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy(clonePaddle);
		Invoke("SetupPaddle", resetDelay);
		CheckGameOver();
	}

	void SetupPaddle(){
		Destroy(deathParticles);
		clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
	}

	public void DestroyBrick(){
		bricks--;
		CheckGameOver();
	}
}
