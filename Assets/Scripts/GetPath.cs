using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPath : MonoBehaviour {

	public GameObject[] allPaths;

	// Use this for initialization
	void Start () {
		int path = Random.Range(0, allPaths.Length);
		transform.position = allPaths[path].transform.position;
		Enemy enemy_path = GetComponent<Enemy> ();
		enemy_path.pathName = allPaths[path].name;
		enemy_path.path = allPaths[path].GetComponent<EnemyPath> ();
		enemy_path.init = true;
	}
}
