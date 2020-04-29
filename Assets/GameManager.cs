using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public bool gameHasEnded = false;
	public bool gameHasCompleted = false;
	public static bool gameHasStarted = false;

	public float restartDelay = 5f;
	public float nextLevelDelay = 5f;

	public GameObject completeLevelUI;
	public GameObject loseLevelUI;
	public GameObject timerUI;
	public GameObject healthBarUI;
	public GameObject scoreUI;


	public void LevelComplete()
	{
		
		if (!gameHasCompleted && gameHasStarted)
		{
			completeLevelUI.SetActive(true);
			timerUI.SetActive(false);
			healthBarUI.SetActive(false);
			scoreUI.SetActive(true);
			gameHasCompleted = true;
			Debug.Log("GameOver");
			Invoke("LoadNextLevel", nextLevelDelay);
		}
	}

	public void EndGame()
	{
		if (!gameHasEnded)
		{
			loseLevelUI.SetActive(true);
			timerUI.SetActive(false);
			healthBarUI.SetActive(false);
			gameHasEnded = true;
			//Debug.Log("GameOver");
			Invoke("Restart", restartDelay);
		}
	}

	void Restart()
	{
		AudioListener.pause = false;
		gameHasCompleted = false;
		gameHasEnded = false;
		gameHasStarted = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	void LoadNextLevel()
	{
		AudioListener.pause = false;
		gameHasStarted = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
