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
    private float moveSpeed;
    private float frameSpeed;
    private float horizontalAxis;
    private float verticalAxis;
    private float randomT;
    Vector3 position;
    Vector3 start;
    Vector3 movement;
    public Text uiText1;
    public Text uiText2;
    public Text uiText3;
    public float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        spriteAnimator.playAnimation(IdleAnimationFrameArray, 1f);
        start = position = transform.position;
        rBody = GetComponent<Rigidbody2D>();
        uiText1 = GameObject.Find("GuestPosition").GetComponent<Text>();
        uiText2 = GameObject.Find("GuestInfo").GetComponent<Text>();
        uiText3 = GameObject.Find("GuestMisc").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = rBody.velocity.x;
        verticalAxis = rBody.velocity.y;
        randomT = Random.Range(2f, 7f);
        float placeX = (horizontalAxis < 0 ? horizontalAxis * -1 : horizontalAxis);
        float placeY = (verticalAxis < 0 ? verticalAxis * -1 : verticalAxis);
        //horizontalAxis = Input.GetAxis("Horizontal") * moveSpeed;
        //verticalAxis = Input.GetAxis("Vertical") * moveSpeed;


        //transform.Translate(movement);
        uiText1.text = "X: " + horizontalAxis.ToString();
        uiText2.text = "Y: " + verticalAxis.ToString();
        timeLeft -= Time.deltaTime;
        position = transform.position;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft += randomT;
            start = transform.position;
        }
        moveSpeed = rBody.velocity.magnitude;
        frameSpeed = moveSpeed * 2f;
        uiText3.text = "Speed: " + moveSpeed.ToString() + " | Frame speed: " +frameSpeed.ToString() ;
        //uiText3.text = placeX.ToString();
        if (placeX > placeY)
        {
            if (rBody.velocity.x > 0f) { PlayAnimation(AnimationType.Right); }
            if (rBody.velocity.x < 0f) { PlayAnimation(AnimationType.Left); }
        }
        if (placeY > placeX)
        {
            if (rBody.velocity.y > 0f) { PlayAnimation(AnimationType.Up); }
            if (rBody.velocity.y < 0f) { PlayAnimation(AnimationType.Down); }
        }
        if (rBody.velocity.magnitude < 0) { PlayAnimation(AnimationType.Idle); }

    }

    void FixedUpdate()
    {

        rBody.velocity = new Vector3(movement.x, movement.y, 0);
        //rBody.AddForce(movement);
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
                    spriteAnimator.playAnimation(UpAnimationFrameArray, frameSpeed);
                    break;
                case AnimationType.Down:
                    spriteAnimator.playAnimation(DownAnimationFrameArray, frameSpeed);
                    break;
                case AnimationType.Left:
                    spriteAnimator.playAnimation(LeftAnimationFrameArray, frameSpeed);
                    break;
                case AnimationType.Right:
                    spriteAnimator.playAnimation(RightAnimationFrameArray, frameSpeed);
                    break;
            }
        }
    }
}
