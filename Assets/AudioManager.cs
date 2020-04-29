using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioSource acceleration;
	public AudioSource slowDown;
	public AudioSource carHit;
	public AudioSource collision;
	public AudioSource explosion;
	public AudioSource backgroudMusic;

	// Use this for initialization
	void Start () {
		backgroudMusic.Play();
		backgroudMusic.loop = true;
		backgroudMusic.ignoreListenerPause = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
