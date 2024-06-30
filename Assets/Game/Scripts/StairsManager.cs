using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsManager : MonoBehaviour
{

    public GameObject stairPrefab;

    int stairIndex = 0;
    float distanceToNextStair = 3f;

    float stairWidth = 2f;
    float stairHeight = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        InitStairs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void InitStairs()
    {
        for (int i = 0; i < 5; i++)
        {
            MakeStair();
        }
    }

    public void MakeStair()
    {
        Vector2 position = new Vector2(0, stairIndex * distanceToNextStair );
        GameObject newStairObj = Instantiate(stairPrefab, position, Quaternion.identity);
        newStairObj.transform.SetParent(transform);
        newStairObj.transform.localScale = new Vector2(stairWidth ,stairHeight );
        SetSpeed(newStairObj);
        DecreaseStair();

        stairIndex ++;
    }
    void SetSpeed(GameObject newStairObj)
    {
        newStairObj.GetComponent<Stair>().velocity = Random.Range(-3, 4);
    }

    void DecreaseStair()
    {
        if (stairWidth > 0.7f)
        {
            stairWidth -= 0.03f;
        }
    }

}
