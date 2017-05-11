using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text Scoretext;
    public GameObject Player;
    public float timer,denemy,score;

	// Use this for initialization
	void Start () {
        timer = 0.0f;
        denemy = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        score = denemy * 2.5f + 1000000/timer;
        Scoretext.text = "Score:" + score.ToString();
	}
}
