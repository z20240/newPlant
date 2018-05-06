using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ObjPool {

}

public class ObjectPool : MonoBehaviour {
    // Use this for initialization
    public GameObject player_bullet_1;
    public GameObject player_bullet_2;
    public GameObject player_bullet_3;

    public GameObject mob_cocaine; // 古柯鹼
    public GameObject mob_morphine; // 嗎啡
    public GameObject mob_marijuana; // 大麻
    public GameObject mob_mdma; // 搖頭丸
    public GameObject mob_poison_coffee; // 毒咖啡
    public GameObject mob_poison_candy; // 毒棒棒糖
    public GameObject mob_poison_bear; // 讀熊熊
    public GameObject mob_poison_suger_bar; // 毒糖棒
    public GameObject mob_poison_soft_suger; // 讀軟糖

    public GameObject mob_cocaine_attack; //
    public GameObject mob_morphine_attack; //
    public GameObject mob_marijuana_attack; //
    public GameObject mob_mdma_attack_1; //
    public GameObject mob_mdma_attack_2; //
    public GameObject mob_mdma_attack_3; //
    public GameObject mob_mdma_attack_4; //
    public GameObject mob_poison_coffee_attack; //
    public GameObject mob_poison_candy_attack; //
    public GameObject mob_poison_bear_attack; //
    public GameObject mob_poison_suger_bar_attack; //
    public GameObject mob_poison_soft_suger_attack; //

    // boss
    public GameObject boss1_ketamine; // K他命
    public GameObject boss2_amphetamines; // 安毒
    public GameObject boss3_heroin; // 海洛因

    public GameObject boss1_ketamine_attack; // K他命
    public GameObject boss2_amphetamines_attack; // 安毒
    public GameObject boss3_heroin_attack; // 海洛因

    public GameObject item_enhancement;
    public GameObject item_extra_skill;
    public GameObject item_heal_pack;
    public GameObject item_rewards;
    public GameObject explosion;

    private IDictionary<string, Queue<GameObject>> dict = new Dictionary<string, Queue<GameObject>>();

    private ArrayList QueueList = new ArrayList();

