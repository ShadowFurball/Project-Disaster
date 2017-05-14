using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlwind : Disaster
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + 7.5f, transform.position.y, transform.position.z);
        transform.Rotate(0, 0, -Time.deltaTime * 400);
    }
}
