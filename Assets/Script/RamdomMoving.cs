﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMoving: MonoBehaviour {

     GameObject[] points;
     GameObject[] enemies = new GameObject[7];
    float timer,speed;
    NavMeshAgent agent;
    Vector3 destination;

    private void Awake()
    {
        enemies = Resources.LoadAll<GameObject>("Enemys");

    }

    // Use this for initialization
    void Start () {
        timer = 0.0f;
        agent = GetComponent<NavMeshAgent>();
        points = GameObject.FindGameObjectsWithTag("point");
        NextDestination();
    }

    // Update is called once per frame
    void Update() {

        timer += Time.deltaTime;

        if (timer >= 10.0f)
        {
            NextDestination();
            timer = 0;

        }		
	}

void NextDestination()
    {
        int index = Random.Range(0, points.Length);
        destination = points[index].transform.position;
        agent.SetDestination(destination);
    }
}

