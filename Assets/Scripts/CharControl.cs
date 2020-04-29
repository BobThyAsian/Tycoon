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
    private GameObject selectedGameObject;
    public Rigidbody2D rBody;
    //public Vector2 direction;
    public Vector3 position;
    public Vector3 start;
    //private float moveSpeed;
    //private float frameSpeed;
    private float horizontalAxis;
    private float verticalAxis;
    //private float randomT;
    //Vector3 movement;
    //public float timeLeft;
    //public Text uiText1;
    public Text uiText2;
    public Text uiText3;


    private void Awake()
    {
        selectedGameObject = transform.Find("Selected").gameObject;
        SetSelectedVisible(false);
        start = position = transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteAnimator.playAnimation(IdleAnimationFrameArray, 1f);
        rBody = GetComponent<Rigidbody2D>();

        //uiText1 = GameObject.Find("GuestMisc").GetComponent<Text>();
        uiText2 = GameObject.Find("GuestBug").GetComponent<Text>();
        uiText3 = GameObject.Find("GuestInfo").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalAxis = rBody.velocity.x;
        verticalAxis = rBody.velocity.y;
        float placeX = (horizontalAxis < 0 ? horizontalAxis * -1 : horizontalAxis);
        float placeY = (verticalAxis < 0 ? verticalAxis * -1 : verticalAxis);

        if (placeX > placeY)
        {
            if (rBody.velocity.x > 0f) { PlayAnimation(AnimationType.Right); }
            if (rBody.velocity.x < 0f) { PlayAnimation(AnimationType.Left); }
            Debug.Log("l/r");
        }
        if (placeY > placeX)
        {
            if (rBody.velocity.y > 0f) { PlayAnimation(AnimationType.Up); }
            if (rBody.velocity.y < 0f) { PlayAnimation(AnimationType.Down); }
            Debug.Log("up/down");
        }
        if (rBody.velocity.magnitude == 0 ) { PlayAnimation(AnimationType.Idle); }
        uiText3.text = "VX: " + rBody.velocity.x.ToString() + " | VY: " + rBody.velocity.ToString();
        uiText2.text = "Start: " + start.ToString() + " | Pos: " + position.ToString();
        //start = transform.position;
        
    }

    void FixedUpdate()
    {
    }
    private void PlayAnimation(AnimationType animationType)
    {
        Debug.Log(animationType);
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


    public void SetSelectedVisible(bool visible)
    {
        selectedGameObject.SetActive(visible);
    }
}


        /*    **************Trial 1 fixedupdate ****************
        rBody.velocity = new Vector3(movement.x, movement.y, 0);
        rBody.AddForce(movement);
        */   
        
    
        /*   *************Trial 1******************* in Update
        horizontalAxis = rBody.velocity.x;
        verticalAxis = rBody.velocity.y;
        randomT = Random.Range(2f, 7f);
        float placeX = (horizontalAxis < 0 ? horizontalAxis * -1 : horizontalAxis);
        float placeY = (verticalAxis < 0 ? verticalAxis * -1 : verticalAxis);
        //horizontalAxis = Input.GetAxis("Horizontal") * moveSpeed;
        //verticalAxis = Input.GetAxis("Vertical") * moveSpeed;


        //transform.Translate(movement);
        uiText1.text = "Frame speed: " + frameSpeed.ToString() + " | Position: " + position.ToString();
        uiText2.text = "Y: " + verticalAxis.ToString() + "X: " + horizontalAxis.ToString();
        timeLeft -= Time.deltaTime;
        position = transform.position;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft += randomT;
            start = transform.position;
        }
        moveSpeed = rBody.velocity.magnitude;
        frameSpeed = 1/moveSpeed;
        uiText3.text = "Magnitude: " + moveSpeed.ToString() + " | Velocity: " + rBody.velocity.ToString();
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
        */