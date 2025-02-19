﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextScene : MonoBehaviour {

	private int nextSceneToLoad;

	void Start () 
	{
		nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
	}
	
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
			SceneManager.LoadScene(nextSceneToLoad);
		}		
	}
}
