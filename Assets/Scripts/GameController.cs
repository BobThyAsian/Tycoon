using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.UI;
//using System;
//using System.Linq;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform selectionAreaTrans;
    private Vector3 startPosition;
    private Vector3 endPostion;
    private Text uiText1;
    private Text uiText2;
    //private Text uiText3;
    //private Text uiText4;
    private Collider2D[] collider2DArray;
    public List<CharControl> people;


    private void Awake()
    {
        people = new List<CharControl>();
        selectionAreaTrans.gameObject.SetActive(false);
    }
    private void Start()
    {
        uiText1 = GameObject.Find("GuestMisc").GetComponent<Text>();
        uiText2 = GameObject.Find("GuestPosition").GetComponent<Text>();
        //uiText3 = GameObject.Find("GuestInfo").GetComponent<Text>();
        //uiText4 = GameObject.Find("GuestBug").GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {

        //Left mouse button down
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = UtilsClass.GetMouseWorldPosition();
            selectionAreaTrans.gameObject.SetActive(true);
        }
        //Left mouse button hold
        if (Input.GetMouseButton(0))
        {
            Vector3 currentMousePosition = UtilsClass.GetMouseWorldPosition();
            Vector3 lowerLeft = new Vector3(
                Mathf.Min(startPosition.x, currentMousePosition.x),
                Mathf.Min(startPosition.y, currentMousePosition.y)
                );
            Vector3 upperRight = new Vector3(
                Mathf.Max(startPosition.x, currentMousePosition.x),
                Mathf.Max(startPosition.y, currentMousePosition.y)
                );

            selectionAreaTrans.position = lowerLeft;
            selectionAreaTrans.localScale = upperRight - lowerLeft;

        }
        //Left mouse button up
        if (Input.GetMouseButtonUp(0))
        {
            endPostion = UtilsClass.GetMouseWorldPosition();
            selectionAreaTrans.gameObject.SetActive(false);
            collider2DArray = Physics2D.OverlapAreaAll(startPosition, endPostion);
            foreach(CharControl charControl in people)
            {
                charControl.SetSelectedVisible(false);
            }
            people.Clear();
            foreach (Collider2D collider2D in collider2DArray)
            {
                CharControl charControl = collider2D.GetComponent<CharControl>();
                if (charControl != null)
                {
                    charControl.SetSelectedVisible(true);
                    people.Add(charControl);
                }
            }
        }


        // GUI - DEBUG
        uiText1.text = "Start: " + startPosition.ToString();
        uiText2.text = "End: " + endPostion.ToString();
        /*if (collider2DArray != null)
        {
            uiText3.text = "Objects: " + String.Join(",", collider2DArray.ToList());
        }
        if (people != null)
        {
            uiText4.text = "People: " + String.Join(",", people);
        }*/
    }

}
