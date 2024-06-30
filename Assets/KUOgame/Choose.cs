using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Choose : MonoBehaviour
{
    public void BackMenu1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void quit3()
    {
        Application.Quit();
    }
}
