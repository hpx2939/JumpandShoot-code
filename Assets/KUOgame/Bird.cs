using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour
{
    private bool isDead = false;            
    private Animator anim;                    
    Rigidbody2D playrigidbody2D;

    public object GameContrl { get; private set; }

    void Start()
    {
       
        anim = GetComponent<Animator>();
        playrigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       BirdAtWall();
        if (isDead == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetTrigger("Flap");
                playrigidbody2D.AddForce(Vector2.up * 300);
            }
        }
    }
    void BirdAtWall()
    {
        if (playrigidbody2D.position.y > 4.6f)
        {
            playrigidbody2D.position = new Vector2(playrigidbody2D.position.x, 4.6f);
            playrigidbody2D.velocity = new Vector2(playrigidbody2D.velocity.x, -playrigidbody2D.velocity.y/1000);
            
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
  
        playrigidbody2D.velocity = Vector2.zero;

        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }

    
}