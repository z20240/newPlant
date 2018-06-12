using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

    private float _timer = 0;

    private float _terminate_sec = 5f;
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
