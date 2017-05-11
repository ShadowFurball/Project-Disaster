using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chevrons : Alert
{

    // Use this for initialization
    void Start()
    {
        transform.GetChild(transform.childCount - 1).GetComponent<FadeInOut>().onComplete = () =>
        {
            Destroy(gameObject);
            onComplete();
        };
    }
}
