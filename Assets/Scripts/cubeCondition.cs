using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;  

public class cubeCondition : MonoBehaviour
{
    public GameObject AttenCube;
    public GameObject MediCube;
    public float timer;
    public float bestTime;
    public Text uiTime;
    public Text bestT;
    public AudioSource source;
    public int timeSeconds;

    void Start()
    {
        bestTime=PlayerPrefs.GetInt ("highscore");
        var bts = TimeSpan.FromSeconds(bestTime);
        bestT.text = string.Format("{0:00}:{1:00}", bts.TotalMinutes, bts.Seconds);
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveAC.score >= 50f && MoveMC.score >= 50f)
        {
            timer += Time.deltaTime;
            var ts = TimeSpan.FromSeconds(timer);
            uiTime.text = string.Format("{0:00}:{1:00}", ts.TotalMinutes, ts.Seconds);
            if (timeSeconds < ts.Seconds){
                timeSeconds=ts.Seconds;
                source.Play();
            }
            if(bestTime < timer){
                bestTime = timer;
                PlayerPrefs.SetInt ("highscore",(int)Math.Floor(bestTime));
                bestT.text = uiTime.text;
                
            }

        }
        else
        {
            timeSeconds = 0;
            timer = 0f;
            uiTime.text = "00:00";
        }
    }
}
