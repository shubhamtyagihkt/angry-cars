using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour {

	public int countDownTime;
	public Text countDownDisplay;

	

	// Use this for initialization
	void Start () {
		StartCoroutine(CountDownToStart());
	}
	
	IEnumerator CountDownToStart()
	{
		while (countDownTime > 0)
		{
			countDownDisplay.text = countDownTime.ToString();

			yield return new WaitForSeconds(1f);

			countDownTime--;
		}

		countDownDisplay.text = "GO!";

		GameManager.gameHasStarted = true;

		yield return new WaitForSeconds(1f);

		countDownDisplay.gameObject.SetActive(false);
		AudioListener.pause = false;
	}
}
