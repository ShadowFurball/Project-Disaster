using DigitalRuby.Tween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Disaster
{
    public GameObject explosion;

    private Transform meteorAnim;

    // Use this for initialization
    void Start()
    {
        meteorAnim = transform.GetChild(0);
        Vector3 initialPosition = meteorAnim.position;

        TweenFactory.Tween(null, 0f, 700f, 0.8f, TweenScaleFunctions.Linear, (t) =>
        {
            meteorAnim.position = new Vector3(initialPosition.x - t.CurrentValue, initialPosition.y - t.CurrentValue, 0f);
        }, (t) =>
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
