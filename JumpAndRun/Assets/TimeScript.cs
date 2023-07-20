using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeScript : MonoBehaviour
{
    public TMP_Text timeText;
    public static int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("addSecond", 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = "Time: " + time + " sec";
    }

    void addSecond()
    {
        time++;
    }
}
