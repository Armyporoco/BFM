using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMoving : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent agent;
    GameObject player, Score, AI;
    public bool alive;

    // Use this for initialization
    void Start() {
        alive = true;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        Score = GameObject.Find("Score_c");
        AI = GameObject.Find("AI");
    }

    // Update is called once per frame
    void Update() {
        agent.SetDestination(player.transform.position);
    }

    public void Die()
    {
        if (alive) { Score.GetComponent<Score>().denemy++; alive = false; }
        Destroy(this.gameObject);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("damage");
        }
    }
}
