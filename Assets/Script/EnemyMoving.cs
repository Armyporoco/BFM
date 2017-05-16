using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMoving : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent agent;
    GameObject player;
    GameObject Score;

    // Use this for initialization
    void Start () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        Score = GameObject.Find("Score_c");
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(player.transform.position);

        if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= 5.0f)
        {
            if (Input.GetMouseButtonDown(1) && player.GetComponent<Items>().yonjun == true)
            {
                Destroy(this.gameObject);
                Score.GetComponent<Score>().denemy += 1f;
            }
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
