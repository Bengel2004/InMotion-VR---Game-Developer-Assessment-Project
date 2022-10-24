using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScore : MonoBehaviour
{
    private TextMeshProUGUI finalScoreText = default;

    private void Awake()
    {
        finalScoreText = GetComponent<TextMeshProUGUI>();
    }
    void OnEnable()
    {
        finalScoreText.text = "final score " + ScoreSystem.instance.GetScore().ToString();
    }

}
