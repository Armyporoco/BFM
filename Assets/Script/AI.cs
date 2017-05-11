using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
   public  GameObject Ring;
    public　GameObject Player;
    public Vector3 direction,touchStartPos,touchEndPos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Ray ray;
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (Input.GetMouseButtonDown(0))
            {
                direction = hit.point;
                touchStartPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            }
            if (Input.GetMouseButtonUp(0))
            {
                touchEndPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            }

            if (Swaip() == true)
            {
                if (Player.GetComponent<Items>().yonjun == true)
                {

                }
            }
            else
            {
                Ring.transform.position = direction;
                transform.position = direction;
            }

        }
    }

   bool Swaip() {
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;

        if(Mathf.Abs(directionY) > 0.5f && Mathf.Abs(directionX) > 0.5f)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}

