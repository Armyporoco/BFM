using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AI : MonoBehaviour
{
    public float timer;
    public GameObject[] enemies;
    public　GameObject Player,Score;
    public Vector3 direction,touchStartPos,touchEndPos;
    public float ts_x, ts_y, te_x, te_y;
    public int HP;
    public Slider playerHP;

    // Use this for initialization
    void Start()
    {
        HP = 15;
        playerHP.maxValue = HP;
        playerHP.value = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP > 0)
        {
            if(Score.GetComponent<Score>().denemy == 20)
            {
                playerHP.maxValue = 30;
                playerHP.value = 30;
            }

            playerHP.value = HP;

            Ray ray, attack;
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Input.GetMouseButton(0))
            {
                timer += Time.deltaTime;
                if (Input.GetMouseButtonDown(0))
                {
                    touchStartPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                    if ((Physics.Raycast(ray, out hit, Mathf.Infinity)) && (hit.collider.gameObject.tag == "Field"))
                    {
                        direction = hit.point;
                    }
                }
            }
            else
            {
                if (Input.GetMouseButtonUp(0))
                {
                    touchEndPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                }

                if (timer >= 0.2f)
                {
                    if (Vector2.Distance(touchStartPos, touchEndPos) >= 15.0f)
                    {
                        if (Player.GetComponent<Items>().yonjun == true)
                        {
                            SpecialAttack();
                        }
                        else
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                attack = Camera.main.ScreenPointToRay(Vector3.Lerp(touchStartPos, touchEndPos, i / 10.0f));
                                if ((Physics.Raycast(attack, out hit, Mathf.Infinity)))
                                {
                                    if (hit.collider.tag == "enemy")
                                    {
                                        hit.collider.GetComponent<EnemyMoving>().Die();
                                    }

                                }

                            }

                        }
                    }
                    else
                    {
                        transform.position = direction;

                    }
                }

                timer = 0.0f;
            }

        }

        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void SpecialAttack()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");

        foreach (GameObject enemy in enemies)
        {
            if (Vector3.Distance(Player.transform.position, gameObject.transform.position) <= 5.0f)
            {
                enemy.gameObject.GetComponent<EnemyMoving>().Die();
            }
        }
    }

}

