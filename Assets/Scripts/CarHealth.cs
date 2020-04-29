using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarHealth : MonoBehaviour {
	public float currentHealth {get; set;}
	public float maxHealth {get; set;}
	public GameManager gameManager;
	public Slider healthBar;
	public AudioManager am;

	void Start()
	{
		maxHealth = 20f;
		currentHealth = maxHealth;

		healthBar.value = CalculateHealth();
	}

	void Update()
	{

	}

	void DealDamage(float damageValue)
	{
		currentHealth -= damageValue;
		healthBar.value = CalculateHealth();
		if (currentHealth <= 0)
		{
			Die();
		}
	}

	void OnCollisionEnter2D (Collision2D col) 
	{
     	//Debug.Log ("Hi");
		if (!gameManager.gameHasEnded && GameManager.gameHasStarted)
		{
			if (col.gameObject.tag == "Enemy Car")
			{
				DealDamage(2f);
				am.collision.Play();
			}
			else if (col.gameObject.tag == "Railing")
			{
				am.carHit.Play();
			}
		}
	}

	float CalculateHealth()
	{
		return currentHealth / maxHealth;
	}
	void Die()
	{
		am.explosion.Play();
		am.explosion.ignoreListenerPause = true;
		am.acceleration.Stop();
		am.slowDown.Stop();
		gameManager.EndGame();
	}	
}
