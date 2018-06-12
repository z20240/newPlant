using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Continue : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Button>().onClick.AddListener(() => {
			GameObject gameSetting = GameObject.Find("GameSetting");
			if (gameSetting) gameSetting.GetComponent<GameSetting>().Continue();
        });
	}

	// Update is called once per frame
	void Update () {
		if ( Input.GetButtonDown("Continue") ) { // 繼續
            GameObject gameSetting = GameObject.Find("GameSetting");
			if (gameSetting) gameSetting.GetComponent<GameSetting>().Continue();
        } 
	}
}
