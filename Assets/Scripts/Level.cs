using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    
    [SerializeField] int breakableBlocks;
    public bool islowMotionEnabled;

    //chached references
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        
    }


    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            islowMotionEnabled = true;
            StartCoroutine(SlowMotion());
            
        }
    }

    IEnumerator SlowMotion()
    {
        yield return new WaitForSeconds(0.1f);
        sceneLoader.LoadNextScene();
        islowMotionEnabled = false;
    }

}
