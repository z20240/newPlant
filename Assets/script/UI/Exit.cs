using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

    private float _timer;

    private int _terminate_sec = 3;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime;

        if (_timer >= _terminate_sec)
            Application.Quit();
	}
}
