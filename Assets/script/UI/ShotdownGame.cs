﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShotdownGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Button>().onClick.AddListener(() => {
			GameObject gameSetting = GameObject.Find("GameSetting");
			if (gameSetting) gameSetting.GetComponent<GameSetting>().ShotDownGame();
        });
	}

	// Update is called once per frame
	void Update () {
		if ( Input.GetButtonDown ("Exit") ) { // 離開遊戲
			GameObject gameSetting = GameObject.Find("GameSetting");
			if (gameSetting) gameSetting.GetComponent<GameSetting>().ShotDownGame();
        }
	}
}
