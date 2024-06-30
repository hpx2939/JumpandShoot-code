using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;            //A reference to our game control script so we can access it statically.
    public Text scoreText;                        //A reference to the UI text component that displays the player's score.
    public GameObject gameOvertext;                //A reference to the object that displays the text which appears when the player dies.

    private int score = 0;                        //The player's score.
    public bool gameOver = false;                //Is the game over?
    public float scrollSpeed = -1.5f;

    
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Update()
    {
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
  
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (gameOver && Input.GetKeyDown(KeyCode.Escape ))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }
    }

    public void BirdScored()
    {
        if (gameOver)
            return;
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void BirdDied()
    {
        gameOvertext.SetActive(true);
        gameOver = true;
    }
}