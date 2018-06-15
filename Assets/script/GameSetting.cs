using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSetting : MonoBehaviour {

	// Use this for initialization
    [Header("關卡設置")]
    public int g_Stage = 1;
    [Header("第一關背景音樂")]
    public AudioSource stage_audio_1;
    [Header("第二關背景音樂")]
    public AudioSource stage_audio_2;
    [Header("第三關背景音樂")]
    public AudioSource stage_audio_3;
    [Header("第一台飛機")]
    public GameObject plant_1;
    [Header("第二台飛機")]
    public GameObject plant_2;

    private int maxStage = 3;
    private float[] boss_time = {60f, 60f, 60f};

    private List<Item> item_list = new List<Item>();

    private bool isBossTime = false;
    private float now_boss_time = 0.0f;
    private float _timer = 0;
    private bool[] playerAlive = {true, true};
    private bool is_complete = false;
    private float waiting_scence_time = 0;
    private List<AudioSource> stage_audio;
    private AudioSource current_audio;


    string[] player_name = {"plant_1", "plant_2"};

    public GameObject UIPause; // Inspector 傳入
    public bool PlayerCritical = false; // 玩家的大招

    public int G_Stage {
        get { return g_Stage; }
        set { g_Stage = value; }
    }

    public string[] Player_name {
        get { return player_name; }
        set { player_name = value; }
    }

    public bool IsBossTime {
        get { return isBossTime; }
        set { isBossTime = value; }
    }

    public float[] Boss_time {
        get { return boss_time; }
        set { boss_time = value; }
    }

    public float Now_boss_time {
        get { return now_boss_time; }
        set { now_boss_time = value; }
    }

    public float Timer {
        get { return _timer; }
    }

    public List<Item> Item_list {
        get { return item_list; }
        set { item_list = value; }
    }

    public int MaxStage {
        get { return maxStage; }
        set { maxStage = value; }
    }

    public bool Is_complete {
        get { return is_complete; }
        set { is_complete = value; }
    }

    void Start () {
        Screen.SetResolution(1920, 1080, true);
        now_boss_time = boss_time[0];
        item_list.Add(new Item("item_enhancement", 5f));
        item_list.Add(new Item("item_extra_skill", 5f));
        item_list.Add(new Item("item_heal_pack", 10f));
        item_list.Add(new Item("item_rewards", 20f)); // 這其實是防護罩

        stage_audio = new List<AudioSource>(){stage_audio_1, stage_audio_2, stage_audio_3};

        if (PlayerPrefs.GetInt("player_num") == 1)
            GameObject.Find("plant_2").SetActive(false);

        stage_audio[0].Play();
        stage_audio[0].playOnAwake = true;
        stage_audio[0].loop = true;
        stage_audio[0].volume = 1;
    }

	// Update is called once per frame
	void Update () {
        _timer += Time.deltaTime; //時間增加

        if (g_Stage >= 3) Debug.Log("g_Stage:" + g_Stage);

        if ( g_Stage != 0 && g_Stage <= 3 && !stage_audio[g_Stage - 1].playOnAwake ) {
            if (g_Stage > 1)
                stage_audio[g_Stage - 2].Stop();
            Debug.Log("current_audio:" + g_Stage);
            stage_audio[g_Stage - 1].Play();
            stage_audio[g_Stage - 1].playOnAwake = true;
            stage_audio[g_Stage - 1].loop = true;
            stage_audio[g_Stage - 1].volume = 1;
        }

        if (Input.GetKey(KeyCode.Return) || Input.GetButtonDown ("Start")) {
            Pause();
        }

        if (Input.GetKey(KeyCode.Escape))
            ShotDownGame();

        if (Is_complete) {
            // 成功破關
            if (waiting_scence_time <= 0)
                waiting_scence_time = _timer + 1f;
            else if (_timer > waiting_scence_time)
                SceneManager.LoadScene("EndSuccess");
        }
	}

    public void Pause() {
        //時間暫停
        Time.timeScale = 0f;
        UIPause.SetActive(true);
    }

    public void Continue() {
        //時間以正常速度運行
        Time.timeScale = 1f;
        UIPause.SetActive(false);
    }

    public void ShotDownGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("FinalScene");
    }

    public bool IsPlant1Active() {
        return plant_1.activeSelf;
    }
    public bool IsPlant2Active() {
        return plant_2.activeSelf;
    }
}
