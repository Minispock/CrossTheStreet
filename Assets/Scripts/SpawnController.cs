using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public bool goLeft;
    public bool goRight;

    public List<GameObject> cars = new List<GameObject>();
    public List<Spawner> spawnersLeft = new List<Spawner>();
    public List<Spawner> spawnerRight = new List<Spawner>();
    
    // Use this for initialization
	void Start () {

        int carNum = Random.Range(0, cars.Count);
        GameObject car = cars[carNum];//vidoe #054
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
