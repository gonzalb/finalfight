using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

	public static AudioClip HaggarDoubleLariatSound, HaggarPunchSound;
	public static AudioClip hitSound, enemydieSound;
	public static AudioClip explodeSound, powerupSound, brokenboxSound;
	public static AudioClip creditSound;

	static AudioSource AudioSource;
	// Use this for initialization
	void Start () {

		HaggarDoubleLariatSound = Resources.Load<AudioClip>("doubleariat");
		HaggarPunchSound = Resources.Load<AudioClip>("punch");
		
		hitSound = Resources.Load<AudioClip>("hit");
		enemydieSound = Resources.Load<AudioClip>("enemydie");
		
		explodeSound = Resources.Load<AudioClip>("explode");
		powerupSound = Resources.Load<AudioClip>("powerup");
		brokenboxSound = Resources.Load<AudioClip>("brokenbox");

		creditSound = Resources.Load<AudioClip>("credit");

		AudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void PlaySound (string clip)
	{
		switch (clip)
		{
			case "doubleariat":
				AudioSource.PlayOneShot(HaggarDoubleLariatSound);
				break;
			case "punch":
				AudioSource.PlayOneShot(HaggarPunchSound);
				break;
			case "hit":
				AudioSource.PlayOneShot(hitSound);
				break;
			case "enemydie":
				AudioSource.PlayOneShot(enemydieSound);
				break;
			case "explode":
				AudioSource.PlayOneShot(explodeSound);
				break;
			case "powerup":
				AudioSource.PlayOneShot(powerupSound);
				break;
			case "brokenbox":
				AudioSource.PlayOneShot(brokenboxSound);
				break;
			case "credit":
				AudioSource.PlayOneShot(creditSound);
				break;	
		}
	}
	
}
