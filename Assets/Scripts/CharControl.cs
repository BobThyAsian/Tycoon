using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharControl : MonoBehaviour
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
    public Rigidbody2D rBody;
    private float moveSpeed = 3f;
    private float horizontalAxis;
    private float verticalAxis;
    private float randomT;
    Vector3 position;
    Vector3 movement;
    public Text uiText1;
    public Text uiText2;
    public float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        spriteAnimator.playAnimation(IdleAnimationFrameArray, 1f);
        position = transform.position;
        rBody = GetComponent<Rigidbody2D>();
        uiText1 = GameObject.Find("GuestPosition").GetComponent<Text>();
        uiText2 = GameObject.Find("GuestInfo").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal") * moveSpeed;
        verticalAxis = Input.GetAxis("Vertical") * moveSpeed;
        randomT = Random.Range(2f, 7f);

        //transform.Translate(movement);
        uiText1.text = horizontalAxis.ToString();
        uiText2.text = verticalAxis.ToString();
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft += randomT;
        }
        if (horizontalAxis > 0) { PlayAnimation(AnimationType.Right); }
        if (horizontalAxis < 0) { PlayAnimation(AnimationType.Left); }
        if (verticalAxis > 0) { PlayAnimation(AnimationType.Up); }
        if (verticalAxis < 0) { PlayAnimation(AnimationType.Down); }
        if (horizontalAxis == 0 && verticalAxis == 0) { PlayAnimation(AnimationType.Idle); }

    }

    void FixedUpdate()
    {
        //rBody.velocity = new Vector3(horizontalAxis, verticalAxis, 0);
        rBody.AddForce(movement);
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
