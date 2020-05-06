using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] private SpriteAnimator spriteAnimator;
    [SerializeField] private Sprite[] IdleAnimationFrameArray;
    [SerializeField] private Sprite[] UpAnimationFrameArray;
    [SerializeField] private Sprite[] DownAnimationFrameArray;
    [SerializeField] private Sprite[] RightAnimationFrameArray;
    [SerializeField] private Sprite[] LeftAnimationFrameArray;
    private enum AnimationType
    {
        Idle,
        Up,
        Down,
        Right,
        Left,
    }
    private AnimationType activeAnimationType;
    private GameObject selectedGameObject;
    private Rigidbody2D rBody;
    private float horizontalAxis;
    private float verticalAxis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        horizontalAxis = rBody.velocity.x;
        verticalAxis = rBody.velocity.y;
        float placeX = (horizontalAxis < 0 ? horizontalAxis * -1 : horizontalAxis);
        float placeY = (verticalAxis < 0 ? verticalAxis * -1 : verticalAxis);

        if (placeX > placeY)
        {
            if (rBody.velocity.x > 0f) { PlayAnimation(AnimationType.Right); Debug.Log("right"); }
            if (rBody.velocity.x < 0f) { PlayAnimation(AnimationType.Left); Debug.Log("left"); }

        }
        if (placeY > placeX)
        {
            if (rBody.velocity.y > 0f) { PlayAnimation(AnimationType.Up); Debug.Log("up"); }
            if (rBody.velocity.y < 0f) { PlayAnimation(AnimationType.Down); Debug.Log("down"); }

        }
        if (rBody.velocity.magnitude == 0) { PlayAnimation(AnimationType.Idle); Debug.Log("idle"); }

    }
    private void PlayAnimation(AnimationType animationType)
    {
        if (animationType != activeAnimationType)
        {
            activeAnimationType = animationType;
            switch (animationType)
            {
                case AnimationType.Idle:
                    spriteAnimator.playAnimation(IdleAnimationFrameArray, 1f);
                    break;
                case AnimationType.Up:
                    spriteAnimator.playAnimation(UpAnimationFrameArray, .1f);
                    break;
                case AnimationType.Down:
                    spriteAnimator.playAnimation(DownAnimationFrameArray, .1f);
                    break;
                case AnimationType.Left:
                    spriteAnimator.playAnimation(LeftAnimationFrameArray, .1f);
                    break;
                case AnimationType.Right:
                    spriteAnimator.playAnimation(RightAnimationFrameArray, .1f);
                    break;
            }
        }
    }
}
