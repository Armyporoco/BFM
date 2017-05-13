using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour {

    public float timer;
    public GameObject EnemyMegane;
    public bool _isRendered = false;
    public string MAIN_CAMERA_TAG_NAME = "MainCamera";


	// Use this for initialization
	void Start () {
        timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        if (_isRendered)
        {
            if (timer >= 5)
            {
                Instantiate(EnemyMegane, this.transform.position, Quaternion.identity);

                timer = 0;
            }
        }

        _isRendered = false;
	}

    private void OnWillRenderObject()
    {
        if(Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {
            _isRendered = true;
        }
    }
}
