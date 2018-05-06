using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    GameObject obj_pool;
    private ObjectPool pool;

    Plant player;

    void Awake() {
        obj_pool = GameObject.Find("ObjectPool");
        pool = obj_pool.GetComponent<ObjectPool>(); // 物件池
    }

	// Use this for initialization
	void Start () {
        player = gameObject.transform.parent.gameObject.GetComponent<Plant>();
	}

	// Update is called once per frame
	void Update () {
        if (player.ShieldOn)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
	}
}
