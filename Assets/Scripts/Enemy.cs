using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public EnemyPath path;

	private int currentWayPointId;
	private float speed = 5;
	public float rotationSpeed = 3.0f;
	public string pathName;
	private float reachDistance = 1.0f;
	public bool init = false;
	private bool setup = false;

	Vector3 lastPosition;
	Vector3 currentPosition;

	// Use this for initialization
	void Start () {
		if (init)
		{
			currentWayPointId = Random.Range(0, path.path_objs.Count - 1);
			transform.position = path.path_objs[currentWayPointId].position;
			currentWayPointId++;
			setup = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!init)
		{
			return;
		}
		if (!setup)
		{
			currentWayPointId = Random.Range(0, path.path_objs.Count - 1);
			transform.position = path.path_objs[currentWayPointId].position;
			currentWayPointId++;
			setup = true;
		}
		
		float distance = Vector3.Distance(path.path_objs[currentWayPointId].position, transform.position);
		transform.position = Vector3.MoveTowards(transform.position, path.path_objs[currentWayPointId].position, Time.deltaTime * speed);

		var rotation = Quaternion.LookRotation(path.path_objs[currentWayPointId].position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

		if (distance <= reachDistance)
		{
			currentWayPointId++;
		}

		if (currentWayPointId >= path.path_objs.Count) 
		{
			currentWayPointId = 0;
		}
	}
}
