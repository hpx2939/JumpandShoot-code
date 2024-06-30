using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour
{

    public float velocity = 1;
    float distance = 2.7f;
    float angle = 0;
    Player playerScript;

    // Start is called before the first frame update
    void Awake()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Move();

        if (playerScript.isDead) return;
        
        
    }
    void Move()
    {
        transform.position = new Vector2(Mathf.Sin(angle) * distance, transform.position.y);
        angle += velocity /200f;
    }
    public IEnumerator  LandingEffect()
    {
        Vector2 originalPosition = transform.position;
        float yChangValue = 0.7f;

        while (yChangValue > 0)
        {
            yChangValue -= 0.1f;
            yChangValue = Mathf.Clamp(yChangValue, 0, 1.5f);
            transform.position = new Vector2(transform.position.x, originalPosition.y - yChangValue);
            yield return 0;
        }
        yield break;
    }

}
