using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGrid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GridBase grid = new GridBase();
        grid.Build(10,10, 1f, new Vector3(-11,-11));

    }

}
