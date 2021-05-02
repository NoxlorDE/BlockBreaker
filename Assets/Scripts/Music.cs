using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    // Start is called before the first frame update


    private void Awake()
    {
        //Prevent GameStatus to be destroyed each new scene ("Singleton Pattern")-
        int gameStatusCount = FindObjectsOfType<Music>().Length; //Count number of GameStatus objects
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


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
