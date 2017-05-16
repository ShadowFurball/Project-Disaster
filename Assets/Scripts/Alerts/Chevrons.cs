using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chevrons : Alert
{
    // Use this for initialization
    void Start()
    {
        bool LHS = Random.value > 0.5;
        transform.position = new Vector3(LHS ? 0f : 1920f, Random.Range(80f, 1000f), 0f);
        if (!LHS)
        {
            transform.localEulerAngles = new Vector3(0f, 0f, 180f);
        }

        transform.GetChild(transform.childCount - 1).GetComponent<FadeInOut>().onComplete = () =>
        {
            Destroy(gameObject);
            onComplete(this);
        };
    }
}
