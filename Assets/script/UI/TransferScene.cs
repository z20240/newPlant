using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferScene : MonoBehaviour {

    private float _time;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		_time += Time.deltaTime;

        if (_time >= 1.5f)
            SceneManager.LoadScene("game");
	}
}
