using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIAction : MonoBehaviour {

    CanvasGroup cg;

    void Awake() {
        cg = gameObject.GetComponent<CanvasGroup>();
    }

    // Use this for initialization
	void Start () {
        Screen.SetResolution(1920, 1080, true);
	}

	// Update is called once per frame
	void Update () {
        DOTween.To(() => {
                // Debug.Log("[pre] cg.alpha:" + cg.alpha);
                return cg.alpha;
            }, x => {
                cg.alpha = x;
                // Debug.Log("x:" + x + " cg.alpha:" + cg.alpha);
        }, 1, 2);
	}
}
