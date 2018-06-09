using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UICtrl : MonoBehaviour {
    public GameObject Heart;
    public GameObject Energy;
    public Text Score;

    GameObject obj_pool;
    private ObjectPool pool;

    GameObject GameSetting;
    private GameSetting game_setting;

    private int totalHeart_p1 = 0;
    private int totalHeart_p2 = 0;

    private Stack<GameObject> heart_stack_p1 = new Stack<GameObject>();
    private Stack<GameObject> heart_stack_p2 = new Stack<GameObject>();
    private Stack<GameObject> energy_stack_p1 = new Stack<GameObject>();
    private Stack<GameObject> energy_stack_p2 = new Stack<GameObject>();

    private Vector3 heart_pos_p1 = new Vector3(-810, -465, 0);
    private Vector3 heart_pos_p2 = new Vector3(-330, -465, 0);
    private Vector3 energy_pos_p1 = new Vector3(-810, -435, 0);
    private Vector3 energy_pos_p2 = new Vector3(-330, -435, 0);
    private int score = 0;
    private float show_time = 1.5f;
    private float _time;

    // public Stack<GameObject> Heart_stack {
    //     get { return heart_stack; }
    //     set { heart_stack = value; }
    // }

    // public Stack<GameObject> Energy_stack {
    //     get { return energy_stack; }
    //     set { energy_stack = value; }
    // }

    void Awake() {
        GameSetting = GameObject.Find ("GameSetting");
        game_setting = GameSetting.GetComponent<GameSetting> ();

        obj_pool = GameObject.Find("ObjectPool");
        pool = obj_pool.GetComponent<ObjectPool>(); // 物件池

        GameObject two_player_text = GameObject.Find("2P");
        if (PlayerPrefs.GetInt("player_num") < 2) {
            two_player_text.SetActive(false);
        }
    }
	// Use this for initialization
	void Start () {
        totalHeart_p1 += GameObject.Find("plant_1").GetComponent<Plant>().Hp;
        if (PlayerPrefs.GetInt("player_num") != 1) {
            totalHeart_p2 += GameObject.Find("plant_2").GetComponent<Plant>().Hp;
        }

        for (int i = 0 ; i < totalHeart_p1 ; i++) {
            addHeart("plant_1");
        }
        for (int i = 0 ; i < totalHeart_p2 ; i++) {
            addHeart("plant_2");
        }

	}

	// Update is called once per frame
	void Update () {
        _time += Time.deltaTime;
	}

    public int addScore (int value) {
        score += value;
        Score.text = score.ToString();
        return score;
    }

    public void addHeart (string plant_name) {
        GameObject heart = Instantiate( Heart ) as GameObject;
        heart.transform.SetParent(GameObject.Find("HP").transform);

        if (plant_name == "plant_1") {
            if (heart_stack_p1.ToArray().Length == 0) {
                    heart.transform.localPosition = heart_pos_p1;
            } else {
                heart.transform.localPosition = heart_stack_p1.Peek().transform.localPosition + new Vector3(60, 0, 0);
            }
            heart_stack_p1.Push(heart);
        } else if (plant_name == "plant_2") {
            if (heart_stack_p2.ToArray().Length == 0) {
                    heart.transform.localPosition = heart_pos_p2;
            } else {
                heart.transform.localPosition = heart_stack_p2.Peek().transform.localPosition + new Vector3(60, 0, 0);
            }
            heart_stack_p2.Push(heart);
        }

    }

    public void delHeart(string plant_name) {
        if (plant_name == "plant_1") {
            if (heart_stack_p1.ToArray().Length > 0)
                Destroy(heart_stack_p1.Pop());
        } else if (plant_name == "plant_2") {
            if (heart_stack_p2.ToArray().Length > 0)
                Destroy(heart_stack_p2.Pop());
        }
    }

    public void addEnergy (string plant_name) {
        GameObject energy = Instantiate( Energy ) as GameObject;
        energy.transform.SetParent(GameObject.Find("SP").transform);

        if (plant_name == "plant_1") {
            if (energy_stack_p1.ToArray().Length == 0) {
                energy.transform.localPosition = heart_pos_p1;
            } else {
                energy.transform.localPosition = energy_stack_p1.Peek().transform.localPosition + new Vector3(60, 0, 0);
            }
            energy_stack_p1.Push(energy);
        } else if (plant_name == "plant_2") {
            if (energy_stack_p2.ToArray().Length == 0) {
                energy.transform.localPosition = heart_pos_p2;
            } else {
                energy.transform.localPosition = energy_stack_p2.Peek().transform.localPosition + new Vector3(60, 0, 0);
            }
            energy_stack_p2.Push(energy);
        }
    }

    public void delEnergy(string plant_name) {
        if (plant_name == "plant_1") {
            if (energy_stack_p1.ToArray().Length > 0)
                Destroy(energy_stack_p1.Pop());
        } else if (plant_name == "plant_2") {
            if (energy_stack_p2.ToArray().Length > 0)
                Destroy(energy_stack_p2.Pop());
        }
    }
}