    void Awake() {

        string[] pool_name_ary = {
            "player_bullet_1", "player_bullet_2", "player_bullet_3",

            "mob_cocaine","mob_morphine","mob_marijuana","mob_mdma","mob_poison_coffee","mob_poison_candy","mob_poison_bear","mob_poison_suger_bar","mob_poison_soft_suger",

            "mob_cocaine_attack", "mob_morphine_attack", "mob_marijuana_attack", "mob_mdma_attack_1", "mob_mdma_attack_2", "mob_mdma_attack_3", "mob_mdma_attack_4", "mob_poison_coffee_attack", "mob_poison_candy_attack", "mob_poison_bear_attack", "mob_poison_suger_bar_attack", "mob_poison_soft_suger_attack",

            "boss1_ketamine", "boss2_amphetamines", "boss3_heroin",

            "boss1_ketamine_attack", "boss2_amphetamines_attack", "boss3_heroin_attack",

            "item_enhancement", "item_extra_skill", "item_heal_pack", "item_rewards",

            "explosion",
        };

        foreach (string name in pool_name_ary) {
            dict[name] = new Queue<GameObject>();
        }

        InitPool(dict["player_bullet_1"], player_bullet_1, 21);
        InitPool(dict["player_bullet_2"], player_bullet_2, 21);
        InitPool(dict["player_bullet_3"], player_bullet_3, 241);

        InitPool(dict["mob_cocaine"], mob_cocaine, 21);
        InitPool(dict["mob_morphine"], mob_morphine, 21);
        InitPool(dict["mob_marijuana"], mob_marijuana, 21);
        InitPool(dict["mob_mdma"], mob_mdma, 21);
        InitPool(dict["mob_poison_coffee"], mob_poison_coffee, 21);
        InitPool(dict["mob_poison_candy"], mob_poison_candy, 21);
        InitPool(dict["mob_poison_bear"], mob_poison_bear, 21);
        InitPool(dict["mob_poison_suger_bar"], mob_poison_suger_bar, 21);
        InitPool(dict["mob_poison_soft_suger"], mob_poison_soft_suger, 21);

        InitPool(dict["mob_cocaine_attack"], mob_cocaine_attack, 21);
        InitPool(dict["mob_morphine_attack"], mob_morphine_attack, 21);
        InitPool(dict["mob_marijuana_attack"], mob_marijuana_attack, 21);
        InitPool(dict["mob_mdma_attack_1"], mob_mdma_attack_1, 21);
        InitPool(dict["mob_mdma_attack_2"], mob_mdma_attack_2, 21);
        InitPool(dict["mob_mdma_attack_3"], mob_mdma_attack_3, 21);
        InitPool(dict["mob_mdma_attack_4"], mob_mdma_attack_4, 21);
        InitPool(dict["mob_poison_coffee_attack"], mob_poison_coffee_attack, 21);
        InitPool(dict["mob_poison_candy_attack"], mob_poison_candy_attack, 21);
        InitPool(dict["mob_poison_bear_attack"], mob_poison_bear_attack, 21);
        InitPool(dict["mob_poison_suger_bar_attack"], mob_poison_suger_bar_attack, 21);
        InitPool(dict["mob_poison_soft_suger_attack"], mob_poison_soft_suger_attack, 21);

        InitPool(dict["boss1_ketamine"], boss1_ketamine, 1);
        InitPool(dict["boss2_amphetamines"], boss2_amphetamines, 1);
        InitPool(dict["boss3_heroin"], boss3_heroin, 1);

        InitPool(dict["boss1_ketamine_attack"], boss1_ketamine_attack, 21);
        InitPool(dict["boss2_amphetamines_attack"], boss2_amphetamines_attack, 21);
        InitPool(dict["boss3_heroin_attack"], boss3_heroin_attack, 21);


        InitPool(dict["item_enhancement"], item_enhancement, 21);
        InitPool(dict["item_extra_skill"], item_extra_skill, 21);
        InitPool(dict["item_heal_pack"], item_heal_pack, 21);
        InitPool(dict["item_rewards"], item_rewards, 21);

        InitPool(dict["explosion"], explosion, 21);

    }

    public GameObject ReUse(string pool_name, Vector3 position, Quaternion rotation, int degree = 90) {
        return Use(dict[pool_name], position, rotation, degree);
    }


    public void Recovery(string pool_name, GameObject recovery) {
        Reback(dict[pool_name], recovery);
    }

    void InitPool(Queue<GameObject> pool, GameObject obj, int amount) {
        for ( int i = 0; i < amount ; i++ ) {
            GameObject go = Instantiate( obj ) as GameObject;
            pool.Enqueue( go );
            go.SetActive( false );
        }
    }

    GameObject Use(Queue<GameObject> pool, Vector3 position, Quaternion rotation, int degree = 90) {
        if (pool.Count > 1) {
            GameObject reuse = pool.Dequeue();
            reuse.transform.position = position;
            reuse.transform.rotation = rotation;
            reuse.SetActive( true );

            if ( reuse.name.Contains("player_bullet_3") ) {
                BulletMove bm = reuse.GetComponent<BulletMove>();
                bm.Degree = degree;
            }
            return reuse;
        } else {
            GameObject reuse = pool.Peek();
            reuse.name = getName(reuse.name);
            GameObject go = Instantiate( reuse ) as GameObject;
            go.transform.position = position;
            go.transform.rotation = rotation;
            go.SetActive( true );

            if ( go.name.Contains("player_bullet_3") ) {
                BulletMove bm = go.GetComponent<BulletMove>();
                bm.Degree = degree;
            }
            return go;
        }
    }

    void Reback(Queue<GameObject> pool, GameObject recovery) {
        pool.Enqueue ( recovery );
        recovery.SetActive ( false );
    }


    string getName(string name) {
        if (name.IndexOf("Clone") == -1)
            return name;
        return name.Substring(0, name.IndexOf("Clone")-1);
    }
}
