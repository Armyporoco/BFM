using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent agent;
    GameObject player;
    public bool _isRendered;
    public string MAIN_CAMERA_TAG_NAME = "MainCamera";

    // Use this for initialization
    void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(player.transform.position);

        if(_isRendered == true)
        {
            gameObject.SetActive(true);
        }

        _isRendered = false;
        gameObject.SetActive(false);
    }

    private void OnWillRenderObject()
    {
        if (Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {
            _isRendered = true;
        }
    }
}
