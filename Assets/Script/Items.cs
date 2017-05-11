using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

    public bool finish, yonjun, conan;

	// Use this for initialization
	void Start () {
        finish = false;
        yonjun = false;
        conan = false;
	}
	
	// Update is called once per frame
	void Update () {

        Ray ray;
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (Input.GetMouseButtonDown(0)){
                if (hit.collider.gameObject.name == "BFM")
                {
                    finish = true;
                }
            }
        }


        }
}
