using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlwind : Disaster
{
    private int direction = 1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + (direction * 7.5f), transform.position.y, transform.position.z);
        transform.Rotate(0, 0, -Time.deltaTime * 400);
    }

    public void OffsetFromAlert(Alert alert)
    {
        if (alert.transform.localEulerAngles.z == 180f)
        {
            transform.position = alert.transform.position + new Vector3(200f, 0f, 0f);
            direction = -1;
        }
        else
        {
            transform.position = alert.transform.position - new Vector3(200f, 0f, 0f);
        }
    }
}
