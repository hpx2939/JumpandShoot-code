using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverPanel;
    void Awake()
    {
        Time.timeScale = 1f;
    }


    public void GameOver()
    {
        StartCoroutine(GameOverCoroutine());
       
    }
    IEnumerator GameOverCoroutine()
    {
        Time.timeScale = 0.02f;
        yield return new WaitForSecondsRealtime(0.5f);
        gameoverPanel.SetActive(true);
        GetComponent<ScoreManager>().ChangeColorToWhite();
        yield break ;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }






}
