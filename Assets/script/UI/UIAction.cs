using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIAction : MonoBehaviour {

    CanvasGroup cg;

    GameObject player1;
    GameObject player2;
    void Awake() {
        cg = gameObject.GetComponent<CanvasGroup>();
        player1 = GameObject.Find("1P");
        player2 = GameObject.Find("2P");
    }

    // Use this for initialization
	void Start () {
        Screen.SetResolution(1920, 1080, true);
	}

	// Update is called once per frame
	void Update () {
        // 離開遊戲
        if (Input.GetKey(KeyCode.Escape) || Input.GetButtonDown("Exit")) {
            Time.timeScale = 1f;
            SceneManager.LoadScene("FinalScene");
        }

        DOTween.To(() => {
                // Debug.Log("[pre] cg.alpha:" + cg.alpha);
                return cg.alpha;
            }, x => {
                cg.alpha = x;
                // Debug.Log("x:" + x + " cg.alpha:" + cg.alpha);
        }, 1, 2);

        if (SceneManager.GetActiveScene().name == "Start") {
            if ( Input.GetAxis("Horizontal_player1") < 0 ) {
                PlayerPrefs.SetInt("player_num", 1);
                PlayerPrefs.SetInt("players",  1);
                player1.transform.GetChild(1).gameObject.SetActive(true);
                player2.transform.GetChild(1).gameObject.SetActive(false);
            } else if ( Input.GetAxis("Horizontal_player1") > 0 ) {
                PlayerPrefs.SetInt("player_num", 2);
                PlayerPrefs.SetInt("players",  2);
                player1.transform.GetChild(1).gameObject.SetActive(false);
                player2.transform.GetChild(1).gameObject.SetActive(true);
            }
            if ( Input.GetAxis("Horizontal_player2") < 0 ) {
                PlayerPrefs.SetInt("player_num", 1);
                PlayerPrefs.SetInt("players",  1);
                player1.transform.GetChild(1).gameObject.SetActive(true);
                player2.transform.GetChild(1).gameObject.SetActive(false);
            } else if ( Input.GetAxis("Horizontal_player2") > 0 ) {
                PlayerPrefs.SetInt("player_num", 2);
                PlayerPrefs.SetInt("players",  2);
                player1.transform.GetChild(1).gameObject.SetActive(false);
                player2.transform.GetChild(1).gameObject.SetActive(true);
            }
        }

        // 搖桿 開始遊戲
        if ( (PlayerPrefs.GetInt("player_num") == 1 || PlayerPrefs.GetInt("player_num") == 2) && Input.GetButtonDown ("Continue") ) {
            // SceneManager.LoadScene("TransferScene");
            SceneManager.LoadScene("game");
        }
	}
}
