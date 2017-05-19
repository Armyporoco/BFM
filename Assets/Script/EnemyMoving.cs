using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMoving : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent agent;
    GameObject player, Score, AI,SelectedBFM;
    public bool alive,poweruped;
    public float timer;
    public int enemyHP;
    public Sprite Otak;

    public int myindex;

    // Use this for initialization
    void Start() {
        enemyHP = 1;
        timer = 0.0f;
        alive = true;
        poweruped = false;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        Score = GameObject.Find("Score_c");
        SelectedBFM = GameObject.Find("SelectedBFM");
        AI = GameObject.Find("AI");
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        agent.SetDestination(player.transform.position);
        if (timer >= 150)
        {
            if (poweruped) { enemyHP = 3; }
            for (int i = 1; i <= 3; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            poweruped = true;
        }
    }

    public void Die()
    {
        if (alive) {
            enemyHP--;
            if (enemyHP <= 0)
            {
                Score.GetComponent<Score>().denemy++;
                alive = false;
            }
        }
        Destroy(gameObject);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AI.GetComponent<AI>().HP--;
            Destroy(this.gameObject);
        }
    }


}
