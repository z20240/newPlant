using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plant : MonoBehaviour {
    // == setting
    private int base_hp = 5;
    private int hp;
    private float shield_time = 3f;


    private bool shieldOn = false;
    private int extra_skill_count = 0;

    PlantFire plant_fire;
    private float _timer, _next;

    public bool ShieldOn {
        get { return shieldOn; }
        set { shieldOn = value; }
    }

    public int Extra_skill_count {
        get { return extra_skill_count; }
        set { extra_skill_count = value; }
    }

    public int Hp {
        get { return hp; }
        set { hp = value; }
    }

    GameObject obj_pool;
    private ObjectPool pool;
    GameObject GameSetting;
    private GameSetting game_setting;

    // Use this for initialization
    void Start () {
        GameSetting = GameObject.Find ("GameSetting");
        game_setting = GameSetting.GetComponent<GameSetting> ();

        obj_pool = GameObject.Find("ObjectPool");
        pool = obj_pool.GetComponent<ObjectPool>(); // 物件池

        hp = base_hp;

        plant_fire = gameObject.GetComponent<PlantFire>();

        _timer = _next = 0;
	}

	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime;

        if (_timer > _next && shieldOn)
            shieldOn = false;
	}

    void OnTriggerEnter2D(Collider2D collider) {
        string collider_name;
        if (collider.transform.name.IndexOf("Clone") == -1)
            collider_name = collider.transform.name;
         else collider_name = collider.transform.name.Substring(0, collider.transform.name.IndexOf("Clone")-1);

        if (collider.tag == "Item") {
            Debug.Log("[collider_name] :" + collider_name);
            switch(collider_name) {
                case "item_enhancement":
                    if (plant_fire.bullet_type < 2)
                        plant_fire.bullet_type += 1;
                    Debug.Log("[item_enhancement] bullet_type : " + plant_fire.bullet_type);
                break;
                case "item_extra_skill":
                    if (extra_skill_count <= 4) {
                        extra_skill_count += 1;
                        GameObject.Find("UICanvas").GetComponent<UICtrl>().addEnergy();
                    }

                break;
                case "item_heal_pack":
                    if (hp < 5) {
                        hp += 1;
                        GameObject.Find("UICanvas").GetComponent<UICtrl>().addHeart();
                    }
                break;
                case "item_rewards":
                    shieldOn = true;
                    _next = System.Math.Max(_next, _timer) + shield_time;
                    gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    Debug.Log("[item_rewards] _timer : " + _timer + ", _next : " + _next);
                break;
            }
        } else if (collider.tag == "MobBullet" || collider.tag == "Mob" || collider.tag == "Boss") {

            if ( shieldOn ) return;

            hp -= 1;
            GameObject.Find("UICanvas").GetComponent<UICtrl>().delHeart();

            if (hp <= 0) {
                pool.ReUse("explosion", gameObject.transform.position, gameObject.transform.rotation);
                gameObject.SetActive(false);

                PlayerPrefs.SetInt("player_num", PlayerPrefs.GetInt("player_num") -1);

                if (PlayerPrefs.GetInt("player_num") <= 0)
                    SceneManager.LoadScene("End");
            }
        }
    }

    public string PlantName() {
        if (gameObject.transform.name.IndexOf("Clone") == -1)
            return gameObject.transform.name;
        return gameObject.transform.name.Substring(0, gameObject.transform.name.IndexOf("Clone")-1);
    }
}
