using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField] private Sprite[] frameArray;
    private int currentFrame;
    private float timer;
    private float frameRate = .1f;
    private SpriteRenderer spriteRenderer;
    private bool loop = true;
    private bool isPlaying = true;


    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        if (!isPlaying)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= frameRate)
        {
            timer -= frameRate;
            currentFrame = (currentFrame + 1) % frameArray.Length;
            if( !loop && currentFrame == 0)
            { 
                StopPlaying(); 
            } 
            else
            { 
                spriteRenderer.sprite = frameArray[currentFrame]; 
            }

        }
    }

    private void StopPlaying()
    {
        isPlaying = false;
    }

    public void playAnimation(Sprite[] frameArray, float framerate)
    {
        this.frameRate = framerate;
        this.frameArray = frameArray;
        currentFrame = 0;
        timer = 0f;
        spriteRenderer.sprite = frameArray[currentFrame];
    }
}
