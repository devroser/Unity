using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Configuration parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    // Cached reference
    Level level;

    // State variables
    [SerializeField] int timesHit; // TODO only serialized for debug purposes

    private void Start()
    {
        countBreakableBlocks();
    }

    private void countBreakableBlocks()
    {
        level = FindObjectOfType<Level>();

        if (tag == "Breakable")
        {
            level.countBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            handleHit();
        }
    }

    private void handleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            showNextHitSprite();
        }
    }

    private void showNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        playBlockDestroySFX();
        Destroy(gameObject);
        level.blockDestroyed();
        triggerSparklesVFX();

    }

    private void playBlockDestroySFX()
    {
        FindObjectOfType<GameSession>().addToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void triggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
