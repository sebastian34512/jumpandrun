using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreScript : MonoBehaviour
{
    public TMP_Text scoreText;
    public static int scoreValue;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "YOUR SCORE: " + scoreValue;
    }
}

