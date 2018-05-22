using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class PlantMove : MonoBehaviour {
    /**
     * setting
     */
     private float plane_speed = 0.1f;

    /*
     * private setting
     */
    private float time;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

        time += Time.deltaTime;

    //     if ( Input.GetKey(KeyCode.Joystick1Button0) ) {
    //         Debug.Log("抓到了！ Joystick1Button0");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick1Button1) ) {
    //         Debug.Log("抓到了！ Joystick1Button1");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick1Button2) ) {
    //         Debug.Log("抓到了！ Joystick1Button2");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick1Button3) ) {
    //         Debug.Log("抓到了！ Joystick1Button3");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick1Button4) ) {
    //         Debug.Log("抓到了！ Joystick1Button4");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick1Button5) ) {
    //         Debug.Log("抓到了！ Joystick1Button5");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick1Button6) ) {
    //         Debug.Log("抓到了！ Joystick1Button6");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick1Button7) ) {
    //         Debug.Log("抓到了！ Joystick1Button7");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick1Button8) ) {
    //         Debug.Log("抓到了！ Joystick1Button8");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick1Button9) ) {
    //         Debug.Log("抓到了！ Joystick1Button9");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick1Button10) ) {
    //         Debug.Log("抓到了！ Joystick1Button10");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick1Button11) ) {
    //         Debug.Log("抓到了！ Joystick1Button11");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick1Button12) ) {
    //         Debug.Log("抓到了！ Joystick1Button12");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick1Button13) ) {
    //         Debug.Log("抓到了！ Joystick1Button13");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick1Button14) ) {
    //         Debug.Log("抓到了！ Joystick1Button14");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick1Button15) ) {
    //         Debug.Log("抓到了！ Joystick1Button15");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick1Button16) ) {
    //         Debug.Log("抓到了！ Joystick1Button16");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick1Button17) ) {
    //         Debug.Log("抓到了！ Joystick1Button17");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick1Button18) ) {
    //         Debug.Log("抓到了！ Joystick1Button18");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick1Button19) ) {
    //         Debug.Log("抓到了！ Joystick1Button19");
    //     }





    //     if ( Input.GetKey(KeyCode.Joystick2Button0) ) {
    //         Debug.Log("抓到了！ Joystick2Button0");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick2Button1) ) {
    //         Debug.Log("抓到了！ Joystick2Button1");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick2Button2) ) {
    //         Debug.Log("抓到了！ Joystick2Button2");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick2Button3) ) {
    //         Debug.Log("抓到了！ Joystick2Button3");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick2Button4) ) {
    //         Debug.Log("抓到了！ Joystick2Button4");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick2Button5) ) {
    //         Debug.Log("抓到了！ Joystick2Button5");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick2Button6) ) {
    //         Debug.Log("抓到了！ Joystick2Button6");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick2Button7) ) {
    //         Debug.Log("抓到了！ Joystick2Button7");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick2Button8) ) {
    //         Debug.Log("抓到了！ Joystick2Button8");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick2Button9) ) {
    //         Debug.Log("抓到了！ Joystick2Button9");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick2Button10) ) {
    //         Debug.Log("抓到了！ Joystick2Button10");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick2Button11) ) {
    //         Debug.Log("抓到了！ Joystick2Button11");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick2Button12) ) {
    //         Debug.Log("抓到了！ Joystick2Button12");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick2Button13) ) {
    //         Debug.Log("抓到了！ Joystick2Button13");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick2Button14) ) {
    //         Debug.Log("抓到了！ Joystick2Button14");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick2Button15) ) {
    //         Debug.Log("抓到了！ Joystick2Button15");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick2Button16) ) {
    //         Debug.Log("抓到了！ Joystick2Button16");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick2Button17) ) {
    //         Debug.Log("抓到了！ Joystick2Button17");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick2Button18) ) {
    //         Debug.Log("抓到了！ Joystick2Button18");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick2Button19) ) {
    //         Debug.Log("抓到了！ Joystick2Button19");
    //     }



    // if ( Input.GetKey(KeyCode.Joystick3Button0) ) {
    //         Debug.Log("抓到了！ Joystick3Button0");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick3Button1) ) {
    //         Debug.Log("抓到了！ Joystick3Button1");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick3Button2) ) {
    //         Debug.Log("抓到了！ Joystick3Button2");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick3Button3) ) {
    //         Debug.Log("抓到了！ Joystick3Button3");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick3Button4) ) {
    //         Debug.Log("抓到了！ Joystick3Button4");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick3Button5) ) {
    //         Debug.Log("抓到了！ Joystick3Button5");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick3Button6) ) {
    //         Debug.Log("抓到了！ Joystick3Button6");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick3Button7) ) {
    //         Debug.Log("抓到了！ Joystick3Button7");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick3Button8) ) {
    //         Debug.Log("抓到了！ Joystick3Button8");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick3Button9) ) {
    //         Debug.Log("抓到了！ Joystick3Button9");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick3Button10) ) {
    //         Debug.Log("抓到了！ Joystick3Button10");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick3Button11) ) {
    //         Debug.Log("抓到了！ Joystick3Button11");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick3Button12) ) {
    //         Debug.Log("抓到了！ Joystick3Button12");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick3Button13) ) {
    //         Debug.Log("抓到了！ Joystick3Button13");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick3Button14) ) {
    //         Debug.Log("抓到了！ Joystick3Button14");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick3Button15) ) {
    //         Debug.Log("抓到了！ Joystick3Button15");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick3Button16) ) {
    //         Debug.Log("抓到了！ Joystick3Button16");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick3Button17) ) {
    //         Debug.Log("抓到了！ Joystick3Button17");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick3Button18) ) {
    //         Debug.Log("抓到了！ Joystick3Button18");
    //     }
    //     if ( Input.GetKey(KeyCode.Joystick3Button19) ) {
    //         Debug.Log("抓到了！ Joystick3Button19");
    //     }

        float value;

        if ( gameObject.name == "plant_1" ) {
            if ( Input.GetKey(KeyCode.RightArrow) ) {
                gameObject.transform.position += new Vector3(plane_speed,0,0);
            }
            if ( Input.GetKey(KeyCode.LeftArrow) ) {
                gameObject.transform.position += new Vector3(-plane_speed,0,0);
            }
            if ( Input.GetKey(KeyCode.UpArrow) ) {
                gameObject.transform.position += new Vector3(0,plane_speed,0);
            }
            if ( Input.GetKey(KeyCode.DownArrow) ) {
                gameObject.transform.position += new Vector3(0,-plane_speed,0);
            }

            if ((value = Input.GetAxis ("Horizontal_player1")) != 0) {
                if (value > 0) gameObject.transform.position += new Vector3(plane_speed,0,0);
                else gameObject.transform.position += new Vector3(-plane_speed,0,0);
            }
            if ((value = Input.GetAxis ("Vertical_player1")) != 0) {
                if (value > 0) gameObject.transform.position += new Vector3(0,plane_speed,0);
                else gameObject.transform.position += new Vector3(0,-plane_speed,0);
            }
        } else if ( gameObject.name == "plant_2" ) {
            if ( Input.GetKey(KeyCode.D) ) {
            gameObject.transform.position += new Vector3(plane_speed,0,0);
            }
            if ( Input.GetKey(KeyCode.A) ) {
                gameObject.transform.position += new Vector3(-plane_speed,0,0);
            }
            if ( Input.GetKey(KeyCode.W) ) {
                gameObject.transform.position += new Vector3(0,plane_speed,0);
            }
            if ( Input.GetKey(KeyCode.S) ) {
                gameObject.transform.position += new Vector3(0,-plane_speed,0);
            }

            if ((value = Input.GetAxis ("Horizontal_player2")) != 0) {
                if (value > 0) gameObject.transform.position += new Vector3(plane_speed,0,0);
                else gameObject.transform.position += new Vector3(-plane_speed,0,0);
            }
            if ((value = Input.GetAxis ("Vertical_player2")) != 0) {
                if (value > 0) gameObject.transform.position += new Vector3(0,plane_speed,0);
                else gameObject.transform.position += new Vector3(0,-plane_speed,0);
            }
        }

	}
}
