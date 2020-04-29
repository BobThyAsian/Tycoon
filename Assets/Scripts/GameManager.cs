using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject personPrefab;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CreatePerson()
    {
        GameObject person = Instantiate(personPrefab, new Vector3(0f,0f,0f), Quaternion.identity) as GameObject;
    }
}
