using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtBFM : MonoBehaviour {

    public Transform BFM;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.LookAt(BFM);

	}
}
