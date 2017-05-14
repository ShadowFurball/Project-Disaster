using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.Tween;

public class Wander : MonoBehaviour
{
    const float MOVE_SPEED = 100f;
    const float MAX_MOVE_DISTANCE = 200f;
    const float MIN_IDLE_TIME = 1f;
    const float MAX_IDLE_TIME = 5f;

    Vector3Tween moveTween;

	// Use this for initialization
	void Start ()
	{
        Invoke("DoWander", Random.Range(MIN_IDLE_TIME, MAX_IDLE_TIME));
	}

    void DoWander()
    {
        if (GameManager.instance.selectedPerson == gameObject)
        {
            Invoke("DoWander", Random.Range(MIN_IDLE_TIME, MAX_IDLE_TIME));
            return;
        }

        Vector2 point;
        Vector3 targetPosition;
        Vector3 bounds = GetComponent<SpriteRenderer>().bounds.extents;

        do
        {
            point = Random.insideUnitCircle * MAX_MOVE_DISTANCE;
            targetPosition = transform.position + new Vector3(point.x, point.y, 0f);
        }
        while (targetPosition.x < bounds.x || targetPosition.x > Screen.width - bounds.x || targetPosition.y < bounds.y || targetPosition. y > Screen.height - bounds.y);

        float distance = Vector3.Distance(transform.position, targetPosition);
        float time = distance / MOVE_SPEED;

        moveTween = TweenFactory.Tween(null, transform.position, targetPosition, time, TweenScaleFunctions.Linear, (t) =>
        {
            transform.position = t.CurrentValue;
        }, (t) =>
        {
            moveTween = null;
            Invoke("DoWander", Random.Range(MIN_IDLE_TIME, MAX_IDLE_TIME));
        });
    }

    public void StopWander()
    {
        if (moveTween != null)
        {
            moveTween.Stop(TweenStopBehavior.Complete);
            moveTween = null;
        }
    }
}
