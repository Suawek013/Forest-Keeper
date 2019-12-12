using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config parameters
    [SerializeField] AudioClip BreakSounds;
    [SerializeField] GameObject blockSparklexVFX;
    [SerializeField] Sprite[] hitSprites;
    [SerializeField] float movingFactor = 1;

    private Vector2 MovingDirection = Vector2.left;


    // Cached reference
    Level level;

    // state variables
    [SerializeField] int timesHit; // TODO only serialized for debug purposes
    bool StartMove = false;

    private void Start()
    {
        CountBreakableBlocks();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            {
                StartMove = true;           
            }
        if (StartMove == true &&tag == "Moving")
        {
            UpdateMovement();
        }
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable" || tag == "Moving")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable" || tag == "Moving")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
            PlayBlockDestroySFX();
            Destroy(gameObject);
            TriggerSparklesVFX();
            level.BlockDestroyed();
    }

    private void PlayBlockDestroySFX()
    {
        FindObjectOfType<GameSession>().AddToScore();
        float volume = 0.3F;
        AudioSource.PlayClipAtPoint(BreakSounds, Camera.main.transform.position, volume);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklexVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
    private void UpdateMovement()
    {
        if (transform.position.x > 15f)
        {
            MovingDirection = Vector2.left;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;

        }
        else if (transform.position.x < 1f)
        {
            MovingDirection = Vector2.right;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;

        }
        transform.Translate(MovingDirection * Time.smoothDeltaTime * movingFactor);
    }
}
