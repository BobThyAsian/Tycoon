using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{

    Camera mainCamera;
    float moveSpeed = 10f;
    float zoomMin = 6f;
    float zoomMax = 20f;
    Vector3 movement;
    public Text uiText1;
    public Text uiText2;
    
    void Start()
    {
        mainCamera = Camera.main;
        uiText1 = GameObject.Find("GuestPosition").GetComponent<Text>();
        uiText2 = GameObject.Find("GuestInfo").GetComponent<Text>();
    }
    void FixedUpdate()
    {

        
        //if(horizontalAxis > 0) { direction = Vector3.right; }
        //if(horizontalAxis < 0) { direction = Vector3.left; }
        //if(verticalAxis > 0) { direction = Vector3.up; }
        //if(verticalAxis < 0) { direction = Vector3.down; }

        
    }
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float verticalAxis = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float scrollAxis = Input.GetAxis("Mouse ScrollWheel") * 5f;
                
        uiText1.text = mainCamera.orthographicSize.ToString();
        uiText2.text = scrollAxis.ToString();

        
        if(mainCamera.orthographicSize <= zoomMin)
        {
            mainCamera.orthographicSize = zoomMin;
        }
        if(mainCamera.orthographicSize >= zoomMax)
        {
            mainCamera.orthographicSize = zoomMax;
        }
        mainCamera.orthographicSize -= scrollAxis;
        movement = new Vector3(horizontalAxis, verticalAxis , 0);
        //Debug.Log(uiText1.text);
        transform.Translate(movement);
    }

}
