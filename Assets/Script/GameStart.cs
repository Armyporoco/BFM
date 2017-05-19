using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStart : MonoBehaviour {

    public GameObject[] canvas = new GameObject[4];
    int i;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            if (i < 3)
            {
                canvas[i + 1].SetActive(true);
                canvas[i].SetActive(false);
            }
            if (i == 3)
            {
                SceneManager.LoadScene("Random");
            }
            i++;
        }
        	
	}
}
