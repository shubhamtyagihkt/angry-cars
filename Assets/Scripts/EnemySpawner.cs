using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] cars;
	public int carCount = 5;

	private int carSpawned = 0;
	private int carNum;

	private double spawnTimer = 1f;
	private double timeToSpawn = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (carSpawned < carCount && timeToSpawn > spawnTimer)
		{
			carNum = Random.Range(0, cars.Length);
			Instantiate(cars[carNum]);
			carSpawned++;
			timeToSpawn = 0;
		}
		timeToSpawn += Time.deltaTime;
	}
}
