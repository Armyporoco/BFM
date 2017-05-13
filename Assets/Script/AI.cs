using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public GameObject[] enemies;
    public　GameObject Player;
    public Vector3 direction,touchStartPos,touchEndPos;
    private bool isDoubleTapStart; //タップ認識中のフラグ
    private float doubleTapTime; //タップ開始からの累積時間

    // Use this for initialization
    void Start()
    { 
        enemies = GameObject.FindGameObjectsWithTag("enemy");

    }

    // Update is called once per frame
    void Update()
    {

        if (isDoubleTapStart)
        {
            doubleTapTime += Time.deltaTime;
            if (doubleTapTime < 0.2f)
            {
                if (Input.GetMouseButtonDown(0))
                {

                    isDoubleTapStart = false;

                    if (Player.GetComponent<Items>().yonjun == true)
                    {
                        foreach (GameObject enemy in enemies)
                        {
                            // 消す！
                            Destroy(enemy);
                        }
                    }

                    doubleTapTime = 0.0f;
                }
            }
            else
            {

                if (Player.GetComponent<Items>().yonjun == true)
                {
                    Debug.Log("ok");
                    foreach (GameObject enemy in enemies)
                    {
                        // 消す！
                        Destroy(enemy);
                    }
                }

                // reset
                isDoubleTapStart = false;
                doubleTapTime = 0.0f;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {

                isDoubleTapStart = true;
            }
        }

        Ray ray;
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (Input.GetMouseButtonDown(0) && hit.collider.tag == "Field")
            {
                direction = hit.point;
                transform.position = direction;

                touchStartPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            }
            if (Input.GetMouseButtonUp(0))
            {
                touchEndPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            }

            /*if (Swaip() == true)
            {
                if (Player.GetComponent<Items>().yonjun == true)
                {
                    foreach (GameObject enemy in enemies)
                    {
                        // 消す！
                        Destroy(enemy);
                    }
                }
            }
            else
            {
                transform.position = direction;
                Ring.transform.position = direction;
               
            }*/

        }
    }

   bool Swaip() {
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;

        if(Mathf.Abs(directionY) < 0.5f && Mathf.Abs(directionX) < 0.5f)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


}

