using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour {

    public float timer;
    public GameObject EnemyMegane;

	// Use this for initialization
	void Start () {
        timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        
        if(timer >= 5)
        {
            Instantiate(EnemyMegane, this.transform.position,Quaternion.identity);

            timer = 0;
        } 
		
	}
}
