using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform startPosition;

    public float delayMin = 1.5F;
    public float delayMax = 5;
    public float speedMin = 1;
    public float speedMax = 4;

    public bool isStationaryObject = false;
    public int spawnCountMin = 4;
    public int spawnCountMax = 20;

    private float lastTime = 0;
    private float delayTime = 0;
    private float speed = 0;

    [HideInInspector] public GameObject obj;
    [HideInInspector] public bool turnLeft = false;
    [HideInInspector] public float spawnLeftPos = 0;
    [HideInInspector] public float spawnRightPos = 0;
    
    
    // Use this for initialization
	void Start ()
    {
        if (isStationaryObject)
        {
            int spawnCount = Random.Range(spawnCountMin, spawnCountMax);

            for (int i = 0; i < spawnCount; i++)
            {
                SpawnObject();
            }

        }

        else
        {
            speed = Random.Range(speedMin, speedMax);
        }
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isStationaryObject)
        {
            return;
        }

        if (Time.time > lastTime + delayTime)
        {
            lastTime = Time.time;
            delayTime = Random.Range(delayMin, delayMax);
            SpawnObject();
        }
		
	}

    void SpawnObject()
    {
        GameObject item = Instantiate(obj) as GameObject;
        item.transform.position = GetSpawnPos();
        float direction = 0;
        if (turnLeft)
        {
            direction = 180;
        }

        if (!isStationaryObject)
        {
            item.GetComponent<ObjectsMover>().speed = speed;
            item.transform.rotation = item.transform.rotation * Quaternion.Euler(0, direction, 0);
        }

        
    }

    Vector3 GetSpawnPos()
    {
        if (isStationaryObject)
        {
            return new Vector3(Random.Range(spawnLeftPos, spawnRightPos), startPosition.position.y, startPosition.position.z);
        }
        else
        {
            return startPosition.position;
        }

        //return startPosition.position;
    }
}
