using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.Tween;

public class Attract : MonoBehaviour {

    const float MOVE_SPEED = 100f;
    Vector3Tween moveTween;

    public void DoAttract(Vector3 targetPosition)
    {
        Vector3 bounds = GetComponent<SpriteRenderer>().bounds.extents;

        while (targetPosition.x < bounds.x || targetPosition.x > Screen.width - bounds.x || targetPosition.y < bounds.y || targetPosition.y > Screen.height - bounds.y) ;
        float distance = Vector3.Distance(transform.position, targetPosition);
        float time = distance / MOVE_SPEED;

        moveTween = TweenFactory.Tween(null, transform.position, targetPosition, time, TweenScaleFunctions.Linear, (t) =>
        {
            transform.position = t.CurrentValue;
        }, (t) =>
        {
            moveTween = null;
        });

    }

    public void StopAttract()
    {
        if (moveTween != null)
        {
            moveTween.Stop(TweenStopBehavior.Complete);
            moveTween = null;
        }
    }
}
