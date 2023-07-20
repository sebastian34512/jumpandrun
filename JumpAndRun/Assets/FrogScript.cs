using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    public float jumptime = 2f;
    public float sawtime = 4f;
    public GameObject frog;
    public GameObject saw;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Jump", jumptime, jumptime);
        InvokeRepeating("ShootSaw", sawtime, sawtime);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShootSaw()
    {
        GameObject schuss = Instantiate(saw);
        schuss.transform.position = new Vector3(frog.transform.position.x + 1, frog.transform.position.y);        
    }

    void Jump()
    {
        frog.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));
        frog.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 6), ForceMode2D.Impulse);

        
    }

}
