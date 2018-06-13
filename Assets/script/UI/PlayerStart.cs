using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStart : MonoBehaviour {

    public UnityEvent OnHover = new UnityEvent();
    bool is_hover = false;
    float _time, exec_time = 0.01f;
    ObjectPool obj_pool;

	// Use this for initialization
	void Start () {
        obj_pool = GameObject.Find("PlayerChooseCtrl").GetComponent<ObjectPool>();

        GetComponent<Button>().onClick.AddListener(() => {
            PlayerPrefs.SetInt("player_num",  gameObject.name == "1P" ? 1 : 2);
            PlayerPrefs.SetInt("players",  gameObject.name == "1P" ? 1 : 2);
            SceneManager.LoadScene("TransferScene");
        });


        OnHover.AddListener(() => {
            // 載入音效
            gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
        });
	}

	// Update is called once per frame
	void Update () {
        // 離開遊戲
        if (Input.GetKey(KeyCode.Escape) || Input.GetButtonDown ("Exit")) {
            Time.timeScale = 1f;
            SceneManager.LoadScene("FinalScene");
        }

        if (is_hover) {
            _time += Time.deltaTime;

            if (_time >= exec_time) {
                is_hover = false;
                OnHover.Invoke();
            }
        }

	}

    // 當滑鼠進入時
    public void OnMouseEnter() {
        is_hover = true;
        GameObject child = gameObject.transform.GetChild(1).gameObject;
        child.SetActive(true);
    }

    void OnMouseOver() {
    }

    /// <summary>
    /// Called when the mouse is not any longer over the GUIElement or Collider.
    /// </summary>
    public void OnMouseExit() {
        is_hover = false;
        GameObject child = gameObject.transform.GetChild(1).gameObject;
        child.SetActive(false);
    }

    public void Do_something() {
    }
}
