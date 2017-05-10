using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdomMoving : MonoBehaviour {

    public GameObject BFM;
    public Vector3 move;
    public float timer,speed;

	// Use this for initialization
	void Start () {
        timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        while (timer <= 3.0f) {
            move =  new Vector3(Random.Range(-5,6),Random.Range(-5,6),0);
            BFM.transform.position += move * speed;

            timer = 0.0f;
        }
		
	}
}
