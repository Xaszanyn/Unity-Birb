using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text text;
    public static int score;

    void Start() {
        text = GetComponent<Text>();
        score = 0;
    }

    void Update() {
        text.text = "Score: " + score;
    }
}
