using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    
    //config paramameters
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 0.8f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] bool isAutoPlayEnabled;

    //state variables
    [SerializeField] int currentScore = 0;
    public int currentScene;
    float slowMotionSpeed = 0.05f;

    AudioSource myAudioSource;

    private void Awake()
    {
        //Prevent GameStatus to be destroyed each new scene ("Singleton Pattern")-
        int gameStatusCount = FindObjectsOfType<GameSession>().Length; //Count number of GameStatus objects
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<Level>().islowMotionEnabled)
        {
            Time.timeScale = gameSpeed;
            winText.text = "";
        }
        else
        {
            Time.timeScale = slowMotionSpeed;
            winText.text = "You got it!";
        }

    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGameSession() //Reset Game
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    public void CurrentScene()
    {
        currentScene = FindObjectOfType<SceneLoader>().CurrentScene();
    }

}
