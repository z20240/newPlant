using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    /**
     * setting
     */

     private float force = 6f;
     private int degree = 90;


	// Use this for initialization
    private Rigidbody2D rigidbody;

    public int Degree {
        get { return degree; }
        set { degree = value; }
    }

    void Start () {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

	}

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// FixedUpdate執行的間隔時間是相同的。
    /// 因此任何會影響到剛體(rigidbody)的行為都應該被放到這裡面來執行而不適合在update中。
    /// 常見的例子就是對一個物體施加一個力時，就應該將程式碼寫在FixedUpdate中。
    /// </summary>
    void FixedUpdate() {
            Vector3 dir = Quaternion.AngleAxis(degree, Vector3.forward) * Vector3.right;
            rigidbody.AddForce(dir*force);
    }
}
