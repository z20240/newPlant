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

    private int totalHeart = 0;

    private Stack<GameObject> heart_stack = new Stack<GameObject>();
    private Stack<GameObject> energy_stack = new Stack<GameObject>();

    private Vector3 heart_pos = new Vector3(-870, -465, 0);
    private Vector3 energy_pos = new Vector3(-870, -435, 0);
    private int score = 0;

    public Stack<GameObject> Heart_stack {
        get { return heart_stack; }
        set { heart_stack = value; }
    }

    public Stack<GameObject> Energy_stack {
        get { return energy_stack; }
        set { energy_stack = value; }
    }

    void Awake() {
        GameSetting = GameObject.Find ("GameSetting");
        game_setting = GameSetting.GetComponent<GameSetting> ();

        obj_pool = GameObject.Find("ObjectPool");
        pool = obj_pool.GetComponent<ObjectPool>(); // 物件池
    }
	// Use this for initialization
	void Start () {
        totalHeart += GameObject.Find("plant_1").GetComponent<Plant>().Hp;
        if (PlayerPrefs.GetInt("player_num") != 1) {
            totalHeart += GameObject.Find("plant_2").GetComponent<Plant>().Hp;
        }

        for (int i = 0 ; i < totalHeart ; i++) {
            addHeart();
        }
	}

	// Update is called once per frame
	void Update () {

	}

    public int addScore (int value) {
        score += value;
        Score.text = score.ToString();
        return score;
    }

    public void addHeart () {
        GameObject heart = Instantiate( Heart ) as GameObject;
        heart.transform.SetParent(GameObject.Find("HP").transform);
        if (heart_stack.ToArray().Length == 0) {
            heart.transform.localPosition = heart_pos;
        } else {
            heart.transform.localPosition = heart_stack.Peek().transform.localPosition + new Vector3(60, 0, 0);
        }
        heart_stack.Push(heart);
    }

    public void delHeart() {
        if (heart_stack.ToArray().Length > 0)
            Destroy(heart_stack.Pop());
    }

    public void addEnergy () {
        GameObject energy = Instantiate( Energy ) as GameObject;
        energy.transform.SetParent(GameObject.Find("SP").transform);
        if (energy_stack.ToArray().Length == 0) {
            energy.transform.localPosition = heart_pos;
        } else {
            energy.transform.localPosition = energy_stack.Peek().transform.localPosition + new Vector3(60, 0, 0);
        }
        energy_stack.Push(energy);
    }

    public void delEnergy() {
        if (energy_stack.ToArray().Length > 0)
            Destroy(energy_stack.Pop());
    }
}
