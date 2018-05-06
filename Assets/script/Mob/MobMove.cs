using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MobMove : MonoBehaviour {
    // setting
    private float force = 5f;
    public float forceTime = 0.5f;

    string[] player_name = {"plant_1", "plant_2"};
    private float _timer, _next_time;
    GameObject player;
    Mob mob;

    string[] top_mob_name = {"mob_cocaine", "mob_morphine", "mob_marijuana", "mob_mdma", "mob_poison_coffee",};
    string[] left_mob_name = {"mob_poison_candy", "mob_poison_bear",};
    string[] right_mob_name = {"mob_poison_suger_bar", "mob_poison_soft_suger",};
	// Use this for initialization
	void Start () {
        mob = gameObject.GetComponent<Mob>() ;
	}

	// Update is called once per frame
	void Update () {

	}

    void FixedUpdate() {
        _timer += Time.deltaTime; //時間增加
        if ( _timer <= _next_time)
            return;

        // Debug.Log("now :" + _timer + " next:" + _next_time);
        _next_time = _timer + forceTime;


        // 左


        // 右

        Vector3 dir = new Vector3(0, 0, 0);
        player = GameObject.Find(player_name[UnityEngine.Random.Range(0, 2)]);

        if( Array.IndexOf(top_mob_name, mob.GetName(mob.name)) != -1 ) {
            // if ( player == null )
                dir = Vector3.down;
            // else
            //     dir = player.transform.position - gameObject.transform.position;
        } else if( Array.IndexOf(left_mob_name, mob.GetName(mob.name)) != -1 ) {
            force = 10;
            if ( player == null ) dir = Vector3.right;
            else dir = player.transform.position - gameObject.transform.position;
        } else if( Array.IndexOf(right_mob_name, mob.GetName(mob.name)) != -1 ) {
            force = 10;
            if ( player == null ) dir = Vector3.left;
            else dir = player.transform.position - gameObject.transform.position;
        } else {
            dir = Vector3.down;
        }

        gameObject.GetComponent<Rigidbody2D>().AddForce(dir * force);
    }
}
