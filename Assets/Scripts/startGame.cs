using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class startGame : MonoBehaviour
{
    public GameObject gameCanvas;
    public GameObject startCanvas;
    public GameObject AttentionCube;
    public GameObject MeditationCube;

    public void OnClick(){
        gameCanvas.SetActive(true);
        startCanvas.SetActive(false);
        AttentionCube.SetActive(true);
        MeditationCube.SetActive(true);
    }
}
