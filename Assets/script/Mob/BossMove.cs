using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour {
    // == setting
    private float boss_speed = 0.1f;

    private float[] boss_pos = {2.8f, 2.0f, 2.0f};
    private float[] boss_hor_float = {6.5f, 5.6f, 3.0f};

    GameObject obj_pool;
    private ObjectPool pool;

    GameObject GameSetting;
    private GameSetting game_setting;
    private float _timer;

    Boss boss;

    void Awake() {
        GameSetting = GameObject.Find("GameSetting");
        game_setting = GameSetting.GetComponent<GameSetting>();

        obj_pool = GameObject.Find("ObjectPool");
        pool = obj_pool.GetComponent<ObjectPool>(); // 物件池

        boss = gameObject.GetComponent<Boss>();
    }

    // Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

        if (gameObject.transform.position.y > boss_pos[game_setting.G_Stage -1])
            gameObject.transform.position += (Vector3.down * boss_speed);

        if (gameObject.transform.position.y <= boss_pos[game_setting.G_Stage -1]) {
            boss.Can_start_attack = true;

            // 從這邊開始計算時間
            _timer += Time.deltaTime;
            float hudu = ((float)(_timer * 36 / 360) * Mathf.PI); // 每秒移動 36 度
            float xx = 0 + ( boss_hor_float[game_setting.G_Stage -1] ) * Mathf.Sin (hudu); // r = 2.5
            gameObject.transform.position = new Vector3(xx, gameObject.transform.position.y, 0);
        }

        // Debug.Log("Boss pos :" + gameObject.transform.position);

	}
}
