using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour {

    private AsyncOperation async;
    public Image image;
    public Text BFMName, Tap;
    public Sprite[] sprite = new Sprite[5];
    public static SceneLoading instance = null; 
    public bool Selected = false;
    public int index;

    private void Awake()
    {

        for(int i = 0; i < sprite.Length; i++)
        {
            sprite[i] = Resources.Load<Sprite>(sprite[i].name);
        }
    }

    IEnumerator Start()
    {

        // 非同期でロード開始
        async = SceneManager.LoadSceneAsync("Main");
        // デフォルトはtrue。ロード完了したら勝手にシーンきりかえ発生しないよう設定。
        async.allowSceneActivation = false;

        // 非同期読み込み中の処理
        while (!async.isDone)
        {
            Debug.Log(async.progress * 100 + "%");

            yield return new WaitForSeconds(0);
        }
        yield return async;


    }

    // Use this for initialization
    /*void Start () {

    }*/
	
	// Update is called once per frame
	void Update () {

        if (Selected == false)
        {
            index = Random.Range(0, sprite.Length);
            image.sprite = sprite[index];
        }

        if (Input.GetMouseButtonDown(0) && Selected == false)
        {
            Selected = true;
            image.sprite = sprite[index];
            BFMName.text = image.sprite.name;
            Tap.text = "Tap to Start";
        }

        else if (Input.GetMouseButtonDown(0) && Selected == true)
        {
            // タッチしたら遷移する（検証用）
            async.allowSceneActivation = true;
        }

    }
}
