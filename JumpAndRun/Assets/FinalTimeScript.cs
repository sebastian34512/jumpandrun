using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalTimeScript : MonoBehaviour
{
    public TMP_Text timeText;
    public static int time;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = "YOUR TIME: " + time + " sec";
    }
}
