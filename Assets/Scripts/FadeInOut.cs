using DigitalRuby.Tween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public float startDelay = 0f;
    public int fadeCount = 10;
    public float fadeTime = 1f;
    public bool fadeIn = true;
    public delegate void OnComplete();
    public OnComplete onComplete;

    private System.Action<ITween<float>> UpdateAlpha;
    private System.Action<ITween<float>> TweenComplete;
    private SpriteRenderer sprite;

    // Use this for initialization
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();

        UpdateAlpha = (t) => { sprite.color = new Color(1f, 1f, 1f, t.CurrentValue); };
        TweenComplete = (t) =>
        {
            fadeIn = !fadeIn;
            fadeCount--;
            if (fadeCount > 0) DoFade();
            else
            {
                if (onComplete != null) onComplete();
            }
        };

        Invoke("DoFade", startDelay);
    }

    void DoFade()
    {
        TweenFactory.Tween(null, fadeIn ? 0f : 1f, fadeIn ? 1f : 0f, fadeTime, TweenScaleFunctions.Linear, UpdateAlpha, TweenComplete);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
