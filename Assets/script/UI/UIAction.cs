using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIAction : MonoBehaviour {

    CanvasGroup cg;

    // Use this for initialization
	void Start () {
        cg = gameObject.GetComponent<CanvasGroup>();
        Screen.SetResolution(1920, 1080, true);
	}

	// Update is called once per frame
	void Update () {
        DOTween.To(() => cg.alpha, x => cg.alpha = x, 1, 2);
	}
}
