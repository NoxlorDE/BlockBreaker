using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    //config params   
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    //Cached Reference
    Level level;
    GameSession gameSession;

    //state variables
    [SerializeField] int timesHit; //Serialized for Debug


    // Start is called before the first frame update

    private void Start()
    {
        CountBreakableBlocks();

        gameSession = FindObjectOfType<GameSession>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            HandleHit();
        }

    }

    private void HandleHit()
    {
        int maxHits = hitSprites.Length + 1;
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprites();
        }
    }

    private void ShowNextHitSprites()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex] !=null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite missing from array! " + gameObject.name);
        }

    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void DestroyBlock()
    {
        PlayAudio();
        Destroy(gameObject);
        TriggerSparklesVFX();
        level.BlockDestroyed();
        gameSession.AddToScore();
    }

    private void PlayAudio()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
