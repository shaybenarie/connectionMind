using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MoveMC : MonoBehaviour
{
    public float highPosition;
    public float howMuchScore;
    public static float score;
    public Text myText;
    public ThinkGear thinkGear;
    public float updateScore;
    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
        myText.text = "Meditation: " + score;
        thinkGear.UpdateConnectedStateEvent += OnConnectFunction;
        thinkGear.UpdateMeditationEvent += OnMeditationUpdate;
    }

    // Update is called once per frame
     void Update()
    {
        myText.text = "Meditation: " + score;
        if (score < updateScore)
        {
            if (score >= 0 && score<50){
                transform.position += Vector3.down * (highPosition/howMuchScore)*Math.Min(updateScore-score,50-score) ;
            }
            score = updateScore;
        }
        if (score > updateScore)
        {
            if (score > 0 && updateScore<=50){
                transform.position += Vector3.up * (highPosition/howMuchScore)*Math.Min(score-updateScore,50-updateScore) ;
            }
            score = updateScore;
        }
    }
      public float getScore()
    {
        return score;
    }
      private void OnMeditationUpdate(int value)
    {
        updateScore = value;
    }
    private void OnConnectFunction()
    {
        thinkGear.StartMonitoring();
        Debug.Log("sensor on");
    }
}
