using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    private TextMeshProUGUI scoreText = default;
    private float score;

    public static ScoreSystem instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = "Score " + score;
    }

    public void UpdateScore(float scoreValue)
    {
        score += scoreValue;
        scoreText.text = "Score " + score;
    }
}
