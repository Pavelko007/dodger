using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;

    public Transform LineBegin;

    public Transform LineEnd;
    private float nextSpawn;
    public float spawnPeriod = .5f;


    // Use this for initialization
	void Start ()
	{
	    nextSpawn = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Time.time > nextSpawn)
	    {
	        Instantiate(Enemy, Vector3.Lerp(LineBegin.position, LineEnd.position, Random.value), Quaternion.identity);
	        nextSpawn = Time.time + spawnPeriod;
	    }
	}
}
