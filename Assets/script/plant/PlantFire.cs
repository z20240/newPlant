using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantFire : MonoBehaviour {

    public float spawnTime = 0.2f;
    // Use this for initialization
    public int bullet_type;
    GameObject obj_pool;
    private ObjectPool pool;
    private float _timer;
    private string[] bullet_name = {"player_bullet_1", "player_bullet_2", "player_bullet_3"};

    void Awake() {
        obj_pool = GameObject.Find("ObjectPool");
        pool = obj_pool.GetComponent<ObjectPool>(); // 物件池
    }

    void Start () {
        // bullet_type = 2;

        pool = obj_pool.GetComponent<ObjectPool>(); // 物件池
    }

    // Update is called once per frame

    void Update() {
        // if ( Time.time > _timer + spawnTime ) {
        if ( Time.time > _timer + spawnTime ) {
            _timer = Time.time;

            switch( bullet_name[bullet_type] ) {
                case "player_bullet_1":
                    pool.ReUse( bullet_name[bullet_type], transform.position + new Vector3(0, 1f, 0), transform.rotation);
                    return;
                case "player_bullet_2":
                    pool.ReUse( bullet_name[bullet_type], transform.position + new Vector3(0, 1f, 0), transform.rotation);
                    return;
                case "player_bullet_3":
                    Bounds bounds = gameObject.GetComponent<SpriteRenderer>().bounds;
                    int tiltAngle = 0;
                    float r = 1f;

                    for (int i = 1 ; i <= 11 ; i++ ) {
                        Quaternion quate = Quaternion.identity;
                        tiltAngle = i * 15 - 90;
                        quate.eulerAngles = new Vector3(0, 0, tiltAngle); // 表示設置x軸方向旋轉了 tiltAngle 度

                        float hudu = ((float)(i * 15) / 180) * Mathf.PI;
                        float xx = transform.position.x + ( r + bounds.extents.x ) * Mathf.Cos (hudu);
                        float yy = transform.position.y + ( r + bounds.extents.y ) * Mathf.Sin (hudu);

                        pool.ReUse( bullet_name[bullet_type], new Vector3(xx, yy, 0), quate, i * 15 );
                    }
                    return;
            }
        }

        if ( ( (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Joystick1Button1)) && gameObject.name == "plant_1") 
            || ( (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Joystick2Button1) ) && gameObject.name == "plant_2") 
        ) {
            if ( gameObject.GetComponent<Plant>().Extra_skill_count <= 0 )
                return;

            GameObject[] gameObjects;
            gameObjects = GameObject.FindGameObjectsWithTag("Mob");

            for(var i = 0 ; i < gameObjects.Length ; i ++) {
                gameObjects[i].GetComponent<Mob>().OnTriggerEnter2D(gameObject.GetComponent<Collider2D>());
            }

            gameObject.GetComponent<Plant>().Extra_skill_count -= 1;
            GameObject.Find("UICanvas").GetComponent<UICtrl>().delEnergy();
        }
    }

    public Vector3 NormalizedCenter(Vector3 location, Bounds bound) {
        return new Vector3(location.x + bound.extents.x, location.y - bound.extents.y, location.z);
    }
}
