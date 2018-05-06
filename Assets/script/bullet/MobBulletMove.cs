using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBulletMove : MonoBehaviour {
    // == setting
    private float force = 0.5f;

    private Vector3 dir;

    public Vector3 Dir {
        get { return dir; }
        set { dir = value; }
    }

    public float Force {
        get { return force; }
        set { force = value; }
    }


    // Use this for initialization
    void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

    void FixedUpdate() {
        gameObject.GetComponent<Rigidbody2D>().AddForce(dir*force);
    }
}
