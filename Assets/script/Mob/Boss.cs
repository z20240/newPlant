using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour {
    // == setting
    private float[] shooting_time = { 0.2f, 0.5f, 0.3f };
    private float[] shooting_force = { 1f, 1f, 1f };
    private int[] hp_setting = { 80, 160, 320 };

    private int bulletAmount = 12;

    GameObject obj_pool;
    private ObjectPool pool;

    GameObject GameSetting;
    private GameSetting game_setting;

    GameObject bulletClone;
    private GameObject player;
    private float _timer, _next_time;
    private float angle = 0;

    private bool can_start_attack = false;
    Vector3 dir;
    Quaternion quate = Quaternion.identity;

    Bounds bounds;
    Vector3 center;
    float r = 0.2f;
    float hudu, xx, yy;
    int changeAngle;
    private int hp = 0;

    public bool Can_start_attack {
        get { return can_start_attack; }
        set { can_start_attack = value; }
    }

    public int Hp {
        get { return hp; }
        set { hp = value; }
    }

    void Awake () {
        GameSetting = GameObject.Find ("GameSetting");
        game_setting = GameSetting.GetComponent<GameSetting> ();

        obj_pool = GameObject.Find ("ObjectPool");
        pool = obj_pool.GetComponent<ObjectPool> (); // 物件池

        hp = hp_setting[game_setting.G_Stage -1];
    }

    // Use this for initialization
    void Start () {


    }

    // Update is called once per frame
    void Update () {
        changeAngle = 360 / bulletAmount;
        _timer += Time.deltaTime; //時間增加

        if (_timer <= _next_time)
            return;

        if (!can_start_attack)
            return;

        _next_time = _timer + shooting_time[game_setting.G_Stage - 1];

        switch (BoosPoolName ()) {
            case "boss1_ketamine":
                player = GameObject.Find(game_setting.Player_name[Random.Range(0, 2)]);
                if (player == null) {
                    dir = Vector3.down;
                    quate.eulerAngles = new Vector3 (0, 0, 0); // 表示設置x軸方向旋轉了 tiltAngle 度
                } else {
                    dir = player.transform.position - gameObject.transform.position;
                    float tiltAngle = Vector3.Angle (Vector3.right, dir);
                    quate.eulerAngles = new Vector3 (0, 0, tiltAngle); // 表示設置x軸方向旋轉了 tiltAngle 度
                }

                bulletClone = pool.ReUse (BoosPoolName () + "_attack", gameObject.transform.position + new Vector3 (1f, 0.2f, 0), quate);
                bulletClone.GetComponent<MobBulletMove> ().Dir = dir;
                bulletClone.GetComponent<MobBulletMove> ().Force = shooting_force[game_setting.G_Stage -1];
                bulletClone = pool.ReUse (BoosPoolName () + "_attack", gameObject.transform.position + new Vector3 (-1f, 0.2f, 0), quate);
                bulletClone.GetComponent<MobBulletMove> ().Dir = dir;
                bulletClone.GetComponent<MobBulletMove> ().Force = shooting_force[game_setting.G_Stage -1];

                break;
            case "boss2_amphetamines":
                //旋轉改變的角度
                // changeAngle = 360 / bulletAmount;

                bounds = gameObject.GetComponent<SpriteRenderer> ().bounds;
                center = gameObject.transform.position;

                // Debug.Log("Bound" + bounds + " normal" + center.normalized);
                for (int i = 0; i < bulletAmount; i++) {
                    bulletClone = pool.ReUse (BoosPoolName () + "_attack", gameObject.transform.position, gameObject.transform.rotation);
                    hudu = (angle / 180) * Mathf.PI;
                    xx = center.x + (r + bounds.extents.x) * Mathf.Cos (hudu);
                    yy = center.y + (r + bounds.extents.y) * Mathf.Sin (hudu);
                    bulletClone.transform.position = new Vector3 (xx, yy, 0);
                    angle += changeAngle;

                    Vector3 dir = bulletClone.transform.position - gameObject.transform.position;
                    quate.eulerAngles = new Vector3 (0, 0, Vector3.Angle (Vector3.down, dir)); // 表示設置x軸方向旋轉了 tiltAngle 度
                    bulletClone.transform.rotation = quate;

                    bulletClone.GetComponent<MobBulletMove> ().Dir = dir;

                    bulletClone.GetComponent<MobBulletMove> ().Force = shooting_force[game_setting.G_Stage -1];
                }
                break;
            case "boss3_heroin":
                r = 0.3f;
                changeAngle = 10;
                bounds = gameObject.GetComponent<SpriteRenderer>().bounds;
                center = gameObject.transform.position;

                hudu = (angle / 180) * Mathf.PI;

                xx = center.x + ( r + bounds.extents.x ) * Mathf.Cos (hudu);
                yy = center.y + ( r + bounds.extents.y ) * Mathf.Sin (hudu);

                quate.eulerAngles = new Vector3 (0, 0, Vector3.Angle (Vector3.down, dir)); // 表示設置x軸方向旋轉了 tiltAngle 度
                bulletClone = pool.ReUse (BoosPoolName () + "_attack", gameObject.transform.position, gameObject.transform.rotation);
                bulletClone.transform.position = new Vector3 (xx, yy, 0);
                bulletClone.transform.rotation = quate;
                dir = bulletClone.transform.position - gameObject.transform.position;
                bulletClone.GetComponent<MobBulletMove> ().Dir = dir;
                bulletClone.GetComponent<MobBulletMove> ().Force = shooting_force[game_setting.G_Stage -1];

                bulletClone = pool.ReUse (BoosPoolName () + "_attack", gameObject.transform.position, gameObject.transform.rotation);
                bulletClone.transform.position = new Vector3 (yy, xx, 0);
                quate.eulerAngles = new Vector3 (0, 0, -Vector3.Angle (Vector3.down, dir)); // 表示設置x軸方向旋轉了 tiltAngle 度
                bulletClone.transform.rotation = quate;
                dir = gameObject.transform.position - bulletClone.transform.position;
                bulletClone.GetComponent<MobBulletMove> ().Dir = dir;
                bulletClone.GetComponent<MobBulletMove> ().Force = shooting_force[game_setting.G_Stage -1];

                angle += changeAngle;

                // 追蹤彈
                player = GameObject.Find(game_setting.Player_name[Random.Range(0, 2)]);
                if (player == null) {
                    dir = Vector3.down;
                    quate.eulerAngles = new Vector3 (0, 0, 0); // 表示設置x軸方向旋轉了 tiltAngle 度
                } else {
                    dir = player.transform.position - gameObject.transform.position;
                    float tiltAngle = Vector3.Angle (Vector3.right, dir);
                    quate.eulerAngles = new Vector3 (0, 0, tiltAngle); // 表示設置x軸方向旋轉了 tiltAngle 度
                }

                bulletClone = pool.ReUse (BoosPoolName () + "_attack", gameObject.transform.position + new Vector3 (0f, -1.5f, 0), quate);
                bulletClone.GetComponent<MobBulletMove> ().Dir = dir;
                bulletClone.GetComponent<MobBulletMove> ().Force = shooting_force[game_setting.G_Stage -1];

                break;
        }
    }

    void OnTriggerEnter2D (Collider2D collider) {
        string pool_name = BoosPoolName ();
        if (collider.tag == "PlayerBullet" && Can_start_attack) {
            // pool.Recovery(pool_name, gameObject);
            hp--;

            if ( hp <= 0 ) {
                GameObject explosion = pool.ReUse("explosion", gameObject.transform.position, gameObject.transform.rotation);
                explosion.transform.localScale *= 4;
                pool.Recovery(pool_name, gameObject);
                game_setting.G_Stage += 1; // 進到下一關
                game_setting.IsBossTime = false;
                GameObject go = GameObject.Find("魔王死");
                go.GetComponent<AudioSource>().PlayOneShot(go.GetComponent<AudioSource>().clip);

                if (game_setting.G_Stage > 3) {
                    game_setting.Is_complete = true;
                } else {
                    game_setting.Now_boss_time = game_setting.Timer + game_setting.Boss_time[game_setting.G_Stage -1];
                }
            }

        }
    }

    public string BoosPoolName () {
        if (gameObject.transform.name.IndexOf ("Clone") == -1)
            return gameObject.transform.name;
        return gameObject.transform.name.Substring (0, gameObject.transform.name.IndexOf ("Clone") - 1);
    }

    public Vector3 NormalizedCenter (Vector3 location, Bounds bound) {
        return new Vector3 (location.x + bound.extents.x, location.y - bound.extents.y, location.z);
    }
}