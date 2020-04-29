using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour {

	public GameManager gameManager;

	void OnTriggerEnter2D()
	{
		gameManager.LevelComplete();
	}

}
