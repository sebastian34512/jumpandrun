using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool amBoden;
    bool anWand = false;
    bool touchingTrampoline = false;
    public Tilemap terrain;
    public Tilemap walls;
    public GameObject spieler;
    public GameObject trampoline;
    SpriteRenderer renderer;
    public float speed;
    public Animator animator;
    public Animator trampolineAnimator;
    
    
    
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

            
        //Springen
        if ((Input.GetButton("Jump")) && (amBoden))
        {

        spieler.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));
        spieler.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 15), ForceMode2D.Impulse);

            animator.SetBool("isJumping", true);

            amBoden = false;            
        }

        //Wandsprung
        if ((Input.GetButton("Jump"))  && (anWand))
        {

            spieler.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));
            spieler.GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxis("Horizontal") * 10 * -1, 15), ForceMode2D.Impulse);

            animator.SetBool("isJumping", true);
            animator.SetBool("isTouchingWall", true);


            anWand = false;
        }

        //Trampolin Sprung
        if (touchingTrampoline)
        {

            spieler.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 0));
            spieler.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 35), ForceMode2D.Impulse);

            animator.SetBool("isJumping", true);




            trampoline.GetComponent<Animator>().SetBool("isTouchingTrampoline", false);
            touchingTrampoline = false;
        }



        //Laufen
        Vector3 playerPos = spieler.transform.position;
        playerPos.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        spieler.transform.position = playerPos;

        animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal") * speed));

        //In Bewegungsrichtung schauen
        renderer = spieler.GetComponent<SpriteRenderer>();
        if (Input.GetAxis("Horizontal") >= 0)
        {            
            renderer.flipX = false;            
        } else
        {
            renderer.flipX = true;        
        }

        





      //  Debug.Log(amBoden);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Items
        if (collision.gameObject.CompareTag("Items"))
        {
            GameObject sound;
            sound = GameObject.Find("itemCollectSound");

            sound.GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
            // collision.gameObject.SetActive(false);
            ScoreScript.scoreValue += 1;
        }

        //Sterben
        if(collision.gameObject.tag == "Death")
        {
            FinalTimeScript.time = TimeScript.time;
            FinalScoreScript.scoreValue = ScoreScript.scoreValue;
            SceneManager.LoadScene(2);
            
        }

        //Gewinnen
        if (collision.gameObject.tag == "Win")
        {
            FinalTimeScript.time = TimeScript.time;
            FinalScoreScript.scoreValue = ScoreScript.scoreValue;
            SceneManager.LoadScene(3);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Laufen
        if (spieler.GetComponent<CircleCollider2D>().IsTouching(terrain.GetComponent<CompositeCollider2D>()))
        {
            amBoden = true;
            anWand = false;
            animator.SetBool("isJumping", false);
            
              Debug.Log("Am Boden");

        }

        //Platformen
        // || spieler.GetComponent<CircleCollider2D>().IsTouching(GameObject.FindWithTag("Platforms").GetComponent<BoxCollider2D>())
         if(collision.gameObject.CompareTag("Platforms"))
        {
            amBoden = true;
            anWand = false;
            animator.SetBool("isJumping", false);
        }

        //Gegner töten
        if (collision.gameObject.CompareTag("Death") && spieler.GetComponent<CircleCollider2D>().IsTouching(collision.gameObject.GetComponent<BoxCollider2D>()))
        {
            Destroy(collision.gameObject);
        }


        //Walljump
        if (spieler.GetComponent<CircleCollider2D>().IsTouching(walls.GetComponent<CompositeCollider2D>()) && !amBoden)
        {
            anWand = true;
           // spieler.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            //amBoden = false; //--> Muss man mit OnCollisionExit wieder umkehren
            animator.SetBool("isTouchingWall", true);
        }

        //Trampoline
        if (spieler.GetComponent<CircleCollider2D>().IsTouching(trampoline.GetComponent<BoxCollider2D>()) && !amBoden)
        {
            touchingTrampoline = true;
            trampoline.GetComponent<Animator>().SetBool("isTouchingTrampoline", true);
            Debug.Log("Hallo");
            trampoline.GetComponent<AudioSource>().Play();
        }


    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (spieler.GetComponent<BoxCollider2D>().IsTouching(terrain.GetComponent<CompositeCollider2D>()))
    //    {
    //        anWand = false;
    //        amBoden = true; //--> Muss man mit OnCollisionExit wieder umkehren
    //        animator.SetBool("isTouchingWall", false);            
    //    }
    //}



}
