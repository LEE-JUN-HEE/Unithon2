﻿using UnityEngine;
using System.Collections;

public class ExitHowToScript : MonoBehaviour {

    //UISprite _sprite;
    public GameObject delete;
    public GameObject startBtn;
    public GameObject RankBtn;
    public GameObject howToBtn;

	// Use this for initialization
	void Start () {

        //_sprite = GetComponent<UISprite>();
		delete.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick_close()
    {
        delete.SetActive(false);
        startBtn.SetActive(true);
        RankBtn.SetActive(true);
        howToBtn.SetActive(true);
    }

    /*
    //마우스 올렸을 때
    void OnHover(bool isOver)
    {
        _sprite.cachedTransform.localScale = (isOver) ? Vector2.one * 1.2f : Vector2.one;

    }
    */
}
