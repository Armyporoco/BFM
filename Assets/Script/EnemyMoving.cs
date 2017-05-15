using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMoving : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent agent;
    GameObject player;
    GameObject Score;
    public bool _isRendered;
    public string MAIN_CAMERA_TAG_NAME = "MainCamera";

    // Use this for initialization
    void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        Score = GameObject.Find("Score(can)");
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(player.transform.position);

        if(_isRendered)
        { 
            if(Input.GetMouseButtonDown(0) && player.GetComponent<Items>().yonjun == true) {
                Debug.Log("ok!");
                Destroy(this);
            }
        }

    }

    private void OnWillRenderObject()
    {
        if (Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {
            _isRendered = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("damage");
        }
    }
}
