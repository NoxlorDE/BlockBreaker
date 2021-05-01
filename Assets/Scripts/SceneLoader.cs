using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadNextScene()
    {
        int currentSceneIndex = CurrentScene();
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGameSession();
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(FindObjectOfType<GameSession>().currentScene);
    }

    public void QuiGame()
    {
        Application.Quit();
    }

    public int CurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

}
