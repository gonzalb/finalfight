using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	private int nextSceneToLoad;
	

	// Use this for initialization
	void Start () {
		nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return)){
			SoundManagerScript.PlaySound("credit");
        	StartCoroutine("ChangeScene");
		}	
	}

	public IEnumerator ChangeScene()
	{
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene(nextSceneToLoad);
	}
}