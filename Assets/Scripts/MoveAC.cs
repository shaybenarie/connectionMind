using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MoveAC : MonoBehaviour
{
    public float highPosition;
    public float howMuchScore;
    public static float score;
    public ThinkGear thinkGear;
    public Text myText;
    public float updateScore;
    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
        myText.text = "Attention: " + score;
        thinkGear.UpdateConnectedStateEvent += OnConnectFunction;
        thinkGear.UpdateAttentionEvent += OnAttentionUpdate;
    }

    // Update is called once per frame

    private void OnAttentionUpdate(int value)
    {
        updateScore = value;
        myText.text = "Attention: " + updateScore;
        if (score < updateScore)
        {
            if (score >= 0 && score< 50){
                transform.position += Vector3.up * (highPosition/howMuchScore)*Math.Min(updateScore-score,50-score) ;
            }
            score = updateScore;
        }
        if (score > updateScore)
        {
            if (score > 0 && updateScore<=50){
                transform.position += Vector3.down * (highPosition/howMuchScore)*Math.Min(score-updateScore,50-updateScore) ;
            }
            score = updateScore;
        }
    }

    private void OnConnectFunction()
    {
        thinkGear.StartMonitoring();
        Debug.Log("sensor on");
    }
}

