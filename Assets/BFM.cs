using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BFM : MonoBehaviour
{
    GameObject[] points;
    GameObject[] enemies = new GameObject[7];
    float timer, speed;
    NavMeshAgent agent;
    Vector3 destination;

    private void Awake()
    {
        enemies = Resources.LoadAll<GameObject>("Enemys");
        //  for (int i = 0; i < enemies.Length; i++)
        //   {
        //   enemies[i] = Resources.Load<GameObject>(enemies[i].name);
        //   }
    }

    // Use this for initialization
    void Start()
    {
        timer = 0.0f;
        agent = GetComponent<NavMeshAgent>();
        points = GameObject.FindGameObjectsWithTag("point");
        NextDestination();
       GameObject obj = Instantiate(enemies[SelectedBFM.instance.index],this.transform,false) as GameObject;
        obj.GetComponent<NavMeshAgent>().enabled = false;
        obj.GetComponent<EnemyMoving>().enabled = false;
        obj.transform.GetChild(0).gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 10.0f)
        {
            NextDestination();
            timer = 0;

        }
    }

    void NextDestination()
    {
        int index = Random.Range(0, points.Length);
        destination = points[index].transform.position;
        agent.SetDestination(destination);
    }
}

