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


        }
    }

}

