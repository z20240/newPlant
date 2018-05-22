using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHp : MonoBehaviour {

	// Use this for initialization
    GameObject boss;
    float ori_length;
    int ori_boss_hp;
	void Start () {
        boss = gameObject.transform.parent.gameObject;
        ori_boss_hp = boss.GetComponent<Boss>().Hp;
        ori_length = gameObject.transform.localScale.x;
	}

	// Update is called once per frame
	void Update () {
        gameObject.transform.localScale = new Vector3((float)(ori_length * boss.GetComponent<Boss>().Hp / ori_boss_hp), gameObject.transform.localScale.y, gameObject.transform.localScale.z);
	}
}
