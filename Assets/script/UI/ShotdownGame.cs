using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShotdownGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Button>().onClick.AddListener(() => {
            SceneManager.LoadScene("FinalScene");
        });
	}

	// Update is called once per frame
	void Update () {
		if ( Input.GetButtonDown ("Fire3") ) { // 離開遊戲
            SceneManager.LoadScene("FinalScene");
        }
	}
}
