using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour {

	// Use this for initialization
    public int g_Stage = 1;
    string[] player_name = {"plant_1", "plant_2"};
    private float[] boss_time = {60f, 60f, 60f};

    private List<Item> item_list = new List<Item>();

    private bool isBossTime = false;
    private float now_boss_time = 0.0f;
    private float _timer = 0;
    private bool[] playerAlive = {true, true};

    public int G_Stage {
        get { return g_Stage; }
        set { g_Stage = value; }
    }

    public string[] Player_name {
        get { return player_name; }
        set { player_name = value; }
    }

    public bool IsBossTime {
        get { return isBossTime; }
        set { isBossTime = value; }
    }

    public float[] Boss_time {
        get { return boss_time; }
        set { boss_time = value; }
    }

    public float Now_boss_time {
        get { return now_boss_time; }
        set { now_boss_time = value; }
    }

    public float Timer {
        get { return _timer; }
    }

    public List<Item> Item_list {
        get { return item_list; }
        set { item_list = value; }
    }

    void Start () {
        now_boss_time = boss_time[0];
        item_list.Add(new Item("item_enhancement", 10f));
        item_list.Add(new Item("item_extra_skill", 40f));
        item_list.Add(new Item("item_heal_pack", 50f));
        item_list.Add(new Item("item_rewards", 30f)); // 這其實是防護罩


        if (PlayerPrefs.GetInt("player_num") == 1)
            GameObject.Find("plant_2").SetActive(false);
	}

	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime; //時間增加
	}
}
