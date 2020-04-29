using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVelocity : MonoBehaviour, IMoveVelocity
{

    [SerializeField] private float moveSpeed;

    private Rigidbody2D rigidbody2D;
    private Vector3 velocityVector;
    //private Character_Base characterBase;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        //characterBase = GetComponent<Character_Base>();
    }

    public void SetVelocity(Vector3 velocityVector)
    {
        this.velocityVector = velocityVector;
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = velocityVector * moveSpeed;

        //characterBase.PlayMoveAnim(velocityVector);
    }
}
