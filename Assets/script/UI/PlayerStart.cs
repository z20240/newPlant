using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(() => {
            Debug.Log("click");
            PlayerPrefs.SetInt("player_num",  gameObject.name == "1P" ? 1 : 2);
            SceneManager.LoadScene("game");
        });
	}

	// Update is called once per frame
	void Update () {

	}
}
