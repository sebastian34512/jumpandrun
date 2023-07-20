using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScipt : MonoBehaviour
{
    public GameObject platform;
    public SliderJoint2D joint;
    public float time = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("changeSpeed", time, time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeSpeed()
    {
        JointMotor2D antrieb = joint.motor;

        antrieb.motorSpeed *= -1;

        joint.motor = antrieb;

    }
}
