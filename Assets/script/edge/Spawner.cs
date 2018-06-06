using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    // == setting
    // Boss 1 登場時間
    private float clear_time = 5f;
    // 上
    private float spawnTime_top = 3f; // 間隔 3 秒
    private float top_mob_per_count = 5f; // 一 波 5 隻
    // 左
    private float spawnTime_left = 5f; //
    private float left_mob_per_count = 3f; //
    // 右
    private float spawnTime_right = 5f;
    private float right_mob_per_count = 2f; //


    GameObject obj_pool;
    private ObjectPool pool;

    GameObject GameSetting;
    private GameSetting game_setting;
    // bool bossTime = false;
    bool[] bossDefeat = {false, false, false};

    private float _timer,
     _next_spawntime_top,
     _next_spawntime_left,
     _next_spawntime_right;

     private int _mob_top_count, _mob_left_count, _mob_right_count;
    private string[] mob_name = {
        // 上
        "mob_cocaine",
        "mob_morphine",
        "mob_marijuana",
        "mob_mdma",
        "mob_poison_coffee",

        // 左
        "mob_poison_candy",
        "mob_poison_bear",

        // 右
        "mob_poison_suger_bar",
        "mob_poison_soft_suger",
    };

    private ArrayList go_boss_audio = new ArrayList();

    private string[] boss_list = {"boss1_ketamine", "boss2_amphetamines", "boss3_heroin",};

    void Awake() {
        GameSetting = GameObject.Find("GameSetting");
        game_setting = GameSetting.GetComponent<GameSetting>();

        obj_pool = GameObject.Find("ObjectPool");
        pool = obj_pool.GetComponent<ObjectPool>(); // 物件池
        _next_spawntime_top = spawnTime_top;
        _next_spawntime_left = spawnTime_left;
        _next_spawntime_right = spawnTime_right;
    }

	// Use this for initialization
	void Start () {
        go_boss_audio.Add(GameObject.Find("魔王出現1"));
        go_boss_audio.Add(GameObject.Find("魔王出現2"));
        go_boss_audio.Add(GameObject.Find("魔王出現3"));
	}

	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime; //時間增加

        if (_timer >= game_setting.Now_boss_time - clear_time && !game_setting.IsBossTime && !bossDefeat[(game_setting.G_Stage -1) % game_setting.MaxStage]) {

            // Debug.Log("gameObject name : " + gameObject.name);
            if (gameObject.name != "spawner_top")
                return;

            // 召喚 boss
            if (game_setting.G_Stage > 3)
                return;
            pool.ReUse( boss_list[game_setting.G_Stage - 1], transform.position + new Vector3(0, +2.5f, 0), transform.rotation);
            GameObject go = (GameObject)go_boss_audio[game_setting.G_Stage - 1];
            go.GetComponent<AudioSource>().PlayOneShot(go.GetComponent<AudioSource>().clip);
            game_setting.IsBossTime = true;
        }

        if (!game_setting.IsBossTime) {
            switch (gameObject.name) {
                case "spawner_top":
                    if ( _timer <= _next_spawntime_top && (_mob_top_count % top_mob_per_count == 0))
                        return;
                    _mob_top_count++;
                    if (_mob_top_count % top_mob_per_count == 0)
                        _next_spawntime_top = _timer + spawnTime_top;

                    pool.ReUse( mob_name[Random.Range(0, 5)], transform.position + new Vector3(Random.Range(-8.8f, 8.8f), -0.8f, 0), transform.rotation);
                break;
                case "spawner_left":
                    if ( _timer <= _next_spawntime_left && (_mob_left_count % left_mob_per_count == 0))
                        return;
                    _mob_left_count++;
                    if (_mob_left_count % left_mob_per_count == 0)
                        _next_spawntime_left = _timer + spawnTime_left;

                    pool.ReUse( mob_name[Random.Range(5, 7)], transform.position + new Vector3(1f, Random.Range(-4.0f, 4.0f), 0), transform.rotation);
                break;
                case "spawner_right":
                    if ( _timer <= _next_spawntime_right && (_mob_right_count % right_mob_per_count == 0))
                        return;
                    _mob_right_count++;
                    if (_mob_right_count % right_mob_per_count == 0)
                        _next_spawntime_right = _timer + spawnTime_right;

                    pool.ReUse( mob_name[Random.Range(7, 9)], transform.position + new Vector3(-1f, Random.Range(-4.0f, 4.0f), 0), transform.rotation);
                break;
                case "spawner_down": break;
            }
        }
	}
}
