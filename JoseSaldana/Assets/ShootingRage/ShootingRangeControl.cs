﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingRangeControl : MonoBehaviour {
    static public int score;
    public Text scoreText;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Hits: " + score;
	}
}
