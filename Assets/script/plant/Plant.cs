using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plant : MonoBehaviour {
    // == setting
    private int base_hp = 5;
    private int hp;
    private float shield_time = 5f; // 防護罩時間


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


    void Awake() {
        GameSetting = GameObject.Find ("GameSetting");
        game_setting = GameSetting.GetComponent<GameSetting> ();

        obj_pool = GameObject.Find("ObjectPool");
        pool = obj_pool.GetComponent<ObjectPool>(); // 物件池

        hp = base_hp;
    }

    // Use this for initialization
    void Start () {
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
        GameObject go;
        if (collider.transform.name.IndexOf("Clone") == -1)
            collider_name = collider.transform.name;
         else collider_name = collider.transform.name.Substring(0, collider.transform.name.IndexOf("Clone")-1);

        if (collider.tag == "Item") {
            // Debug.Log("[collider_name] :" + collider_name);
            switch(collider_name) {
                case "item_enhancement":
                    if (plant_fire.bullet_type < 2) {
                        plant_fire.bullet_type += 1;
                        go = GameObject.Find("換攻擊");
                        go.GetComponent<AudioSource>().PlayOneShot(go.GetComponent<AudioSource>().clip);
                    }
                break;
                case "item_extra_skill":
                    if (extra_skill_count <= 4) {
                        extra_skill_count += 1;
                        GameObject.Find("UICanvas").GetComponent<UICtrl>().addEnergy(gameObject.name);
                        go = GameObject.Find("炸彈包");
                        go.GetComponent<AudioSource>().PlayOneShot(go.GetComponent<AudioSource>().clip);
                    }

                break;
                case "item_heal_pack":
                    if (hp < 5) {
                        hp += 1;
                        GameObject.Find("UICanvas").GetComponent<UICtrl>().addHeart(gameObject.name);
                        go = GameObject.Find("救護包");
                        go.GetComponent<AudioSource>().PlayOneShot(go.GetComponent<AudioSource>().clip);
                    }
                break;
                case "item_rewards":
                    shieldOn = true;
                    _next = System.Math.Max(_next, _timer) + shield_time;
                    gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    go = GameObject.Find("勳章");
                    go.GetComponent<AudioSource>().PlayOneShot(go.GetComponent<AudioSource>().clip);
                break;
            }
        } else if (collider.tag == "MobBullet" || collider.tag == "Mob" || collider.tag == "Boss") {

            if ( shieldOn ) return;

            hp -= 1;
            GameObject.Find("UICanvas").GetComponent<UICtrl>().delHeart(gameObject.name);

            if (hp <= 0) {
                pool.ReUse("explosion", gameObject.transform.position, gameObject.transform.rotation);
                gameObject.SetActive(false);

                PlayerPrefs.SetInt("player_num", PlayerPrefs.GetInt("player_num") -1);

                if (PlayerPrefs.GetInt("player_num") <= 0) {
                    // 失敗
                    SceneManager.LoadScene("EndFailure");
                }
            }
        }
    }

    public string PlantName() {
        if (gameObject.transform.name.IndexOf("Clone") == -1)
            return gameObject.transform.name;
        return gameObject.transform.name.Substring(0, gameObject.transform.name.IndexOf("Clone")-1);
    }
}
