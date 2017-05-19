using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedBFM : MonoBehaviour {

    public static SelectedBFM instance = null;
    public int index;
   // public GameObject SceneLoading;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

	// Use this for initialization
	void Start () {
		
	}



    public void SetIndex(int index)
    {
        this.index = index;
    }
	
	// Update is called once per frame
	void Update () {
       // if (SceneLoading != null && SceneLoading.gameObject.GetComponent<SceneLoading>().Selected == true) {
           // index = SceneLoading.gameObject.GetComponent<SceneLoading>().index;
                }
	
}
