using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    private float nextSpawn;
    private Vector3 lineBegin;
    private Vector3 lineEnd;

    private Setttings settings;

    [Inject]
    public void Construct(Setttings settings)
    {
        this.settings = settings;
    }

    [Serializable]
    public class Setttings
    {
        public float spawnPeriod = .5f;
    }

    // Use this for initialization
    void Start ()
	{
	    nextSpawn = Time.time;
	    lineBegin = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
	    lineEnd = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
	    lineBegin.z = 0;
	    lineEnd.z = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Time.time > nextSpawn)
	    {
	        Instantiate(Enemy, Vector3.Lerp(lineBegin, lineEnd, Random.value), Quaternion.identity);
            nextSpawn = Time.time + settings.spawnPeriod;
	    }
	}
}
