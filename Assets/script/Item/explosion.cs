using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {


    GameObject obj_pool;
    private ObjectPool pool;

    GameObject GameSetting;
    private GameSetting game_setting;
	// Use this for initialization
	void Start () {
        GameSetting = GameObject.Find ("GameSetting");
        game_setting = GameSetting.GetComponent<GameSetting> ();

        obj_pool = GameObject.Find ("ObjectPool");
        pool = obj_pool.GetComponent<ObjectPool> (); // 物件池
	}

	// Update is called once per frame
	void Update () {

	}

    void AnimationEnd() {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        pool.Recovery(PoolName(), gameObject);
    }

    public string PoolName () {
        if (gameObject.transform.name.IndexOf ("Clone") == -1)
            return gameObject.transform.name;
        return gameObject.transform.name.Substring (0, gameObject.transform.name.IndexOf ("Clone") - 1);
    }
}
