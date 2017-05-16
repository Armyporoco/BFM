using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float timer;
    public bool timerstart;
    public GameObject[] enemies;
    public　GameObject Player;
    public Vector3 direction,touchStartPos,touchEndPos;
    public float ts_x, ts_y, te_x, te_y;

    // Use this for initialization
    void Start()
    { 
        enemies = GameObject.FindGameObjectsWithTag("enemy");

    }

    // Update is called once per frame
    void Update()
    {

        Ray ray;
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
                if (Vector2.Distance(touchStartPos,touchEndPos) >= 15.0f)
                {
                    Vector3 center = new Vector3((touchStartPos.x + touchEndPos.x) / 2, (touchStartPos.y + touchEndPos.y) / 2, Camera.main.transform.position.z);
                    Vector3 extends = new Vector3(System.Math.Abs(touchStartPos.x - touchEndPos.x)/2, System.Math.Abs(touchStartPos.y - touchEndPos.y)/2, Mathf.Infinity);
                    if (Physics.BoxCast(center, extends, Camera.main.transform.forward,out hit,Quaternion.identity,Mathf.Infinity))
                    {
                        Debug.Log("Ray");
                        if(hit.collider.tag == "enemy")
                        {
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    Debug.Log("swaip");

                }
                else
                { 
                    transform.position = direction;

                }
            }

            timer = 0.0f;
        }

    }

}

