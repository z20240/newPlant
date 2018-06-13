using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Continue : MonoBehaviour {

	// Use this for initialization


	void Start () {
        gameObject.GetComponent<Button>().onClick.AddListener(() => {
            Debug.Log(PlayerPrefs.GetInt("player_num"));

            if (SceneManager.GetActiveScene().name != "game") {
                PlayerPrefs.SetInt("player_num", PlayerPrefs.GetInt("players"));
                SceneManager.LoadScene("game");
            } else {
                GameObject gameSetting = GameObject.Find("GameSetting");
                if (gameSetting) gameSetting.GetComponent<GameSetting>().Continue();
            }
        });
	}

	// Update is called once per frame
	void Update () {
        if ( Input.GetButtonDown("Continue") ) { // 繼續
            if (SceneManager.GetActiveScene().name != "game") {
                PlayerPrefs.SetInt("player_num", PlayerPrefs.GetInt("players"));
                SceneManager.LoadScene("game");
            } else {
                GameObject gameSetting = GameObject.Find("GameSetting");
                if (gameSetting) gameSetting.GetComponent<GameSetting>().Continue();
            }
        }
	}
}
