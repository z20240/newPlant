using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIAction : MonoBehaviour {

    CanvasGroup cg;

    // Use this for initialization
	void Start () {
        cg = gameObject.GetComponent<CanvasGroup>();
	}

	// Update is called once per frame
	void Update () {
        DOTween.To(() => cg.alpha, x => cg.alpha = x, 1, 2);
	}
}
