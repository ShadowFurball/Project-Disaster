using DigitalRuby.Tween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : Alert
{

    // Use this for initialization
    void Start()
    {
        TweenFactory.Tween(null, 0f, 720f, 2f, TweenScaleFunctions.Linear, (t) =>
        {
            transform.localEulerAngles = new Vector3(0f, 0f, t.CurrentValue);
        }, (t) =>
        {
            Destroy(gameObject);
            onComplete(this);
        });
    }
}
