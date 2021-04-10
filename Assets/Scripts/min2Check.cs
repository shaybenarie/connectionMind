using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;  

public class min2Check : MonoBehaviour
{
    public GameObject gameCanvas;
    public GameObject endCanvas;
    public GameObject AttentionCube;
    public GameObject MeditationCube;
    public Text remainText;
    
    public float timeRemaining = 10;

    void Update()
    {
        if(gameCanvas.activeSelf)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                var ts = TimeSpan.FromSeconds(timeRemaining);
                remainText.text = string.Format("{0:00}:{1:00}", ts.TotalMinutes, ts.Seconds);
            }
            else
            {
                gameCanvas.SetActive(false);
                endCanvas.SetActive(true);
                AttentionCube.SetActive(false);
                MeditationCube.SetActive(false);
            }
        }
    }

}
