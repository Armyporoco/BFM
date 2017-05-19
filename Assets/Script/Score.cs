using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    public Text Scoretext;
    public GameObject Player,Light;
    public float timer,denemy,score;

	// Use this for initialization
	void Start () {
        timer = 0.0f;
        denemy = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        Light.transform.Rotate(new Vector3(0f, timer/108000 , 0f));
        score = denemy * 2.5f;
        Scoretext.text = score.ToString();
        if(timer >= 300)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
