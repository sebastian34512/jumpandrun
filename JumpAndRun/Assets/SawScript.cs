using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject saw;
    
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(2.5f,0), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(saw);
    }
}
