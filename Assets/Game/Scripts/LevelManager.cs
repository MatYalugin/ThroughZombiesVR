using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
public void changeLevel(int index)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(index);
    }
    public void goToMainMenuWithDelay()
    {
        Invoke("changeLevel(0)", 0.5f);
    }
    public void reloadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
