using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour {

    GameObject obj_pool;
    private ObjectPool pool;

    void Awake() {
        obj_pool = GameObject.Find("ObjectPool");
        pool = obj_pool.GetComponent<ObjectPool>(); // 物件池
    }

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 2);
	}

	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter2D(Collider2D collider) {
        string pool_name = ItemName();
        if (collider.tag == "Player" || collider.tag == "wall") {
            pool.Recovery(pool_name, gameObject);
        }
    }

    string ItemName() {
        if (gameObject.transform.name.IndexOf("Clone") == -1)
            return gameObject.transform.name;
        return gameObject.transform.name.Substring(0, gameObject.transform.name.IndexOf("Clone")-1);
    }
}
