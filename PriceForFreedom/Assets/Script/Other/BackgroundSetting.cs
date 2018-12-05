﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundSetting : MonoBehaviour {

    public static BackgroundSetting Instance;

    public static int PlayerLayer = 9, GroundLayer = 12, BodyPartLayer = 13, DullLayer = 14, ObstacleLayer = 15;

    public static int totalLevel = 12, curLevel = 1, highestLevel = 1;   

    public static Material highlightMat, bloodRedMat;

    // Use this for initialization
    void Awake () {
        if (Instance == null)
        {
            Instance = this;
            highlightMat = Resources.Load<Material>("Material/Highlight");
            bloodRedMat = Resources.Load<Material>("Material/bloodRed");
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void LoadLevel(int levelNum)
    {
        curLevel = levelNum;
        if (curLevel > highestLevel)
        {
            highestLevel = curLevel;
        }
        SceneManager.LoadScene(levelNum + 1);   //level 1 in sence num 2, 0 = Menu, 1 = level selection
    }

    public void NextLevel()
    {
        LoadLevel(curLevel + 1);
    }
}
