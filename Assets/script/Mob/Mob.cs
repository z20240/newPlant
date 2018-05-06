using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour {
    // == setting
    private float shooting_time = 3f;


    private float _timer, _next_time;
    GameObject obj_pool;
    private ObjectPool pool;
    private GameObject player;
    GameObject GameSetting;
    private GameSetting game_setting;

    private List<string> need_scale_up = new List<string>();

    void Awake() {
        GameSetting = GameObject.Find ("GameSetting");
        game_setting = GameSetting.GetComponent<GameSetting> ();

        obj_pool = GameObject.Find("ObjectPool");
        pool = obj_pool.GetComponent<ObjectPool>(); // 物件池
        need_scale_up.Add("mob_poison_coffee_attack");
        need_scale_up.Add("mob_poison_bear_attack");
        need_scale_up.Add("mob_poison_suger_bar_attack");
        need_scale_up.Add("mob_poison_soft_suger_attack");
    }

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime; //時間增加
        if ( _timer <= _next_time)
            return;
        _next_time = _timer + shooting_time;

        string attack_name;
        if (gameObject.name.Contains("mdma")) {
            attack_name = GetName(gameObject.name) + "_attack_" + Random.Range(1, 5);
        } else {
            attack_name = GetName(gameObject.name) + "_attack";
        }
        Vector3 dir;

        player = GameObject.Find(game_setting.Player_name[Random.Range(0, 2)]);

        Quaternion quate = Quaternion.identity;
        if ( player == null ) {
            dir = Vector3.down;
            quate.eulerAngles = new Vector3(0, 0, 0); // 表示設置x軸方向旋轉了 tiltAngle 度
        } else {
            dir =  player.transform.position - gameObject.transform.position;
            float tiltAngle = Vector3.Angle(Vector3.down, dir);
            quate.eulerAngles = new Vector3(0, 0, tiltAngle); // 表示設置x軸方向旋轉了 tiltAngle 度
        }

        GameObject bullet = pool.ReUse(attack_name, gameObject.transform.position, quate);

        if (need_scale_up.Contains(GetName(bullet.name)))
            bullet.transform.localScale *= 2;

        bullet.GetComponent<MobBulletMove>().Dir = dir;


	}

    public void OnTriggerEnter2D(Collider2D collider) {
        string pool_name = GetName(gameObject.name);
        if (collider.tag == "Player" || collider.tag == "PlayerBullet" || collider.tag == "wall") {
            // Debug.Log("collider bullet:" + collider.tag + " " + pool_name);
            if (collider.tag != "wall") {
                pool.ReUse("explosion", gameObject.transform.position, gameObject.transform.rotation);
                GameObject.Find("UICanvas").GetComponent<UICtrl>().addScore(10);
            }

            string item = RandomItem();

            if (item != "")
                pool.ReUse(item, gameObject.transform.position + new Vector3(UnityEngine.Random.Range(0.2f, -0.2f), 0, 0), gameObject.transform.rotation);

            pool.Recovery(pool_name, gameObject);
        }
    }

    public string GetName(string name) {
        if (name.IndexOf("Clone") == -1)
            return name;
        return name.Substring(0, name.IndexOf("Clone")-1);
    }

    string RandomItem() {
        float rand = UnityEngine.Random.Range(0, 100);

        foreach( Item item in game_setting.Item_list ) {
            if ( rand <= item.Rate ) {
                return item.Name;
            }
        }
        return "";
    }
}
