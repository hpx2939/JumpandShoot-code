using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    enum PlayerState
    {
        Standing , Jumping ,Falling
    }

    public Transform playerParentTransfrom;

    PlayerState currentState = PlayerState .Falling ;

    Rigidbody2D rb;
    BoxCollider2D bc2D;

    float previousPosXofParent;
    [HideInInspector ]
   public  bool isDead = false;

    public GameObject shootEffectPrefab;
    public GameObject deadEffectPrefab;

    float hueValue;
    void Awake()
    {
        rb = GetComponent <Rigidbody2D>();
        bc2D = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        hueValue = Random.Range(0, 1f);
        ChangeBackgroundColor();
       
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        BounceAtWall();
        GetPreviousPositionOfParent();
        DeadCheck();
    }
    void GetInput()
    { if (Input.GetMouseButtonDown (0) ){
        if (currentState == PlayerState.Standing)
        {
            Jump();
        }
        else if (currentState == PlayerState.Jumping)
        {
            StartCoroutine(Shoot());
        }
    }
    }
    void GetPreviousPositionOfParent()
    {
        previousPosXofParent = transform.position.x;

    }
    void Jump(){
        
        bc2D.enabled = false;
        currentState = PlayerState.Jumping;

        rb.velocity = new Vector2 (ParentVelocity() ,10);

        transform.SetParent(playerParentTransfrom);
    }
    float ParentVelocity()
    {
        return (transform.parent.transform.position.x - previousPosXofParent) / (5*Time.deltaTime);
    }
    IEnumerator Shoot()
    {
       GameObject shootEffectObj = Instantiate(shootEffectPrefab,transform.position, Quaternion.identity);
       
       shootEffectObj.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.HSVToRGB(hueValue, 0.6f, 0.8f);
       Destroy(shootEffectObj, 1.0f);
        currentState = PlayerState.Falling;

        StopPlayer();

        yield return new WaitForSeconds(0.5f);

        ChangeBackgroundColor();

        bc2D.enabled = true;
        rb.isKinematic = false;
        rb.velocity = new Vector2(0, -30);
        yield break;
    }

  void BounceAtWall()
    {
        if (rb.position.x < -2.2f)
        {
            rb.position = new Vector2(-2.2f, rb.position.y);
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }
        if (rb.position.x > 2.2f)
        {
            rb.position = new Vector2(2.2f, rb.position.y);
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }
    }

    void DeadCheck()
    {
        if (isDead == false && Camera .main .transform .position .y - transform .position .y > 5)
        {
            isDead = true;
            StopPlayer();
            DeadEffect();
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();  
           
            
       
           
        }
    }
    void StopPlayer()
    {
        rb.isKinematic = true;
        rb.velocity = new Vector2(0, 0);
    }
    void DeadEffect(){
        Destroy(Instantiate(deadEffectPrefab, transform.position, Quaternion.identity), 1.0f);
}

    void OnCollisionEnter2D(Collision2D other){
        rb.velocity = Vector2.zero;
        currentState = PlayerState.Standing;
        transform.SetParent(other.gameObject.transform);

        StartCoroutine(other.gameObject.GetComponent<Stair>().LandingEffect());

        GameObject.Find("GameManager").GetComponent<ScoreManager>().AddScore();
    }

    void ChangeBackgroundColor()
    {
        Camera.main.backgroundColor = Color.HSVToRGB(hueValue, 0.6f, 0.8f);
        hueValue += 0.08f;
        if (hueValue >= 1)
        {
            hueValue = 0;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {

        GameObject.Find("Stairs").GetComponent<StairsManager>().MakeStair();
        Destroy(other.gameObject, 0.1f);
    }
 
}
