using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private String label;
    public int score{get; private set; }

    // Start is called before the first frame update
    private void Start() {
        score = 0;
        label = "Score: ";
    }

    private void UpdateUI() {
        scoreText.text = label + score;
    }

    public void addScore(int point) {
        score += point;
        UpdateUI();
    }

    public void reduceScore(int point) {
        score -= point;
        UpdateUI();
    }
}
