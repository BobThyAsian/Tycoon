using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePositionDirect : MonoBehaviour
{
    [SerializeField]private Vector3 movePosition;


    public void SetMovePosition(Vector3 movePosition)
    {
        this.movePosition = movePosition;
        Debug.Log("called");
    }

    private void Awake()
    {
        if(movePosition.z == 0)
        {
            movePosition = transform.position;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = (Vector3.Distance(transform.position, movePosition) < .1f) ? Vector3.zero : (movePosition - transform.position).normalized;
        GetComponent<IMoveVelocity>().SetVelocity(moveDir);
        Debug.Log(movePosition+" "+transform.position);
    }
}
