using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Items : MonoBehaviour {

    public bool finish, yonjun, conan;
    public Image Yonjun, Conan;
    public GameObject Arrow;

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

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (Input.GetMouseButtonDown(0)){
                if (hit.collider.gameObject.name == "BFM")
                {
                    finish = true;
                    SceneManager.LoadScene("Finish");
                }
                if(hit.collider.gameObject.name == "Yonjun")
                {
                    AudioClip clip = hit.collider.gameObject.GetComponent<AudioSource>().clip;
                    gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
                    yonjun = true;
                    Yonjun.enabled = true;
                    Destroy(hit.collider.gameObject);
                }
                if(hit.collider.gameObject.name == "Conan")
                {
                    AudioClip clip = hit.collider.gameObject.GetComponent<AudioSource>().clip;
                    gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
                    Arrow.SetActive(true);
                    conan = true;
                    Conan.enabled = true;
                    Destroy(hit.collider.gameObject);
                }
               
            }
        }


        }
}
