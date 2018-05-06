using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBullet : MonoBehaviour {

    GameObject obj_pool;
    private ObjectPool pool;

    void Awake() {
        obj_pool = GameObject.Find("ObjectPool");
        pool = obj_pool.GetComponent<ObjectPool>(); // 物件池
    }

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D collider) {
        string pool_name = BulletPoolName();
        if (collider.tag == "wall" || collider.tag == "Player" || collider.tag == "shield") {
            pool.Recovery(pool_name, gameObject);
        }

    }

    string BulletPoolName() {
        if (gameObject.transform.name.IndexOf("Clone") == -1)
            return gameObject.transform.name;
        return gameObject.transform.name.Substring(0, gameObject.transform.name.IndexOf("Clone")-1);
    }
}
