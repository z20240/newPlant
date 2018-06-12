using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Button>().onClick.AddListener(() => {
            Time.timeScale = 1f;
            SceneManager.LoadScene("Start");
        });
	}

	// Update is called once per frame
	void Update () {
		if ( Input.GetButtonDown ("Start") ) { // 重新開始
            Time.timeScale = 1f;
            SceneManager.LoadScene("Start");
        }
	}
}
