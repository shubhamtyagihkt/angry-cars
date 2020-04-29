using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Car2dController : MonoBehaviour {

	float speedForce = 8f;
	float torqueForce = 100f;
	private float driftFactorSticky = 0.9f;
	private float driftFactorSlippy = 1f;
	private float maxSticyVelcoty = 5f;
	private float minSlippyVelocity = 3f;
	private bool drifting = false;

	public Text timer;
	public Text score;
	private float scoreRightNow = 0;
	private float timeElapsed = 0;
	private float levelMaxTime = 100;
	private float levelScore = 50;
	public AudioManager am;

	public GameManager gm;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Cancel") == 1) {
			SceneManager.LoadScene("Credits");
		}

		if (Input.GetKeyDown("w"))
        {
            am.acceleration.Play();
			am.acceleration.loop = true;
        }
		if (Input.GetKeyUp("w"))
        {
			am.slowDown.Play();
			am.acceleration.Stop();
        }

		if (!gm.gameHasCompleted && GameManager.gameHasStarted)
		{
			timeElapsed += Time.deltaTime;
			scoreRightNow = Math.Max(0, levelMaxTime - timeElapsed) * levelScore;
			timer.text = "Time: " + timeElapsed.ToString("0");
			score.text = "Score: " + scoreRightNow.ToString("0");
		}
		if (gm.gameHasCompleted || gm.gameHasEnded)
		{
			AudioListener.pause = true;
		}
		
	}

	// this is physics engine update
	// physics engine update is not necessarily in sync with graphics update
	// usually they run on diffrent threads
	void FixedUpdate() {
		if (GameManager.gameHasStarted)
		{
			Rigidbody2D rb = GetComponent<Rigidbody2D>();
			float driftFactor;
			//Debug.Log(RightVelocity().magnitude);
			if (drifting)
			{
				driftFactor = RightVelocity().magnitude > minSlippyVelocity ? driftFactorSlippy : driftFactorSticky;
				if (driftFactor < driftFactorSlippy) drifting = false;
			}
			else
			{
				driftFactor = RightVelocity().magnitude > maxSticyVelcoty ? driftFactorSlippy : driftFactorSticky;
				if (driftFactor > driftFactorSticky) drifting = true;
			}
			
			rb.velocity = ForwardVelocity() + RightVelocity() * driftFactor;

			if (Input.GetButton("Accelerate")) {
				rb.AddForce( transform.up * speedForce );
			}

			if (Input.GetButton("Brakes")) {
				rb.AddForce( transform.up * (-speedForce)/2 );
			}

			float tf = Mathf.Lerp(0, torqueForce, rb.velocity.magnitude / 5);
			rb.angularVelocity =  Input.GetAxis("Horizontal") * tf;
		}
	}

	Vector2 ForwardVelocity() {
		return transform.up * Vector2.Dot( GetComponent<Rigidbody2D>().velocity, transform.up);
	}

	Vector2 RightVelocity() {
		return transform.right * Vector2.Dot( GetComponent<Rigidbody2D>().velocity, transform.right);
	}	
}
