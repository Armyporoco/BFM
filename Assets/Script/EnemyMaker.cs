using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour {

    public float timer;
    GameObject[] enemies = new GameObject[7];
    public bool _isRendered = false;
    public string MAIN_CAMERA_TAG_NAME = "MainCamera";


    private void Awake()
    {
        enemies = Resources.LoadAll<GameObject>("Enemys");
    }

    // Use this for initialization
    void Start () {
        timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;

        if (timer >= 10.0f)
        {
            int random = Random.Range(0, 7);
            if (random != SelectedBFM.instance.index) {
                GameObject obj = Instantiate(enemies[random], this.transform, false) as GameObject;
                Instantiate(obj, this.transform.position, Quaternion.identity);
            } timer = 0.0f;
        }
	}

    private void OnWillRenderObject()
    {
        if(Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {
            _isRendered = true;
        }
    }
}
